using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MsftDashboard.Helpers
{
    public class HyperLinkButtonWrapper: HyperlinkButton
    {
        public void OpenURL(string navigateUri)
        {
            OpenURL(new Uri(navigateUri, UriKind.Absolute));
        }

        public void OpenURL(Uri navigateUri)
        {
            base.NavigateUri = navigateUri;
            base.TargetName = "ContentFrame";
            base.OnClick();
        }
    }
}
