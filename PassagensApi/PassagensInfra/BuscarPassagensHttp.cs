using PassagensServices.contracts;
using PassagensServices.Exceptions;
using PassagensServices.model;
using System.Net.Http.Json;

namespace PassagensServices
{
    public sealed class BuscarPassagensHttp : IBuscarPassagensHttp
    {
        private const string ApiLatam = "https://dev.reserve.com.br/airapi/latam/flights?departureCity=Rio%20de%20Janeiro&arrivalCity=Sao%20Paulo&departureDate=2024-06-20";
        private const string ApiGol = "https://dev.reserve.com.br/airapi/gol/getavailability?origin=Rio%20de%20Janeiro&destination=Sao%20Paulo&date=2024-06-20";
        public BuscarPassagensHttp()
        {
                
        }

        public async Task<IEnumerable<CiaAerea>> ObtemDadosGol()
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(ApiGol);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<CiaAerea>>();
            else
                throw new CiaAereaException("Não foi possivel buscar as Passagens");
        }

        public async Task<IEnumerable<CiaAerea>> ObtemDadosLatam()
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(ApiLatam);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<CiaAerea>>();
            else
                throw new CiaAereaException("Não foi possivel buscar as Passagens");
        }
    }
}
