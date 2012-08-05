using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PivotServerTools;
using MsftDashboard.Web.Services;
using MsftDashboard.Web.Models;

namespace MsftDashboard.Web
{
    public class DataSourceCompetition : CollectionFactoryBase
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

            List<Competition> query = db.GetCompetitionsByDate(initialDate, finalDate).ToList<Competition>();

            foreach (Competition competitionProgram in query)
            {

                id++;
                collection.AddItem(
                    id.ToString(), null, null, null,
                    new Facet("Tipo", competitionProgram.TypeSource.Name),
                    new Facet("Owner", competitionProgram.Owner.Name),
                    new Facet("Inversion", (double)competitionProgram.Investment),
                    new Facet("ROI", (double)competitionProgram.ROI),
                    new Facet("Progreso", (int)competitionProgram.Progress),
                    new Facet("Número", (int)competitionProgram.Number),
                    new Facet("Estado", competitionProgram.State.Name));
            }
            return collection;
        }
    }
}