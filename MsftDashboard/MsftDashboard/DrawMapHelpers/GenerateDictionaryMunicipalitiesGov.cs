using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsftDashboard.DrawMapHelpers
{
    public static class GenerateDictionaryMunicipalitiesGov
    {

        public static Dictionary<int, List<MunicipalityGoverment>> getDictionaryMunicipalitiesGov()
        {
            Dictionary<int, List<MunicipalityGoverment>> dictionarie = new Dictionary<int, List<MunicipalityGoverment>>();

            List<MunicipalityGoverment> bajacalifornianorte = new List<MunicipalityGoverment>()
            {
                 new MunicipalityGoverment(){Estado="Baja California Norte",Nombre="Tijuana",Partido="PAN",ColorPartido="#FF169DF3"},
                 new MunicipalityGoverment(){Estado="Baja California Norte",Nombre="Mexicali",Partido="PRI",ColorPartido="#FFF31616"},
                 new MunicipalityGoverment(){Estado="Baja California Norte",Nombre="Tecate",Partido="PAN",ColorPartido="#FF169DF3"}

            };

            List<MunicipalityGoverment> jalisco = new List<MunicipalityGoverment>()
            {
                 new MunicipalityGoverment(){Estado="Jalisco",Nombre="Guadalajara",Partido="PAN",ColorPartido="#FF169DF3"},
                 new MunicipalityGoverment(){Estado="Jalisco",Nombre="Puerto Vallarta",Partido="PRD",ColorPartido="#FFF2FF13"},
                 new MunicipalityGoverment(){Estado="Jalisco",Nombre="Zapopan",Partido="PAN",ColorPartido="#FF169DF3"}

            };

            List<MunicipalityGoverment> sinaloa = new List<MunicipalityGoverment>()
            {
                 new MunicipalityGoverment(){Estado="Sinaloa",Nombre="Culiacan",Partido="PRI",ColorPartido="#FFF31616"},
                 new MunicipalityGoverment(){Estado="Sinaloa",Nombre="Mazatlán",Partido="PAN",ColorPartido="#FF169DF3"},
                 new MunicipalityGoverment(){Estado="Sinaloa",Nombre="Los Mochis",Partido="PAN",ColorPartido="#FFF31616"}

            };


            dictionarie.Add(1, new List<MunicipalityGoverment>());

            dictionarie.Add(2, bajacalifornianorte);

            dictionarie.Add(3, new List<MunicipalityGoverment>());
            dictionarie.Add(4, new List<MunicipalityGoverment>());
            dictionarie.Add(5, new List<MunicipalityGoverment>());
            dictionarie.Add(6, new List<MunicipalityGoverment>());
            dictionarie.Add(7, new List<MunicipalityGoverment>());
            dictionarie.Add(8, new List<MunicipalityGoverment>());
            dictionarie.Add(9, new List<MunicipalityGoverment>());
            dictionarie.Add(10,new List<MunicipalityGoverment>());
            dictionarie.Add(11, new List<MunicipalityGoverment>());
            dictionarie.Add(12, new List<MunicipalityGoverment>());
            dictionarie.Add(13, new List<MunicipalityGoverment>());
            dictionarie.Add(14, new List<MunicipalityGoverment>());

            dictionarie.Add(15, jalisco);

            dictionarie.Add(16, new List<MunicipalityGoverment>());
            dictionarie.Add(17, new List<MunicipalityGoverment>());
            dictionarie.Add(18, new List<MunicipalityGoverment>());
            dictionarie.Add(19, new List<MunicipalityGoverment>());
            dictionarie.Add(20, new List<MunicipalityGoverment>());
            dictionarie.Add(21, new List<MunicipalityGoverment>());
            dictionarie.Add(22, new List<MunicipalityGoverment>());
            dictionarie.Add(23, new List<MunicipalityGoverment>());
            dictionarie.Add(24, new List<MunicipalityGoverment>());

            dictionarie.Add(25, sinaloa);


            dictionarie.Add(26, new List<MunicipalityGoverment>());
            dictionarie.Add(27, new List<MunicipalityGoverment>());
            dictionarie.Add(28, new List<MunicipalityGoverment>());
            dictionarie.Add(29, new List<MunicipalityGoverment>());
            dictionarie.Add(30, new List<MunicipalityGoverment>());
            dictionarie.Add(31, new List<MunicipalityGoverment>());
            dictionarie.Add(32, new List<MunicipalityGoverment>());

            
            
            
            

            return dictionarie;
        }

        public static Dictionary<int, List<ElevemosMexico>> getDictionaryElevemos()
        {
            Dictionary<int, List<ElevemosMexico>> dictionarie = new Dictionary<int, List<ElevemosMexico>>();
            
            List<ElevemosMexico> chiapas = new List<ElevemosMexico>()
            {
                
                new ElevemosMexico(){ Estado="Chiapas",Convenio="Gobierno del Estado",Tipo="Marco",Inversion=1000000},
                new ElevemosMexico(){ Estado="Chiapas",Convenio="Secretaria de Educación",Tipo="Especifico", Inversion=200000},

            };

            List<ElevemosMexico> mexico = new List<ElevemosMexico>()
            {
                
                new ElevemosMexico(){ Estado="Estado de México",Convenio="Gobierno del Estado",Tipo="Marco",Inversion=9000000},
                new ElevemosMexico(){ Estado="Estado de México",Convenio="Conalep Estado de México",Tipo="Especifico", Inversion=300000},

            };
            List<ElevemosMexico> sonora = new List<ElevemosMexico>()
            {
                
                new ElevemosMexico(){ Estado="Sonora",Convenio="Gobierno del Estado",Tipo="Marco",Inversion=1040000},
                new ElevemosMexico(){ Estado="Sonora",Convenio="Secretarias de Economía",Tipo="Especifico", Inversion=229000},

            };


            dictionarie.Add(1, new List<ElevemosMexico>());
            dictionarie.Add(2, new List<ElevemosMexico>());
            dictionarie.Add(3, new List<ElevemosMexico>());
            dictionarie.Add(4, new List<ElevemosMexico>());
            dictionarie.Add(6, new List<ElevemosMexico>());
            dictionarie.Add(7, new List<ElevemosMexico>());
            dictionarie.Add(8, new List<ElevemosMexico>());
            dictionarie.Add(9, new List<ElevemosMexico>());
            dictionarie.Add(10, new List<ElevemosMexico>());
            dictionarie.Add(12, new List<ElevemosMexico>());
            dictionarie.Add(13, new List<ElevemosMexico>());
            dictionarie.Add(14, new List<ElevemosMexico>());
            dictionarie.Add(15, new List<ElevemosMexico>());
            dictionarie.Add(16, new List<ElevemosMexico>());
            dictionarie.Add(17, new List<ElevemosMexico>());
            dictionarie.Add(18, new List<ElevemosMexico>());
            dictionarie.Add(19, new List<ElevemosMexico>());
            dictionarie.Add(20, new List<ElevemosMexico>());
            dictionarie.Add(21, new List<ElevemosMexico>());
            dictionarie.Add(22, new List<ElevemosMexico>());
            dictionarie.Add(23, new List<ElevemosMexico>());
            dictionarie.Add(24, new List<ElevemosMexico>());
            dictionarie.Add(25, new List<ElevemosMexico>());
            dictionarie.Add(27, new List<ElevemosMexico>());
            dictionarie.Add(28, new List<ElevemosMexico>());
            dictionarie.Add(29, new List<ElevemosMexico>());
            dictionarie.Add(30, new List<ElevemosMexico>());
            dictionarie.Add(31, new List<ElevemosMexico>());
            dictionarie.Add(32, new List<ElevemosMexico>());

            dictionarie.Add(5, chiapas);
            dictionarie.Add(11, mexico);
            dictionarie.Add(26, sonora);

            return dictionarie;
        }

        public static Dictionary<int,List<InversionMsft>> getDictionaryInversion()
        {
            //private List<int> investment1 = new List<int>() { 3, 10 };
            //private List<int> investment2 = new List<int>() { 21, 30 };
            //private List<int> investment3 = new List<int>() { 23, 15 };
            //private List<int> investment4 = new List<int>() {28, 5 };
            //private List<int> investment5 = new List<int>() { 2, 20 ,14};

            Dictionary<int,List<InversionMsft>> dictionarie = new Dictionary<int,List<InversionMsft>>();

            dictionarie.Add(1, new List<InversionMsft>());

            List<InversionMsft> bajaNorte = new List<InversionMsft>() 
            { 
                
                new InversionMsft(){Programa="BI",Estado="Baja California Norte",Area="Area 2",Inversion=48112.00,Roi=2121}
            };

            dictionarie.Add(2, bajaNorte);
            dictionarie.Add(3, new List<InversionMsft>());
             
            List<InversionMsft> campeche = new List<InversionMsft>()
            { 
                new InversionMsft(){Programa="MiPyME",Estado="Campeche",Area="Area 1",Inversion=172711.00,Roi=2121}
            };
            
            dictionarie.Add(4, campeche);

            List<InversionMsft> chihuahua = new List<InversionMsft>()
            { 
                new InversionMsft(){Programa="Azure",Estado="Chihuahua",Area="Area 2",Inversion=59528.00,Roi=2121}
            };

            dictionarie.Add(5, new List<InversionMsft>());
            dictionarie.Add(6, chihuahua);
            dictionarie.Add(7, new List<InversionMsft>());
            dictionarie.Add(8, new List<InversionMsft>());
            dictionarie.Add(9, new List<InversionMsft>());
            List<InversionMsft> mexico = new List<InversionMsft>()
            { 
                new InversionMsft(){Programa="MiPyME creSE",Estado="Estado de México",Area="Area 1",Inversion=12112.20,Roi=2121}
            };

            dictionarie.Add(10, new List<InversionMsft>());
            dictionarie.Add(11, mexico);
            dictionarie.Add(12, new List<InversionMsft>());
            dictionarie.Add(13, new List<InversionMsft>());
             List<InversionMsft> michoacan = new List<InversionMsft>(){ 
                new InversionMsft(){Programa="DreamSpark",Estado="Michoacan",Area="Area 1",Inversion=858412.20,Roi=2121}
                
            };

             List<InversionMsft> jalisco = new List<InversionMsft>(){ 
                new InversionMsft(){Programa="BI",Estado="Jalisco",Area="Area 2",Inversion=12112.20,Roi=2121}
            };
             dictionarie.Add(14, new List<InversionMsft>());
             dictionarie.Add(15, jalisco);

            dictionarie.Add(16, michoacan);
            dictionarie.Add(17, new List<InversionMsft>());
            dictionarie.Add(18, new List<InversionMsft>());
            dictionarie.Add(19, new List<InversionMsft>());
            dictionarie.Add(20, new List<InversionMsft>());

            List<InversionMsft> puebla = new List<InversionMsft>()
            { 
                new InversionMsft(){Programa="BI",Estado="Puebla",Area="Area 2",Inversion=59528.00,Roi=2121}
            };


            dictionarie.Add(21, puebla);

            List<InversionMsft> queretaro = new List<InversionMsft>()
            { 
                new InversionMsft(){Programa="BizPark",Estado="Queretaro",Area="Area 1",Inversion=48112.00,Roi=2121},
                
            };
            dictionarie.Add(22, queretaro);

            
            List<InversionMsft> sanluis = new List<InversionMsft>()
            { 
                new InversionMsft(){Programa="DreamSpark",Estado="San Luis Potosi",Area="Area 1",Inversion=212181.00,Roi=2121}
            };

            dictionarie.Add(23, new List<InversionMsft>());
            dictionarie.Add(24, sanluis);
            dictionarie.Add(25, new List<InversionMsft>());
            dictionarie.Add(26, new List<InversionMsft>());
            dictionarie.Add(27, new List<InversionMsft>());
            dictionarie.Add(28, new List<InversionMsft>());

            List<InversionMsft> tlaxcala = new List<InversionMsft>()
            { 
                new InversionMsft(){Programa="Azure",Estado="Tlaxcala",Area="Area 2",Inversion=21210.0,Roi=2121}
            };
            dictionarie.Add(29, tlaxcala);
            
            dictionarie.Add(30, new List<InversionMsft>());
             List<InversionMsft> yucatan = new List<InversionMsft>(){ 
                new InversionMsft(){Programa="BizSpark",Estado="Yucatan",Area="Area 1",Inversion=23212.10,Roi=2121}
            };
             dictionarie.Add(31, yucatan);

            
            dictionarie.Add(32, new List<InversionMsft>());


           
            return dictionarie;
        }
    }
}
