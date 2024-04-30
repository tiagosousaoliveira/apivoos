using AutoMapper;
using MediatR;
using PassagensServices.contracts;
using PassagensServices.model;

namespace PassagensServices
{
    public class ObtemPassagensQueryHandler : IRequestHandler<ObtemPassagensQuery, ObtemPassagensQuery.Response>
    {
        private readonly IBuscarPassagensHttp _buscarPassagensHttp;
        private readonly IMapper _mapper;

        public ObtemPassagensQueryHandler(IBuscarPassagensHttp buscarPassagensHttp,
            IMapper mapper)
        {
            _mapper = mapper;
            _buscarPassagensHttp = buscarPassagensHttp;
        }
        public async Task<ObtemPassagensQuery.Response> Handle(ObtemPassagensQuery request, CancellationToken cancellationToken)
        {
            var listaGol = await _buscarPassagensHttp.ObtemDadosGol();
            var listaLatam = await _buscarPassagensHttp.ObtemDadosGol();
            return new ObtemPassagensQuery.Response(ObtemListaOrdenada(
                _mapper.Map<IEnumerable<CiaAerea>>(listaGol),
                _mapper.Map<IEnumerable<CiaAerea>>(listaLatam)));
        }

        private IEnumerable<CiaAerea> ObtemListaOrdenada(IEnumerable<CiaAerea> ciaGol, IEnumerable<CiaAerea> ciaLatam)
            => ciaGol.OrderBy(x => x.Tarifa).Concat(ciaLatam.OrderBy(x => x.Tarifa));
    }

    public class ObtemPassagensQuery() : IRequest<ObtemPassagensQuery.Response>
    {
        public sealed record Response(IEnumerable<CiaAerea> cia);
    }
}
