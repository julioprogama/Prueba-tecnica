using api.modelo;
using System;
using System.Collections.Generic;
using System.Data;

using Npgsql;
using NpgsqlTypes;

namespace api.UnityAPI
{
    public class Conexion
    {
        private NpgsqlConnection connection = new NpgsqlConnection();
        private string host = "postgresql-95313-0.cloudclusters.net";
        private string port = "10013";
        private string dtbs = "PruebaTecnica";
        private string user = "Admi";
        private string pass = "Julio-931120";

        /// <summary>
        /// Abre la conexion
        /// </summary>
        public Conexion()
        {
            connection.ConnectionString = "Server=" + host + ";Port=" + port + "; User Id=" + user + ";Password=" + pass + ";Database = " + dtbs;
            connection.Open();
        }

        /// <summary>
        /// Cierra la conexion
        /// </summary>
        private void CloseConexion()
        {
            connection.Close();
        }

        /// <summary>
        /// declaracion de paramentros que seran ingresados
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public NpgsqlParameter parameter(string nombre, string valor)
        {
            NpgsqlParameter param = new NpgsqlParameter();
            param.ParameterName = nombre;
            param.Value = valor;

            return param;
        }
        public NpgsqlParameter parameter(string nombre, int valor)
        {
            NpgsqlParameter param = new NpgsqlParameter();
            param.ParameterName = nombre;
            param.Value = valor;

            return param;

        }

        /// <summary>
        /// Constructor de comandos
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public NpgsqlCommand command(string consulta, List<NpgsqlParameter> parametros)
        {
            NpgsqlCommand comand = new NpgsqlCommand(consulta, connection);
            comand.CommandType = CommandType.StoredProcedure;

            foreach (NpgsqlParameter item in parametros)
            {
                comand.Parameters.Add(item);
            }


            return comand;
        }
        public NpgsqlCommand command(string consulta)
        {
            NpgsqlCommand comand = new NpgsqlCommand(consulta, connection);
            comand.CommandType = CommandType.StoredProcedure;

            return comand;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado o una funcion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Response ejecuta(NpgsqlCommand command, ref string resp)
        {
            Response rtn = new Response();
            NpgsqlTransaction t = connection.BeginTransaction();
            try
            {
                command.Parameters.Add(new NpgsqlParameter("resp", NpgsqlDbType.Varchar)).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();

                t.Commit();

                resp = (string)command.Parameters["resp"].Value;

                rtn.codigo = "A1";
                rtn.Mensaje = "Ejecucion correcta";

            }
            catch (Exception e)
            {
                Response response = new Response("-1", e.Message, "E1");
                rtn = response;

            }

            CloseConexion();

            return rtn;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado o una funcion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Response ejecuta(NpgsqlCommand command)
        {
            Response rtn = new Response();
            NpgsqlTransaction t = connection.BeginTransaction();
            try
            {
                command.ExecuteNonQuery();

                rtn.codigo = "A1";
                rtn.Mensaje = "Ejecucion correcta";
                t.Commit();

            }
            catch (Exception e)
            {
                Response response = new Response("-1", e.Message, "E1");
                rtn = response;

            }

            CloseConexion();

            return rtn;
        }

        /// <summary>
        /// Ejecuta una consulta sql
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable ejecutacData(string command)
        {
            DataTable dt = new DataTable();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command, connection);

            da.Fill(dt);

            return dt;
        }

    }
}
