using maravillasRESTWS.Dominio;
using maravillasRESTWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace maravillasRESTWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMaravillasService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMaravillasService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate ="reservas", ResponseFormat = WebMessageFormat.Json)]
        reserva CrearReserva(reserva reservaACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "reservas/{codigoreserva}", ResponseFormat = WebMessageFormat.Json)]
        reserva ObtenerReserva(string codigoreserva);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "reservas", ResponseFormat = WebMessageFormat.Json)]
        reserva ModificarReserva(reserva reservaAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "reserva/{codigoreserva}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarReserva(string codigoreserva);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Reservas", ResponseFormat = WebMessageFormat.Json)]
        List<Reservas> ListarReservas();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ciudades", ResponseFormat = WebMessageFormat.Json)]
        List<ciudad> ListarCiudades();
    }
}
