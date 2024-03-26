using FirebaseAdmin.Messaging;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace FirebaseCloudMessaging;
public class FirebaseNotificationHub
{
    public FirebaseNotificationHub()
    {
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromJson(Private.DecodeKey())
        });
    }

    public void SendNotifcationToTopic(string title, string body, string topic = "all")
    {        

        var message = new Message()
        {
            Topic = topic,
            Notification = new Notification()
            {
                Title = title,
                Body = body,
            }
        };

        string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;

        // Response is a message ID string.
        Console.WriteLine("Successfully sent message: " + response);
    }

    public void SendNotifcationToDevice(string title, string body, string token)
    {

        var message = new Message()
        {
            Token = token,
            Notification = new Notification()
            {
                Title = title,
                Body = body
            }
        };

        string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;

        // Response is a message ID string.
        Console.WriteLine("Successfully sent message: " + response);
    }

    public void SendNotifcationToMultipleDevices(string title, string body, string[] tokens)
    {
        var message = new MulticastMessage()
        {
            Tokens = tokens,
            Notification = new Notification()
            {
                Title = title,
                Body = body
            }
        };

        BatchResponse response = FirebaseMessaging.DefaultInstance.SendMulticastAsync(message).Result;

        // Response is a message ID string.
        Console.WriteLine("Successfully sent message: " + response);
    }
}
