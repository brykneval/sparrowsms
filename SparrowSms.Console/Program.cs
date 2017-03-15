using System;
using SparrowSms.nuget;

namespace SparrowSms.Console
{
    internal class Program
    {
        public static ISparrowSms sparrowSms;

        private static void Main(string[] args)
        {
            sparrowSms = new Sms("test", "test", onSucess, onError);
            sparrowSms.SendSms("test", "test");
        }

        // onError throws base Exception class
        public static void onError(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        // onSuccess throws string message
        public static void onSucess(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}