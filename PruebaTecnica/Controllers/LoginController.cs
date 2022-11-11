using api.modelo;
using api.UnityAPI;

using PruebaTecnicaService.Models;
using PruebaTecnicaService.Security;

using System;

using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace PruebaTecnicaService.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("ObtenerToken")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            try
            {
                if (login == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                Conexion con = new Conexion();

                var publicKey = System.Configuration.ConfigurationManager.AppSettings["publicKey"];

                bool connected = true;//con.GetSessionID(login.usuario, login.contrasena, datasource, url, 0);


                //TODO: This code is only for demo - extract method in new class & validate correctly in your application !!
                //var isUserValid = (login.Username == "user" && login.Password == "123456");
                if (connected)
                {
                    var rolename = "Developer";
                    // var token = TokenGenerator.GenerateTokenJwt(login.parametros.Usuario, rolename,
                    //   sessionID);

                    string passwordEncrypted = EncryptPassword(login.contrasena, publicKey);

                    var token = TokenGenerator.GenerateTokenJwt(login.usuario, rolename, passwordEncrypted);

                    ObtenerTokenResponse res = new ObtenerTokenResponse("S04", "Token generado correctamente", token);

                    return Ok(res);
                }

                return Unauthorized();


            }
            catch (Exception exc)
            {

                return Ok(new ObtenerTokenResponse("S03", exc.InnerException.ToString(), ""));

            }
        }

        public static string EncryptPassword(string plainText, string pubKeyPath)
        {
            //converting the public key into a string representation
            string pubKeyString;
            {
                using (StreamReader reader = new StreamReader(pubKeyPath)) { pubKeyString = reader.ReadToEnd(); }
            }
            //get a stream from the string
            var sr = new StringReader(pubKeyString);

            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));

            //get the object back from the stream
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters((RSAParameters)xs.Deserialize(sr));
            byte[] bytesPlainTextData = Encoding.Default.GetBytes(plainText);

            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCipherText = csp.Encrypt(bytesPlainTextData, false);
            //we might want a string representation of our cypher text... base64 will do
            string encryptedText = Convert.ToBase64String(bytesCipherText);
            return encryptedText;
        }
    }
}
