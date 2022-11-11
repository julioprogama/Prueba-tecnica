using api.controlador;
using api.modelo;
using api.UnityAPI;
using PruebaTecnicaService.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PruebaTecnicaService.Controllers
{
    [Authorize]
    [RoutePrefix("")]
    public class UsuarioController : ApiController
    {
        private transactionsResponse _mdconestadoresponse = new transactionsResponse();
        [HttpPost]
        [Route("cobrarServicio")]
        public IHttpActionResult cobrarServicio(Parametros parametros)
        {
            try
            {
                Utilidades utilidades = new Utilidades();

                var identity = (System.Security.Claims.ClaimsIdentity)this.RequestContext.Principal.Identity;
                
                ControladorBase Controller = new ControladorBase();
                string aceptacion = string.Empty;
                List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
                TokenCardRequest tokenCardRequest = new TokenCardRequest();
                //if ()
                //{
                if (Controller.TokenAceptacion(out aceptacion, out paymentMethods))
                    tokenCardRequest = Controller.transaccion(parametros.idServicio, parametros.idBilletera);

                    return Ok(_mdconestadoresponse);
                //}
                //else
                //{
                //    return Ok(new RespuestaAlmacenar(null, 0, "S02", "Parámetros incorrectos"));
                //}

            }
            catch (Exception exc)
            {
                return Ok(_mdconestadoresponse);
                //return Ok(new RespuestaAlmacenar("", 0, "401", exc.Message));
            }
        }



    }
}