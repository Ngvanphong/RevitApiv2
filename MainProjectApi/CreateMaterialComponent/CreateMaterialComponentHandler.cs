using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Threading;
using MainProjectApi.Helper;

namespace MainProjectApi.CreateMaterialComponent
{
   public class CreateMaterialComponentHandler:IExternalEventHandler
    {

        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            Category category = doc.Settings.Categories.get_Item(BuiltInCategory.OST_GenericModel);
            IList<Element> collection = app.ActiveUIDocument.Selection.PickElementsByRectangle(new SelectionFilterCategory(category));
            ParameterRevit paremeter = new ParameterRevit(app);
            foreach (var item in collection)
            {
                try
                {
                    paremeter.CreateParameterRevit("Materials", "Structural Material", BuiltInCategory.OST_GenericModel);
                }
                catch
                {
                    continue;
                }
            }
        }

        public string GetName()
        {
            return "Assign material";
        }

       
    }
}
