using AutoMapper;

namespace Next3.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile(new DomainToViewModelMappingProfile());
                c.AddProfile(new ViewModelToDomainMappingProfile());
            });

            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
