using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace MainProjectApi.DirectShape
{
   public static class AppPenalCreateDirectShape
    {
        public static frmCreateDirectShape formCreateDrirectShape;
        public static void ShowFormShape(UIApplication uiApp)
        {
            CreateDirectShapeHandler handler = new CreateDirectShapeHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);
            formCreateDrirectShape = new frmCreateDirectShape(myEvent, handler);
            formCreateDrirectShape.Show();
        }


    }
}
