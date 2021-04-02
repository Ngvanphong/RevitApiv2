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
            //AllignBeamFloorButton allignBeam = new AllignBeamFloorButton();
            //allignBeam.CreateAlllignBeam(a);
            RevisionButton revisionClass = new RevisionButton();
            revisionClass.CreateRevision(a);
            //RevisionCloudButton revisionCloud = new RevisionCloudButton();
            //revisionCloud.CreateRevisionCloud(a);
            DimOffsetButton dimOffsetClass = new DimOffsetButton();
            dimOffsetClass.DimOffset(a);
            Trim2DGridLevelButton trim2Dclass = new Trim2DGridLevelButton();
            trim2Dclass.Trim2D(a);
            //Trim3DGridLevelButton trim3Dclass = new Trim3DGridLevelButton();
            //trim3Dclass.Trim3D(a);
            //ShowHideHeaderButton showHideButton = new ShowHideHeaderButton();
            //showHideButton.ShowHideHeader(a);
            CropViewButton cropViewButton = new CropViewButton();
            cropViewButton.CropView(a);
            AlignBeamFloor3DButton alignBeam3d = new AlignBeamFloor3DButton();
            alignBeam3d.CreateAllignBeam3D(a);
            new FilteredWpfButton().CreateFileredWpf(a);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
