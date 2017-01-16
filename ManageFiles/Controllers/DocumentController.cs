namespace ManageFiles.Controllers
{
    using Common.DTO;
    using Infrastructure.IServices;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ManageFiles.Models;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using PagedList;

    public class DocumentController : Controller
    {
        private IDocumentService _documentService;
        private readonly string _targetURL = "http://localhost:8080/rs-files-service/webresources/SendFiles/sendFile/multipart";
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public ActionResult GetDocuments(int? page)
        {
            List<DocumentDTO> documents = _documentService.GetAllDocuments().ToList();

            //pagination config
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //end config

            return View(documents.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View(new SearchResultsModel());
        }

        [HttpPost]
        public ActionResult Search(SearchResultsModel model)
        {
            if (ModelState.IsValid)
            {
                var documents = _documentService.GetAllDocuments();

                if (model.Id > 0)
                {
                    documents = documents.Where(x => x.Id == model.Id).ToList();
                }

                if (model.ContentUUID != default(Guid))
                {
                    documents = documents.Where(x => x.ContentUUID == model.ContentUUID).ToList();
                }

                if (!string.IsNullOrWhiteSpace(model.UploadedBy))
                {
                    documents = documents.Where(x => x.UploadedBy == model.UploadedBy).ToList();
                }

                if (!string.IsNullOrWhiteSpace(model.DocumentName))
                {
                    documents = documents.Where(x => x.DocumentName == model.DocumentName).ToList();
                }

                if (!string.IsNullOrWhiteSpace(model.DocumentExternalURI))
                {
                    documents = documents.Where(x => x.DocumentExternalURI == model.DocumentExternalURI).ToList();
                }
                model.SearchResults = documents;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View(new DocumentViewModel());
        }

        [HttpPost]
        public ActionResult Upload(DocumentViewModel viewModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null && file.ContentLength > 0)
            {
                // Get file info
                var fileName = file.FileName;
                var contentLength = file.ContentLength;
                var contentType = file.ContentType;

                MultipartFormDataContent requestContent = new MultipartFormDataContent();
                HttpContent fileContent = new StreamContent(file.InputStream);

                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
                fileContent.Headers.ContentLength = contentLength;

                // Add the file
                requestContent.Add(fileContent, "file", fileName);

                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(_targetURL, requestContent).Result;

                _documentService.InsertDocument(new DocumentDTO
                {
                    ContentUUID = new Guid(response.Content.ReadAsStringAsync().Result), //UUID returned from web service
                    DocumentName = viewModel.DocumentName,
                    UploadedBy = viewModel.UploadedBy,
                    DateUploaded = viewModel.DateUploaded,
                    DocumentExternalURI = viewModel.DocumentExternalURI
                });
                return RedirectToAction("GetDocuments", "Document");
            }
            else
            {
                return RedirectToAction("Upload", "Document");
            }
        }
    }
}