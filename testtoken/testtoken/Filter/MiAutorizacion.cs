using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
//using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNet.Identity;
using testtoken.Clases;


namespace testtoken.Filter
{
    public class MiAutorizacion : AuthorizeAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (AuthorizeRequest(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }

        private bool AuthorizeRequest(HttpActionContext actionContext)
        {
            bool Estado = false;
            HttpClient client = HttpClientFactory.Create(new ApiLogHandler());

            //Write your code here to perform authorization
            var authentication = HttpContext.Current.GetOwinContext().Authentication;
            if (authentication.User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var IdUsuario = int.Parse(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());

                using (Context db = new Context())
                {
                    var user = db.usuario.FirstOrDefault(u => u.IdUsuario == IdUsuario);
                    if (user.Logueado==true)
                        Estado = true;
                    else
                        Estado = false;
               }
            }
            else
            {
                Estado = false;
            }
            return Estado;
        }

        /*
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //Code to handle unauthorized request
            var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
           // challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
          //  throw new HttpResponseException(challengeMessage);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
        }*/

    }


}