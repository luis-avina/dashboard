using System;

namespace MsftDashboard
{
    public class HasChangesEventArgs : EventArgs
    {
        public bool HasChanges { get; set; }
    }
}