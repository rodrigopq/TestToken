using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.AspNet.Identity;
using System.Threading;
using System.Security.Authentication;
using Microsoft.Owin.Security;
using testtoken.Filter;
//using System.Web.Mvc;

using System.Text;
using Newtonsoft.Json;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Web.Routing;
using testtoken.Clases;




namespace testtoken.Controllers
{
    //[Authorize]
    //[RESTAuthorize]
    public class SecureController : ApiController
    {
        [MiAutorizacion]
        public IHttpActionResult Get()
        {
        
            var authentication = HttpContext.Current.GetOwinContext().Authentication;
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

            var email = identity.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            return Ok("Welcome " + User.Identity.Name);
        
       

            //Request.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ExternalBearer);
            	
           // Request.GetOwinContext().Authentication.SignOut();

        }


        [Route("api/secure/personas")]
        [HttpGet]
        [MiAutorizacion]
        public IHttpActionResult GetPersonas()
        {
            var LstPersonas = new List<Personas>();

            LstPersonas.Add( new Personas { Id=1,Nombre="Rodrigo",FecNac=DateTime.Parse("28-09-1975")});
            LstPersonas.Add(new Personas { Id = 2, Nombre = "Magdalena", FecNac = DateTime.Parse("26-09-1975") });
 
            //Request.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ExternalBearer);

            // Request.GetOwinContext().Authentication.SignOut();

            return Ok(LstPersonas);
        }


        [HttpPost]
       // [RESTAuthorize]
        [MiAutorizacion]
        public IHttpActionResult Logout()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var IdUsuario =int.Parse(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
            var authentication = HttpContext.Current.GetOwinContext().Authentication;

            authentication.SignOut(DefaultAuthenticationTypes.ExternalBearer);


            using (Context db = new Context())
            {
                var user = db.usuario.FirstOrDefault(u => u.IdUsuario == IdUsuario);
                user.Logueado = false;

                db.Configuration.ValidateOnSaveEnabled = false;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
            }

            return Ok("Bye " + User.Identity.Name);

        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }
    }
}