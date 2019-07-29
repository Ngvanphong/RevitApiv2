#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using MainProjectApi.Button;
#endregion

namespace MainProjectApi
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            //CreateMaterialFamilyButton createMaterialButton = new CreateMaterialFamilyButton();
            //createMaterialButton.CreateMaterial(a);
            AssignViewButton assignViewButton = new AssignViewButton();
            assignViewButton.CreateAssignView(a);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
