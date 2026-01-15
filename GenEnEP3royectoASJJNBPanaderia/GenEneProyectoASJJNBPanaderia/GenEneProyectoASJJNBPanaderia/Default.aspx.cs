using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;

//Definimos el Comportamiento
public partial class _Default : System.Web.UI.Page
{
    public String TipoMenu = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            TipoMenu = "0";
        }
        else
        {
            TipoMenu = Request.QueryString["id"];
        }
        TransformaXML();
    }
    private void TransformaXML()
    {
        string xmlPath = ConfigurationManager.AppSettings["FileServer"].ToString() + "xml/menu.xml";
        string xsltPath = ConfigurationManager.AppSettings["FileServer"].ToString() + "xslt/template.xslt";
        XmlTextReader trMenu = new XmlTextReader(xmlPath);
        //credenciales
        XmlUrlResolver resolver = new XmlUrlResolver();
        resolver.Credentials = CredentialCache.DefaultCredentials;
        //Crear la configuración para poder acceder al XSLT
        // los parámetros true son para poder tratar al xslt
        //como documento y poder transformarlo
        XsltSettings settings = new XsltSettings(true, true);
        //Leer XSLT
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(xsltPath, settings, resolver);
        // creamos a donde enviar la transformacion
        StringBuilder sBuilder = new StringBuilder();
        TextWriter tWriter = new StringWriter(sBuilder);
        XsltArgumentList xslArgs = new XsltArgumentList();
        xslArgs.AddParam("TipoMenu", "", TipoMenu);
        xslt.Transform(trMenu, xslArgs, tWriter);
        string resultado = sBuilder.ToString();
        Response.Write(resultado);
    }
}