// See https://aka.ms/new-console-template for more information

using FirebaseCloudMessaging;

// This registration token comes from the client FCM SDKs.
string token = "TOKEN_HERE";


// This registration tokens comes from the client FCM SDKs.
string[] tokens = new List<string>()
{
    "TOKEN_HERE",
    "TOKEN_HERE",
    "TOKEN_HERE"
}.ToArray();


// The message the user will recieve
string title = "Test from code";
string body = "Here is your test!";

var fcm = new FirebaseNotificationHub();

//fcm.SendNotifcationToDevice(title, body, token);
//fcm.SendNotifcationToMultipleDevices(title, body, tokens);
fcm.SendNotifcationToTopic(title, body);