using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;
namespace AppEnvio
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Sessao();
            }
            else
            {
                LoadApresentacao();
            }
        }

        public void Sessao()
        {
            if (!string.IsNullOrEmpty((string)Session["StatusMessage"]))
            {
                if (Session["StatusMessage"].ToString().Equals("success"))
                {
                    Alert("success");
                    Session["StatusMessage"] = null;
                    LoadApresentacao();
                }
                else
                {
                    Alert("Erro");
                    Session["StatusMessage"] = null;
                    Response.Redirect("Default.aspx");

                }
            }
            }

        public void LoadApresentacao()
        {
            if (!string.IsNullOrWhiteSpace(WebConfigurationManager.AppSettings["carregatextocorpo"]))
            {
                using (var stream = new StreamReader(Server.MapPath("Arquivo/" + WebConfigurationManager.AppSettings["carregatextocorpo"]),
                    Encoding.GetEncoding(WebConfigurationManager.AppSettings["encoding"])))
                {
                    corpoEmail.InnerText = stream.ReadToEnd();
                }
            }
        }

        public void Enviar(object obj, EventArgs e)
         {
            var email = Request["emailDestinatario"];

            var assunto = Request["assuntoDestinatario"];

            var remetente = WebConfigurationManager.AppSettings["remetente"];

            var senha = WebConfigurationManager.AppSettings["senha"];

            var corpo = Request["corpoEmail"] + "\r\nAtenciosamente\r\n" + WebConfigurationManager.AppSettings["assinatura.nome"] +" \r\n" +WebConfigurationManager.AppSettings["assinatura.telefone"];

            var stream = new MemoryStream();
            var mensagem = new MailMessage {From = new MailAddress(remetente)};

            mensagem.To.Add(email);
            mensagem.Subject = assunto;
            mensagem.Body = corpo;
            mensagem.Attachments.Add(new Attachment(stream, "Arquivo/" + WebConfigurationManager.AppSettings["anexo"] ));
            mensagem.Priority = MailPriority.High;
            mensagem.BodyEncoding = Encoding.GetEncoding(WebConfigurationManager.AppSettings["encoding"]);

            var smtp = new SmtpClient(WebConfigurationManager.AppSettings["clientsmtp"])
            {
                EnableSsl = Convert.ToBoolean( WebConfigurationManager.AppSettings["ssl"] ),
                Port = Convert.ToInt32( WebConfigurationManager.AppSettings["port"]),
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(remetente,senha),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            try
            {
                smtp.Send(mensagem);
                Session["StatusMessage"] = "success";
                Sessao();

            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }

        }

        public void Alert(string msg)
        {
            if (msg.Equals("success"))
            {
                DivAlert.Attributes.Add("class", "alert alert-success alert-dismissable");
                DivAlert.Visible = true;
                alertText.InnerHtml = "E-mail Enviado com sucesso";
            }
            else
            {
                DivAlert.Attributes.Add("class", "alert alert-danger alert-dismissable");
                DivAlert.Visible = true;
                alertText.InnerHtml = msg;
            }

            emailDestinatario.Value = "";
            assuntoDestinatario.Value = "";
        }
    }
}