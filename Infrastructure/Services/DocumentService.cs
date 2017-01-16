namespace Infrastructure.Services
{
    using Common.DTO;
    using DataAccess;
    using DataAccess.GenericRepository;
    using Infrastructure.IServices;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class DocumentService : IDocumentService
    {
        private GenericRepository<DOCUMENTS> _repo;

        public DocumentService()
        {
            _repo = new GenericRepository<DOCUMENTS>();
        }

        public List<DocumentDTO> GetAllDocuments()
        {
            return AutoMapper.Mapper
                .Map<List<DocumentDTO>>(_repo
                .GetAllRecords()
                .ToList());
        }

        public void InsertDocument(DocumentDTO dto)
        {
            dto.DateUploaded = DateTime.Now;
            DOCUMENTS entity = new DOCUMENTS()
            {
                CONTENT_UUID = dto.ContentUUID,
                DOC_NAME = dto.DocumentName,
                UPLOADED_BY = dto.UploadedBy,
                DATE_UPLOADED = dto.DateUploaded,
                DOC_EXTERNAL_URI = dto.DocumentExternalURI
            };
            _repo.InsertSaveRecord(entity);
        }
    }
}
