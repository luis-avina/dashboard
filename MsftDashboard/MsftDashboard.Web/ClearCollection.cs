using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PivotServerTools;

namespace MsftDashboard.Web
{
    public class ClearCollection : CollectionFactoryBase
    {
        public override Collection MakeCollection(CollectionRequestContext context)
        {
            Collection collection = new Collection();
            collection.Name = "";

           
                collection.AddItem("", null, null, null, new Facet("Empty Collection", ""));
           
            return collection;
        }
    }
}