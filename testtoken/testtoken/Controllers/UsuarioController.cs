using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testtoken.Filter;
using System.Data.Entity;
using testtoken.Clases;
namespace testtoken.Controllers
{
    public class UsuarioController : ApiController
    {
       /*
        private readonly List<usuario> _usuario = Persona.Todos();

        public List<usuario> Get()
        {
            return _usuario;
        }
        */
        public HttpResponseMessage Get(int id)
        {
            Context db = new Context();
            var usuario = db.usuario.FirstOrDefault(x => x.IdUsuario == id);
            if (usuario == null)
            {
                var mensaje404 = new HttpResponseMessage(HttpStatusCode.NotFound);
                return mensaje404;
            }

            var personaMensaje = Request.CreateResponse(HttpStatusCode.OK, usuario);
            return personaMensaje;
        }


        [Route("api/usuario/foto/{Id}")]
        [HttpGet]
        [MiAutorizacion]
        public HttpResponseMessage GetFoto(int Id)
        {
           // int Id = 1;
            Context db = new Context();
            var usuario = db.usuario.FirstOrDefault(x => x.IdUsuario == Id);
            var img = usuario.Foto;
            byte[] imgData = img;
            MemoryStream ms = new MemoryStream(imgData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
            return response;

        }

        [Route("api/usuario/EjecutaSP")]
        [HttpGet]
        public HttpResponseMessage EjecutaSP()
        {

            var email = new SendEmail();
            email.EnviaConfirmacionRegistro();


            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
     
        }

    }
}
