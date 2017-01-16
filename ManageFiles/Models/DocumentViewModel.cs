namespace ManageFiles.Models
{
    using System;
    using Common.Resources;
    using System.ComponentModel.DataAnnotations;

    public class DocumentViewModel
    {
        #region Properties
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrorResource),
            ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(DocumentResource), Name = "ContentUUID")]
        public Guid ContentUUID { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrorResource),
           ErrorMessageResourceName = "Required")]
        [StringLength(2000, ErrorMessageResourceType = typeof(ValidationErrorResource)
            , ErrorMessageResourceName = "StringLength")]
        [Display(ResourceType = typeof(DocumentResource), Name = "DocName")]
        public string DocumentName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrorResource),
           ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(ValidationErrorResource)
            , ErrorMessageResourceName = "StringLength")]
        [Display(ResourceType = typeof(DocumentResource), Name = "UploadedBy")]
        public string UploadedBy { get; set; }

        public DateTime DateUploaded { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ValidationErrorResource)
            , ErrorMessageResourceName = "StringLength")]
        [Display(ResourceType = typeof(DocumentResource), Name = "DocExternalURI")]
        public string DocumentExternalURI { get; set; }
        #endregion
    }
}