using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace maravillasSOAPWS.Dominio
{
    [DataContract]
    public class ReservaHotel
    {
        [DataMember]
        public string Codigoreservahotel { get; set; }
        [DataMember]
        public string Nombrehotel { get; set; }
        [DataMember]
        public string Numerodias { get; set; }
        [DataMember]
        public string Cantidadpersonas { get; set; }
        [DataMember]
        public string Numerohabitaciones { get; set; }
        [DataMember]
        public string Montototal { get; set; }
        [DataMember]
        public DateTime Fechaingreso { get; set; }
    }
}