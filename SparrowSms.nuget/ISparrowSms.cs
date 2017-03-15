namespace SparrowSms.nuget
{
    public interface ISparrowSms
    {
        void SendSms(string to, string message);
    }
}