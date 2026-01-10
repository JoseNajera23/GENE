using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contacto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //recuperacion de los datos mandados en el formulario
        string from = Request.Form["contact_email"].ToString();
        string nombre = Request.Form["contact_name"].ToString();
        string personas = Request.Form["contact_personas"].ToString();
        string extra = Request.Form["contact_adicionales"].ToString();
        string fecha = Request.Form["contact_fecha"].ToString();
        string hora = Request.Form["contact_hora"].ToString();
        string subject = nombre + " Fecha: " + fecha + ". Hora: " + hora + ". Personas: " + (int.Parse(personas) + int.Parse(extra)).ToString();
        string mensaje = "El cliente " + nombre + "ha realizado una reservacion para el dia: " + " Fecha: " + fecha + " a las: " + hora + " hrs para " +
"Personas: " + (int.Parse(personas) + int.Parse(extra)).ToString();
        string resultado = sendGmail(from, subject, mensaje);
     
        //redireccionar a http:localhost:789/Default.aspx?Id=2
        Response.Redirect("/Default.aspx?Id=2");

    }

    private string sendGmail(string from, string subject, string mensaje)
    {
        SmtpClient client = new SmtpClient();
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true; //Socket Secure Layer  https
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        //Nos autenticamos en el SMTP
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("", "");
        client.UseDefaultCredentials = false;
        client.Credentials = credentials;
        //Creamos nuestro correo
        MailMessage oMail = new MailMessage();
        oMail.From = new MailAddress(from);
        oMail.To.Add(new MailAddress("javier_timal@hotmail.com"));
        oMail.CC.Add(new MailAddress(from));
        oMail.Subject = subject;
        oMail.IsBodyHtml = true;
        oMail.Priority = MailPriority.Low;
        oMail.Body = "<h1 style='color:red'>Reservacion</h1><br>" + mensaje;
        try
        {
            client.Send(oMail);
            return "Correo enviado";
        }
        catch (Exception ex)
        {
            return "Error en el envio. " + ex.Message;
        }
    } // fin de sendGmail


}