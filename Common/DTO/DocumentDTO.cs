namespace Common.DTO
{
    using System;
    
    public class DocumentDTO
    {
        public int Id { get; set; }
        public Guid ContentUUID { get; set; }
        public string DocumentName { get; set; }
        public string UploadedBy { get; set; }
        public DateTime DateUploaded { get; set; }
        public string DocumentExternalURI { get; set; }
    }
}
