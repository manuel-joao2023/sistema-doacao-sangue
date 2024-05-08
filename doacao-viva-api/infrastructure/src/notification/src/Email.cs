using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;

namespace DoacaoViva.Infrastructure.Notification;
public class Email {

    public static string SendEmail(string mensageBody,string fromEmail) {
        // Autenticação e autorização
        UserCredential credential;
        string credPath = "token.json";
        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.FromFile("credentials.json").Secrets,
            new[] { GmailService.Scope.GmailSend },
            "user",
            CancellationToken.None,
            new FileDataStore(credPath, true)).Result;
        

        // Criar o serviço Gmail
        var service = new GmailService(new BaseClientService.Initializer() {
            HttpClientInitializer = credential,
            ApplicationName = "Gmail API Example"
        });

        // Construir a mensagem
        var msg = new MimeMessage();
        msg.From.Add(new MailboxAddress("SalveVidaDoando", "seu_email@gmail.com"));
        msg.To.Add(new MailboxAddress("Destinatário", fromEmail));
        msg.Subject = "Solicitação de Sangue";
        msg.Body = new TextPart("plain") {
            Text = mensageBody
        };

        // Converter a mensagem para um formato adequado
        byte[] emailBytes;
        using var memory = new MemoryStream();
        msg.WriteTo(memory);
        emailBytes = memory.ToArray();
        
        string emailBase64 = Convert.ToBase64String(emailBytes);
        var email = new Message { Raw = emailBase64 };

        // Enviar o e-mail
        var result = service.Users.Messages.Send(email, "me").Execute();
        Console.WriteLine("E-mail enviado com sucesso. ID da mensagem: " + result.Id);

        return string.Empty;

    }
}

