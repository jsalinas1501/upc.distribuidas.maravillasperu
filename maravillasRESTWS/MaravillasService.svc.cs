using maravillasRESTWS.Dominio;
using maravillasRESTWS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace maravillasRESTWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MaravillasService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MaravillasService.svc o MaravillasService.svc.cs en el Explorador de soluciones e inicie la depuración.
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MaravillasService : IMaravillasService
    {
        private maravillasEntities1 db = new maravillasEntities1();

        public reserva CrearReserva(reserva reservaACrear)
        {
            db.reservas.Add(reservaACrear);
            db.SaveChanges();
            reserva reserva = ObtenerReserva(reservaACrear.codigoreserva);
            return reserva;
        }

        public void EliminarReserva(string codigoreserva)
        {
            reserva reserva = ObtenerReserva(codigoreserva);
            db.reservas.Remove(reserva);
            db.SaveChanges();
        }

        public List<ciudad> ListarCiudades()
        {
            return db.ciudads.ToList();
        }

        public List<Reservas> ListarReservas()
        {
            var query = from a in db.reservas
                        join b in db.ciudads on a.codigociudadorigen equals b.codigociudad
                        join c in db.ciudads on a.codigociudaddestino equals c.codigociudad
                        select new Reservas
                        {
                            id = a.id,
                            codigoreserva = a.codigoreserva,
                            codigociudadorigen = a.codigociudadorigen,
                            descripcionciudadorigen = b.descripcionciudad,
                            codigociudaddestino = a.codigociudaddestino,
                            descripcionciudaddestino = c.descripcionciudad,
                            tiporeserva = a.tiporeserva,
                            inicioreserva = a.inicioreserva,
                            finreserva = a.finreserva,
                            estado = a.estado
                        };
            return query.ToList();
        }

        public reserva ModificarReserva(reserva reservaAModificar)
        {
            db.Entry(reservaAModificar).State = EntityState.Modified;
            db.SaveChanges();
            reserva reserva = ObtenerReserva(reservaAModificar.codigoreserva);
            return reserva;
        }

        public reserva ObtenerReserva(string codigoreserva)
        {
            var query = from reserva in db.reservas.Where(x => (x.codigoreserva == codigoreserva))
                        select reserva;
            reserva resultado = query.FirstOrDefault();
            return resultado;
        }
    }
}
