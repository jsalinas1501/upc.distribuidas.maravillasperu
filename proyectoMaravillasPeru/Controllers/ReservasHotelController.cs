using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace proyectoMaravillasPeru.Controllers
{
    public class ReservasHotelController : Controller
    {
        private MaravillasSOAPWS.MaravillasSOAPServiceClient proxy = new MaravillasSOAPWS.MaravillasSOAPServiceClient();
        // GET: ReservasHotel
        public ActionResult Index()
        {
            MaravillasSOAPWS.ReservaHotel[] reservasHotelCreadas = proxy.ListarReservaHotel();
            ViewData["Message"] = "Listado de reserva hotel";
            ViewBag.Titulo1 = "Codigo Reserva Hotel";
            ViewBag.Titulo2 = "Nombre Hotel";
            ViewBag.Titulo3 = "Numero Dias";
            ViewBag.Titulo4 = "Cantidad Personas";
            ViewBag.Titulo5 = "Numero Habitaciones";
            ViewBag.Titulo6 = "Monto Total";
            ViewBag.Titulo7 = "Fecha Ingreso";
            return View(reservasHotelCreadas);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaravillasSOAPWS.ReservaHotel reservahotel = proxy.ObtenerReservaHotel(id);
            if (reservahotel == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Detalle de reserva hotel";
            ViewBag.Titulo1 = "Codigo Reserva Hotel";
            ViewBag.Titulo2 = "Nombre Hotel";
            ViewBag.Titulo3 = "Numero Dias";
            ViewBag.Titulo4 = "Cantidad Personas";
            ViewBag.Titulo5 = "Numero Habitaciones";
            ViewBag.Titulo6 = "Monto Total";
            ViewBag.Titulo7 = "Fecha Ingreso";
            return View(reservahotel);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaravillasSOAPWS.ReservaHotel reservahotel = proxy.ObtenerReservaHotel(id);
            if (reservahotel == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Detalle de la reserva hotel";
            ViewBag.ReservaHotel = reservahotel;
            return View(reservahotel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigoreservahotel,Nombrehotel,Numerodias,Cantidadpersonas,Numerohabitaciones,Montototal,Fechaingreso")]
                                proyectoMaravillasPeru.MaravillasSOAPWS.ReservaHotel reservahotel)
        {
            if (ModelState.IsValid)
            {
                proxy.ModificarReservaHotel(reservahotel);
                return RedirectToAction("Index");
            }
            return View(reservahotel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigoreservahotel,Nombrehotel,Numerodias,Cantidadpersonas,Numerohabitaciones,Montototal,Fechaingreso")]
                                    proyectoMaravillasPeru.MaravillasSOAPWS.ReservaHotel reservahotel)
        {
            if (ModelState.IsValid)
            {
                proxy.CrearReservaHotel(reservahotel);
                return RedirectToAction("Index");
            }

            return View(reservahotel);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["Message"] = "Detalle de reserva hotel";
            ViewBag.Titulo1 = "Codigo Reserva Hotel";
            ViewBag.Titulo2 = "Nombre Hotel";
            ViewBag.Titulo3 = "Numero Dias";
            ViewBag.Titulo4 = "Cantidad Personas";
            ViewBag.Titulo5 = "Numero Habitaciones";
            ViewBag.Titulo6 = "Monto Total";
            ViewBag.Titulo7 = "Fecha Ingreso";
            MaravillasSOAPWS.ReservaHotel reservahotel = proxy.ObtenerReservaHotel(id);
            if (reservahotel == null)
            {
                return HttpNotFound();
            }
            return View(reservahotel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            proxy.EliminarReservaHotel(id);
            return RedirectToAction("Index");
        }


    }
}