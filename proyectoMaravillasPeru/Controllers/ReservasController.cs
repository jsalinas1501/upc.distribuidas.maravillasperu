using proyectoMaravillasPeru.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace proyectoMaravillasPeru.Controllers
{
    public class ReservasController : Controller
    {
        // GET: Reservas
        public ActionResult Index()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                    Create("http://localhost:51123/MaravillasService.svc/Reservas");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reservas> reservasObtenidas = js.Deserialize<List<Reservas>>(tramaJson);

            ViewData["Message"] = "Listado de reservas";
            ViewBag.Titulo01 = "Codigo";
            ViewBag.Titulo02 = "Ciudad origen";
            ViewBag.Titulo03 = "Descripción ciudad origen";
            ViewBag.Titulo04 = "Ciudad destino";
            ViewBag.Titulo05 = "Descripción ciudad destino";
            ViewBag.Titulo06 = "Tipo reserva";
            ViewBag.Titulo07 = "Fecha hora inicio";
            ViewBag.Titulo08 = "Fecha hora final";
            ViewBag.Titulo09 = "Estado";

            return View(reservasObtenidas);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                    Create("http://localhost:51123/MaravillasService.svc/reservas/" + id);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Reserva reservaObtenida = js.Deserialize<Reserva>(tramaJson);

            if (reservaObtenida == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Detalle de la reserva";
            ViewBag.Titulo01 = "Codigo ";
            ViewBag.Titulo02 = "Ciudad origen";
            ViewBag.Titulo03 = "Ciudad destino";
            ViewBag.Titulo04 = "Tipo reserva";
            ViewBag.Titulo05 = "Fecha hora inicio";
            ViewBag.Titulo06 = "Fecha hora final";
            ViewBag.Titulo07 = "Estado";
            return View(reservaObtenida);
        }

        public ActionResult Edit(string id1)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                    Create("http://localhost:51123/MaravillasService.svc/reservas/" + id1);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Reserva reservaObtenida = js.Deserialize<Reserva>(tramaJson);

            if (reservaObtenida == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Editar reserva";
            return View(reservaObtenida);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigoreserva,codigociudadorigen,codigociudaddestino,tiporeserva,inicioreserva,finreserva,estado")]
                                proyectoMaravillasPeru.Dominio.Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string postdata = js.Serialize(reserva);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest request = (HttpWebRequest)WebRequest
                    .Create("http://localhost:51123/MaravillasService.svc/reservas");
                request.Method = "PUT";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";
                var requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();

                return RedirectToAction("Index");
            }
            return View(reserva);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigoreserva,codigociudadorigen,codigociudaddestino,tiporeserva,inicioreserva,finreserva,estado")]
                                    proyectoMaravillasPeru.Dominio.Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string postdata = js.Serialize(reserva);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest request = (HttpWebRequest)WebRequest
                    .Create("http://localhost:51123/MaravillasService.svc/reservas");
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";
                var requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                return RedirectToAction("Index");
            }

            return View(reserva);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["Message"] = "Detalle de la reserva a eliminar";
            ViewBag.Titulo1 = "Codigo";
            ViewBag.Titulo2 = "Codigo Origen";
            ViewBag.Titulo3 = "Codigo Destino";
            ViewBag.Titulo4 = "Tipo Reserva";
            ViewBag.Titulo5 = "Fecha hora desde";
            ViewBag.Titulo6 = "Fecha hora hasta";
            ViewBag.Titulo7 = "Estado";

            HttpWebRequest request = (HttpWebRequest)WebRequest.
                    Create("http://localhost:51123/MaravillasService.svc/reservas/" + id);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Reserva reservaObtenida = js.Deserialize<Reserva>(tramaJson);

            if (reservaObtenida == null)
            {
                return HttpNotFound();
            }
            return View(reservaObtenida);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:51123/MaravillasService.svc/reserva/" + id);
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return RedirectToAction("Index");
        }


    }
}