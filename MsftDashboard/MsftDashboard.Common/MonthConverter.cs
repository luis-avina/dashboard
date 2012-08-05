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

namespace MsftDashboard.Common
{
    public class MonthConverter
    {
        private const int ENERO = 1;
        private const int FEBRERO = 2;
        private const int MARZO = 3;
        private const int ABRIL = 4;
        private const int MAYO = 5;
        private const int JUNIO = 6;
        private const int JULIO = 7;
        private const int AGOSTO = 8;
        private const int SEPTIEMBRE = 9;
        private const int OCTUBRE = 10;
        private const int NOVIEMBRE = 11;

        public static String Convert(int month)
        {
            switch (month)
            {
                case ENERO:
                    return "Enero";
                case FEBRERO:
                    return "Febrero";
                case MARZO:
                    return "Marzo";
                case ABRIL:
                    return "Abril";
                case MAYO:
                    return "Mayo";
                case JUNIO:
                    return "Junio";
                case JULIO:
                    return "Julio";
                case AGOSTO:
                    return "Agosto";
                case SEPTIEMBRE:
                    return "Septiembre";
                case OCTUBRE:
                    return "Octubre";
                case NOVIEMBRE:
                    return "Noviembre";
                default:
                    return "Diciembre";

            }
        }
    }
}
