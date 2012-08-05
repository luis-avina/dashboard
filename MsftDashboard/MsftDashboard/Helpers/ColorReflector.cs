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
using System.Reflection;

namespace MsftDashboard.Helpers
{
    public static class ColorReflector
    {
        public static Color GetThisColor(string colorString)
        {
            Type colorType = (typeof(System.Windows.Media.Colors));
            if (colorType.GetProperty(colorString) != null)
            {
                object o = colorType.InvokeMember(colorString, BindingFlags.GetProperty, null, null, null); if (o != null)
                {
                    return (Color)o;

                }

            }
            return Colors.Black;

        }
    }
}
