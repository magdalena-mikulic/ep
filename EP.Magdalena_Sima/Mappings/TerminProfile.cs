using AutoMapper;
using EP.Magdalena_Sima.Models;
using EP.Magdalena_Sima.Models.Termin;

namespace EP.Magdalena_Sima.Mappings
{
    public class TerminProfile : Profile
    {
        public TerminProfile()
        {
            CreateMap<TerminFields, TerminRequest>().ReverseMap();

            CreateMap<TerminFields, ExtendedModel>().ReverseMap();
        }
    }
}