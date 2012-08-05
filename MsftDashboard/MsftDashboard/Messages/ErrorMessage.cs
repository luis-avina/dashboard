using GalaSoft.MvvmLight.Messaging;

namespace MsftDashboard
{
    internal class ErrorMessage : MessageBase
    {
        public Error Error { get; set; }
    }
}