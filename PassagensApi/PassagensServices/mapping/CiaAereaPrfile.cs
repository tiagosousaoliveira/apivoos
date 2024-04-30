using AutoMapper;
using PassagensServices.model;

namespace PassagensServices.mapping
{
    public class CiaAereaPrfile : Profile
    {
        public CiaAereaPrfile()
        {
            CreateMap<CiaAereaApi, CiaAerea>();
        }
    }
}
