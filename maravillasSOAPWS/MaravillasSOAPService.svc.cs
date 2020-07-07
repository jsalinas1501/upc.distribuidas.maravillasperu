using maravillasSOAPWS.Dominio;
using maravillasSOAPWS.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace maravillasSOAPWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MaravillasSOAPService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MaravillasSOAPService.svc o MaravillasSOAPService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MaravillasSOAPService : IMaravillasSOAPService
    {
        private ReservaHotelDAO reservaHotelDAO = new ReservaHotelDAO();
        public ReservaHotel CrearReservaHotel(ReservaHotel reservaHotelACrear)
        {
            return reservaHotelDAO.Crear(reservaHotelACrear);
        }

        public void EliminarReservaHotel(string codigo)
        {
            reservaHotelDAO.Eliminar(codigo);
        }

        public List<ReservaHotel> ListarReservaHotel()
        {
            return reservaHotelDAO.Listar();
        }

        public ReservaHotel ModificarReservaHotel(ReservaHotel reservaHotelAModificar)
        {
            return reservaHotelDAO.Modificar(reservaHotelAModificar);
        }

        public ReservaHotel ObtenerReservaHotel(string codigo)
        {
            return reservaHotelDAO.Obtener(codigo);
        }
    }
}
