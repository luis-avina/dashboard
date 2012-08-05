using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PivotServerTools;
using MsftDashboard.Web.Services;
using MsftDashboard.Web.Models;

namespace MsftDashboard.Web
{
    public class MsftDashBoardSource : CollectionFactoryBase
    {
        public override Collection MakeCollection(CollectionRequestContext context)
        {
            Collection collection = new Collection();
            collection.Name = "Inversion Microsoft";
            string parameters;

            DateTime initialDate = new DateTime();
            DateTime finalDate = new DateTime();
            if (context.Query != null)
            {
                string param1 = context.Query[0];
                string param2 = context.Query[1];
                long thick1 = 0;
                long thick2 = 0;
                if (long.TryParse(param1, out thick1) && long.TryParse(param2, out thick2))
                {
                    initialDate = new DateTime(thick1);
                    finalDate = new DateTime(thick2);
                }


            }
            

             int id = 0;

             DBService db = new DBService();

             List<MicrosoftProgramState> query = db.GetMicrosoftProgramStatesByDate(initialDate,finalDate).ToList<MicrosoftProgramState>();

             foreach (MicrosoftProgramState msftProgram in query)
             {

                 id++;
                 collection.AddItem(
                     id.ToString(), null, null, null,
                     new Facet("Area", msftProgram.Source.Name),
                     new Facet("Programa", msftProgram.Program.Name),
                     new Facet("Tipo",msftProgram.TypeSource.Name),
                     new Facet("Owner", msftProgram.Owner.Name),
                     new Facet("Inversion",(double) msftProgram.Investment), 
                     new Facet("ROI",(double) msftProgram.ROI),
                     new Facet("Progreso", (int)msftProgram.Progress),
                     new Facet("Número",(int)msftProgram.Number),
                     new Facet("Estado", msftProgram.State.Name));
             }
            return collection;
        }
    }
}