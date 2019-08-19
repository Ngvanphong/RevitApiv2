#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ProjectApiV3.Button;
#endregion

namespace ProjectApiV3
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            AllignBeamFloorButton allignBeam = new AllignBeamFloorButton();
            allignBeam.CreateAlllignBeam(a);
            FilterElementButton filterClass = new FilterElementButton();
            filterClass.FilterElement(a);
            RevisionButton revisionClass = new RevisionButton();
            revisionClass.CreateRevision(a);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
