using Microsoft.AspNet.Identity;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace testtoken.Clases
{
    public class SendEmail
    {

        public bool EnviaConfirmacionRegistro()
        {

            // Create the email object first, then add the properties.
            SendGridMessage myMessage = new SendGridMessage();
            myMessage.AddTo("rodrigopq@gmail.com");
            myMessage.From = new MailAddress("soporte@syncoweb.com", "Confirmacion Registro");
            myMessage.Subject = "Testing the SendGrid Library";
            myMessage.Text = "Hello World!";

            // Create credentials, specifying your user name and password.
            var credentials = new NetworkCredential("azure_287873a4c183d9c244faddde9c6f4ccf@azure.com", "W234dfTYdER567swQS8521");

            // Create an Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email, which returns an awaitable task.
            transportWeb.DeliverAsync(myMessage);

            // If developing a Console Application, use the following
            // transportWeb.DeliverAsync(mail).Wait();
            string code = 

            return true;
        }


    }

}