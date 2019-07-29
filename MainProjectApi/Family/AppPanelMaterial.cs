using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace MainProjectApi.CreateMaterialFamily
{
  public static  class AppPanelMaterial
    {
        public static frmCreateMaterialFamily formCreateMaterial;

        public static void ShowCrateMaterial(UIApplication uiApp)
        {
            CreateMaterialFamilyHandler handler = new CreateMaterialFamilyHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);            
            formCreateMaterial = new frmCreateMaterialFamily(myEvent, handler);
            formCreateMaterial.Show();
        }
    }
}
