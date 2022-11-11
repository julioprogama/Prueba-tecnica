using api.modelo;
using api.UnityAPI;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;

namespace api.controlador
{
    /// <summary>
    /// Controlador con metodos
    /// </summary>
    public class ControladorBase
    {
        #region Propiedades
        private Conexion cnx = new Conexion();
        private Utilidades util = new Utilidades();
        private string publicKey = Properties.Settings.Default.PublicKey ;
        private string metodo = Properties.Settings.Default.endPoint;


        #endregion 

        public Boolean TokenAceptacion (out string AcceptanceToken, out List<PaymentMethod> methods)
        {
            AcceptanceToken = string.Empty;
            methods = new List<PaymentMethod>();
            
            string agreementsmetodo = metodo + "/merchants/" +publicKey;
            try
            {
                var client = new HttpClient();
                
                var result = client.GetAsync(agreementsmetodo).Result;
                var stringjson = result.Content.ReadAsStringAsync().Result;

                MerchantsData root = JsonConvert.DeserializeObject<MerchantsData>(stringjson);
                AcceptanceToken = root.Data.PresignedAcceptance.AcceptanceToken;
                methods = root.Data.PaymentMethods.ToList();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                return false;
            }

        }

        public TokenCardRequest transaccion (int idServicio, int idbilletera )
        {
            TokenCardRequest transc = new TokenCardRequest();
            DataTable dataTable = cnx.ejecutacData("select distinct nrotarjeta, cv, substring(cast(fechavencimiento as varchar), 1, 2) mes, substring(cast(fechavencimiento as varchar),4, 2) anio, u.nombrecompleto  " +
                                                    "from public.billetera b left join public.servicio s on s.idpasajero = b.idusuario " +
                                                    "left join public.usuario u on u.id  = b.idusuario " +
                                                    "where b.idusuario = "+idServicio.ToString()+"and b.idbilletera = "+idbilletera.ToString() );

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    transc.Number = util.DecryptPassword(row["nrotarjeta"].ToString() );
                    transc.CardHolder = row["nombrecompleto"].ToString();
                    transc.Cvc = Convert.ToInt32( util.DecryptPassword(row["cv"].ToString()) );
                    transc.ExpMonth = Convert.ToInt32(row["mes"].ToString() );
                    transc.ExpYear = Convert.ToInt32(row["anio"].ToString() ) ;
                }
            }

            return transc;
        }
    }
}
