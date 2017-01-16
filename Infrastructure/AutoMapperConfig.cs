namespace Infrastructure
{
    using AutoMapper;
    using Common.DTO;
    using DataAccess;

    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(
            cfg =>
            {
                cfg.CreateMap<DOCUMENTS, DocumentDTO>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.ID))
               .ForMember(dest => dest.ContentUUID, opts => opts.MapFrom(src => src.CONTENT_UUID))
               .ForMember(dest => dest.DocumentName, opts => opts.MapFrom(src => src.DOC_NAME))
               .ForMember(dest => dest.UploadedBy, opts => opts.MapFrom(src => src.UPLOADED_BY))
               .ForMember(dest => dest.DateUploaded, opts => opts.MapFrom(src => src.DATE_UPLOADED))
               .ForMember(dest => dest.DocumentExternalURI, opts => opts.MapFrom(src => src.DOC_EXTERNAL_URI))
               .ReverseMap();
            }
           );
        }
    }
}
