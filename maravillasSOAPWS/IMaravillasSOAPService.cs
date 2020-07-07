using maravillasSOAPWS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace maravillasSOAPWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMaravillasSOAPService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMaravillasSOAPService
    {
        [OperationContract]
        ReservaHotel CrearReservaHotel(ReservaHotel reservaHotelACrear);

        [OperationContract]
        ReservaHotel ObtenerReservaHotel(string codigo);

        [OperationContract]
        ReservaHotel ModificarReservaHotel(ReservaHotel reservaHotelAModificar);

        [OperationContract]
        void EliminarReservaHotel(string codigo);

        [OperationContract]
        List<ReservaHotel> ListarReservaHotel();

    }
}
