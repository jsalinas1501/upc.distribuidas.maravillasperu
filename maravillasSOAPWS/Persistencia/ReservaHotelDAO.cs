using maravillasSOAPWS.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace maravillasSOAPWS.Persistencia
{
    public class ReservaHotelDAO
    {
        private string CadenaConexion = "Data Source=(local); Initial Catalog=maravillas;Integrated Security=SSPI;";
        public ReservaHotel Crear(ReservaHotel reservahotelACrear)
        {
            ReservaHotel reservahotelCreada = null;
            string sql = "INSERT INTO reservahotel VALUES(@codigoreservahotel,@nombrehotel,@numerodias,@cantidadpersonas,@numerohabitaciones," +
                "@montototal,@fechaingreso)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigoreservahotel", reservahotelACrear.Codigoreservahotel));
                    comando.Parameters.Add(new SqlParameter("@nombrehotel", reservahotelACrear.Nombrehotel));
                    comando.Parameters.Add(new SqlParameter("@numerodias", reservahotelACrear.Numerodias));
                    comando.Parameters.Add(new SqlParameter("@cantidadpersonas", reservahotelACrear.Cantidadpersonas));
                    comando.Parameters.Add(new SqlParameter("@numerohabitaciones", reservahotelACrear.Numerohabitaciones));
                    comando.Parameters.Add(new SqlParameter("@montototal", reservahotelACrear.Montototal));
                    comando.Parameters.Add(new SqlParameter("@fechaingreso", reservahotelACrear.Fechaingreso));
                    comando.ExecuteNonQuery();
                }
                reservahotelCreada = Obtener(reservahotelACrear.Codigoreservahotel);
                return reservahotelCreada;
            }
        }

        public ReservaHotel Obtener(string codigo)
        {
            ReservaHotel reservaEncontrada = null;
            string sql = "SELECT * FROM reservahotel WHERE codigoreservahotel=@codigoreservahotel";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigoreservahotel", codigo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            reservaEncontrada = new ReservaHotel()
                            {
                                Codigoreservahotel = (string)resultado["codigoreservahotel"],
                                Nombrehotel = (string)resultado["nombrehotel"],
                                Numerodias = (string)resultado["numerodias"],
                                Cantidadpersonas = (string)resultado["cantidadpersonas"],
                                Numerohabitaciones = (string)resultado["numerohabitaciones"],
                                Montototal = (string)resultado["montototal"],
                                Fechaingreso = (DateTime)resultado["fechaingreso"]
                            };
                        }
                    }
                }
                return reservaEncontrada;
            }
        }

        public ReservaHotel Modificar(ReservaHotel reservaAModificar)
        {
            ReservaHotel reservaModificada = null;
            string sql = "UPDATE reservahotel SET codigoreservahotel=@codigoreservahotel,nombrehotel=@nombrehotel,numerodias=@numerodias,cantidadpersonas=@cantidadpersonas," +
                "numerohabitaciones=@numerohabitaciones,montototal=@montototal,fechaingreso=@fechaingreso";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigoreservahotel", reservaAModificar.Codigoreservahotel));
                    comando.Parameters.Add(new SqlParameter("@nombrehotel", reservaAModificar.Nombrehotel));
                    comando.Parameters.Add(new SqlParameter("@numerodias", reservaAModificar.Numerodias));
                    comando.Parameters.Add(new SqlParameter("@cantidadpersonas", reservaAModificar.Cantidadpersonas));
                    comando.Parameters.Add(new SqlParameter("@numerohabitaciones", reservaAModificar.Numerohabitaciones));
                    comando.Parameters.Add(new SqlParameter("@montototal", reservaAModificar.Montototal));
                    comando.Parameters.Add(new SqlParameter("@fechaingreso", reservaAModificar.Fechaingreso));
                }
                reservaModificada = Obtener(reservaAModificar.Codigoreservahotel);
                return reservaModificada;
            }
        }

        public void Eliminar(string codigo)
        {
            string sql = "DELETE FROM reservahotel WHERE codigoreservahotel=@codigoreservahotel";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigoreservahotel", codigo));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<ReservaHotel> Listar()
        {
            List<ReservaHotel> reservaHotelesEncontradas = new List<ReservaHotel>();
            ReservaHotel reservahotelEncontrada = null;
            string sql = "SELECT * FROM reservahotel";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            reservahotelEncontrada = new ReservaHotel()
                            {
                                Codigoreservahotel = (string)resultado["codigoreservahotel"],
                                Nombrehotel = (string)resultado["nombrehotel"],
                                Numerodias = (string)resultado["numerodias"],
                                Cantidadpersonas = (string)resultado["cantidadpersonas"],
                                Numerohabitaciones = (string)resultado["numerohabitaciones"],
                                Montototal = (string)resultado["montototal"],
                                Fechaingreso = (DateTime)resultado["fechaingreso"]
                            };
                            reservaHotelesEncontradas.Add(reservahotelEncontrada);
                        }
                    }
                }
            }
            return reservaHotelesEncontradas;
        }



    }
}