namespace ManageFiles.Models
{
    using System;
    using Common.Resources;
    using Common.DTO;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SearchResultsModel
    {
        #region Properties
        [Required(ErrorMessageResourceType = typeof(ValidationErrorResource),
            ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(DocumentResource), Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrorResource),
            ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(DocumentResource), Name = "ContentUUID")]
        public Guid ContentUUID { get; set; }

        [StringLength(2000, ErrorMessageResourceType = typeof(ValidationErrorResource)
           , ErrorMessageResourceName = "StringLength")]
        [Display(ResourceType = typeof(DocumentResource), Name = "DocName")]
        public string DocumentName { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ValidationErrorResource)
           , ErrorMessageResourceName = "StringLength")]
        [Display(ResourceType = typeof(DocumentResource), Name = "UploadedBy")]
        public string UploadedBy { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ValidationErrorResource)
            , ErrorMessageResourceName = "StringLength")]
        [Display(ResourceType = typeof(DocumentResource), Name = "DocExternalURI")]
        public string DocumentExternalURI { get; set; }

        public List<DocumentDTO> SearchResults { get; set; }
        #endregion

        public SearchResultsModel()
        {
            SearchResults = new List<DocumentDTO>();
        }
    }
}