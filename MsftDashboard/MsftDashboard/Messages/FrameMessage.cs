using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace MsftDashboard
{
    internal class FrameMessage : MessageBase
    {
        public Frame RootFrame { get; set; }
    }
}