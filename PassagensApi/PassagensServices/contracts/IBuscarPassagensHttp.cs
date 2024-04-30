using PassagensServices.model;

namespace PassagensServices.contracts
{
    public interface IBuscarPassagensHttp
    {
        Task<IEnumerable<CiaAerea>> ObtemDadosGol();
        Task<IEnumerable<CiaAerea>> ObtemDadosLatam();
    }
}
