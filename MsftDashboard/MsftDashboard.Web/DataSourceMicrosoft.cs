using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsftDashboard.Web
{
    public class DataSourceMicrosoft
    {
        public static string[] states = new string[] { "Aguascalientes", "Baja California Norte", "Baja California Sur", "Campeche", "Coahuila", "Colima", "Chiapas", "Chihuahua", "Distrito Federal", "Durango", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "Estado de México", "Michoacán", "Morelos", "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo", "San Luis Potosí", "Sinaloa", "Sonora", "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas" };

        static Random rand = new Random();

        public static List<Microsoft> Load()
        {
            int type = 0;
            List<Microsoft> list = new List<Microsoft>();
            for (int y = 2010; y <= 2012; y++)
            {
                for (int m = 1; m <= 12; m++)
                {
                    foreach (var s in states)
                    {
                        for (int p = 0; p < 3; p++)
                        {
                            for (int t = 0; t < 2; t++)
                            {
                                if (type % 2 == 0)
                                {
                                    list.Add(new Microsoft() { From = new DateTime(y, m, 1), To = new DateTime(y, m, 1), Investment = rand.Next(1000, 10000), Owner = "DPE", Program = getProgram(p), Progress = rand.Next(0, 100), ROI = rand.Next(100, 1000), Source = "Microsoft", State = s, Type = getType(t) });
                                }
                                else
                                {
                                    list.Add(new Microsoft() { From = new DateTime(y, m, 1), To = new DateTime(y, m, 1), Investment = rand.Next(1000, 10000), Owner = "DPE", Program = getProgram(p), Progress = rand.Next(0, 100), ROI = rand.Next(100, 1000), Source = "Estado", State = s, Type = getType(t) });
                                } 
                            }

                           type= rand.Next(1, 10);
                        }
                    }
                }
            }
            return list;
        }
        private static string getType(int t)
        {
            switch (t)
            {
                case 0:
                    return "Software";
                case 1:
                    return "Conference";
                default:
                    return "MOU";
            }
        }


        private static string getProgram(int p)
        {
            switch (p)
            {
                case 0:
                    return "Dreamspark";
                case 1:
                    return "Bizpark";
                case 2:
                    return "MSP";
                case 3:
                    return "MSDN Alliance";
                case 4:
                    return "Technet";
                default:
                    return "";
            }


        }
    }
}