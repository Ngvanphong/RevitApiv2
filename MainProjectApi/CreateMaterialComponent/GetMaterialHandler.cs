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
namespace MainProjectApi.CreateMaterialComponent
{
    public class GetMaterialHandler : IExternalEventHandler
    {
       

        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;

        }

        public string GetName()
        {
            return "GetMaterial";
        }
    }
}
