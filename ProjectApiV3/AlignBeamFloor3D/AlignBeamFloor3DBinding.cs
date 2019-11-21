using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using ProjectApiV3.Helper;

namespace ProjectApiV3.AlignBeamFloor3D
{
    [Transaction(TransactionMode.Manual)]
    public class AlignBeamFloor3DBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //if (CheckAccess.CheckLicense() == true)
            //{
                AlignBeam3d(uiApp);
            //}
            return Result.Succeeded;
        }
        public void AlignBeam3d(UIApplication _uiApp)
        {
            try
            {
                Document _doc = _uiApp.ActiveUIDocument.Document;
                List<ElementId> listIds = _uiApp.ActiveUIDocument.Selection.GetElementIds().ToList();
                List<FamilyInstance> listBeam = new List<FamilyInstance>();
                foreach (var id in listIds)
                {
                    FamilyInstance element = null;
                    element = _doc.GetElement(id) as FamilyInstance;
                    if (element != null)
                    {
                        if (element.Category.Name == "Structural Framing")
                        {
                            listBeam.Add(element);
                        }
                    }
                }
                XYZ A = _uiApp.ActiveUIDocument.Selection.PickPoint();
                XYZ B = _uiApp.ActiveUIDocument.Selection.PickPoint();
                XYZ C= _uiApp.ActiveUIDocument.Selection.PickPoint();
                XYZ ab = new XYZ(B.X - A.X, B.Y - A.Y, B.Z - A.Z);
                XYZ ac = new XYZ(C.X - A.X, C.Y - A.Y, C.Z - A.Z);
                XYZ n = new XYZ(ab.Y * ac.Z - ab.Z * ac.Y, ab.Z * ac.X - ac.Z * ab.X, ab.X * ac.Y - ac.X * ab.Y);
                double k = -(n.X * A.X + n.Y * A.Y + n.Z * A.Z);
                foreach (var item in listBeam)
                {
                    try
                    {
                        LocationCurve locationBeam = item.Location as LocationCurve;
                        XYZ D = locationBeam.Curve.GetEndPoint(0);
                        XYZ E = locationBeam.Curve.GetEndPoint(1);
                        double t = -(k + n.X * D.X + n.Y * D.Y + n.Z * D.Z) / n.Z;
                        double h= -(k + n.X * E.X + n.Y * E.Y + n.Z * E.Z) / n.Z;
                        XYZ F = new XYZ(D.X, D.Y, D.Z + t);
                        XYZ G = new XYZ(E.X, E.Y, E.Z + h);
                        using (Transaction t2 = new Transaction(_doc, "AlignBeam3D"))
                        {
                            t2.Start();
                            Curve curve = Line.CreateBound(F, G);
                            locationBeam.Curve = curve;    
                            t2.Commit();
                        }
                    }
                    catch { continue; }
                }
            }
            catch { }
        }
    }
}
