/*
using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using testtoken;
using System.IO;
using System.Web.Mvc;
namespace MvcApplication.MediaTypesFotmatters
{
    public class JpegFormatter : BufferedMediaTypeFormatter
    {
        public JpegFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return (type == typeof(usuario));
        }

        public override void WriteToStream(Type type, object value, System.IO.Stream stream,
                                           HttpContentHeaders contentHeaders)
        {
            var persona = value as usuario;
            if (persona != null)
            {
                stream.Write(persona.Foto, 0, persona.Foto.Length);
                stream.Flush();
            }
        }
    }
}
*/