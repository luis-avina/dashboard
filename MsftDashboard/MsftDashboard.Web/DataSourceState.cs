using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PivotServerTools;
using MsftDashboard.Web.Services;
using MsftDashboard.Web.Models;

namespace MsftDashboard.Web
{
    public class DataSourceState : CollectionFactoryBase
    {
        public override Collection MakeCollection(CollectionRequestContext context)
        {
            Collection collection = new Collection();
            collection.Name = "Inversion Estado";
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

            List<StateProgram> query = db.GetStateProgramsByDate(initialDate, finalDate).ToList<StateProgram>();

            foreach (StateProgram stateProgram in query)
            {

                id++;
                collection.AddItem(
                    id.ToString(), null, null, null,
                    new Facet("Area", stateProgram.Source.Name),
                    new Facet("Programa", stateProgram.Program.Name),
                    new Facet("Tipo", stateProgram.TypeSource.Name),
                    new Facet("Owner", stateProgram.Owner.Name),
                    new Facet("Inversion", (double)stateProgram.Investment),
                    new Facet("ROI", (double)stateProgram.ROI),
                    new Facet("Progreso", (int)stateProgram.Progress),
                    new Facet("Número", (int)stateProgram.Number),
                    new Facet("Estado", stateProgram.State.Name));
            }
            return collection;
        }
    }
}