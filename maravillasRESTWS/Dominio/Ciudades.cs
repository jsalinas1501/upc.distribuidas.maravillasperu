using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace maravillasRESTWS.Dominio
{
    [DataContract]
    public class Ciudades
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string codigociudad { get; set; }
        [DataMember]
        public string descripcionciudad { get; set; }
    }
}