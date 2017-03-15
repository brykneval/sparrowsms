# sparrowsms
Simple code for sparrow sms hosted on nuget.

>Nuget Project: https://www.nuget.org/packages/sparrow.sms/

>Install Nuget: Install-Package sparrow.sms


Done using EAP pattern for WebClient.
Can hook onError and onSuccess on constructor

`sparrowSms = new Sms("{from provided by Janaki}", "{token provided}", onSucess, onError);`

`sparrowSms.SendSms("{to}", "{message}");`



**onSuccess delegate encapsulates Exception**

`public static void onError(Exception ex)
{
    //Logging etc
    System.Console.WriteLine(ex.Message);
}`



**onSuccess delegate encapsulates string**

`public static void onSucess(string message)
{
    // Logging etc
    System.Console.WriteLine(message);
}`
