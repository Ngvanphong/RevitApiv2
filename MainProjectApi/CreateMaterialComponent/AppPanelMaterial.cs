using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace MainProjectApi.CreateMaterialComponent
{
  public static  class AppPanelMaterial
    {
        public static frmCreateMaterialCompont formCreateMaterial;

        public static void ShowCrateMaterial(UIApplication uiApp)
        {
            CreateMaterialComponentHandler handler = new CreateMaterialComponentHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);            
            formCreateMaterial = new frmCreateMaterialCompont(myEvent, handler);
            formCreateMaterial.Show();
        }
    }
}
