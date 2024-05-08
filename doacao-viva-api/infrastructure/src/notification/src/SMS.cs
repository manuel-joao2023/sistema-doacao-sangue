using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DoacaoViva.Infrastructure.Notification;
public class SMS {

    static readonly string? AccountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
    static readonly string? AuthToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
    static readonly string? PhoneNumberFrom = Environment.GetEnvironmentVariable("PHONE_NUMBER_FROM");

    public static string SendMessage(string bodyMessage, string phone) {

        TwilioClient.Init(AccountSid, AuthToken);

        var message = MessageResource.Create(
            body: bodyMessage,
            from: new Twilio.Types.PhoneNumber(PhoneNumberFrom),
            to: new Twilio.Types.PhoneNumber(phone)
        );

        return message.Status.ToString();
    }
}
