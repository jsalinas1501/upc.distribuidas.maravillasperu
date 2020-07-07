using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoMaravillasPeru.Dominio
{
    public class Reservas
    {
        public int id { get; set; }
        public string codigoreserva { get; set; }
        public string codigociudadorigen { get; set; }
        public string descripcionciudadorigen { get; set; }
        public string codigociudaddestino { get; set; }
        public string descripcionciudaddestino { get; set; }
        public string tiporeserva { get; set; }
        public DateTime inicioreserva { get; set; }
        public DateTime finreserva { get; set; }
        public string estado { get; set; }
    }
}