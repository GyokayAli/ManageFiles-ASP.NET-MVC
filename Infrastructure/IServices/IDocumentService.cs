namespace Infrastructure.IServices
{
    using Common.DTO;
    using System.Collections.Generic;

    public interface IDocumentService
    {
        List<DocumentDTO> GetAllDocuments();

        void InsertDocument(DocumentDTO dto);
    }
}
