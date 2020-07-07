using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace maravillasRESTWS.Dominio
{
    [DataContract]
    public class Reservas
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string codigoreserva { get; set; }
        [DataMember]
        public string codigociudadorigen { get; set; }
        [DataMember]
        public string descripcionciudadorigen { get; set; }
        [DataMember]
        public string codigociudaddestino { get; set; }
        [DataMember]
        public string descripcionciudaddestino { get; set; }
        [DataMember]
        public string tiporeserva { get; set; }
        [DataMember]
        public DateTime inicioreserva { get; set; }
        [DataMember]
        public DateTime finreserva { get; set; }
        [DataMember]
        public string estado { get; set; }
    }
}