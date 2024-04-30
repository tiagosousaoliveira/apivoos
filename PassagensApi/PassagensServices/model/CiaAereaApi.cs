using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassagensServices.model
{
    public class CiaAereaApi
    {
        public string FlightNumber { get; set; }
        public string Carrier { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public double FarePrice { get; set; } // Ajustado para double, mas pode ser string se necessário
    }
}
