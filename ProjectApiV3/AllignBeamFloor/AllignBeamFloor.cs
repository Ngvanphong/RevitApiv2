using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
namespace ProjectApiV3.AllignBeamFloor
{
   public class AllignBeamFloor
    {
        UIApplication _uiApp;
        Document _doc;
        public AllignBeamFloor(UIApplication uiApp)
        {
            _uiApp = uiApp;
            _doc = _uiApp.ActiveUIDocument.Document;
        }
        public void AllignBeamToFloor()
        {
            List<ElementId> listIds= _uiApp.ActiveUIDocument.Selection.GetElementIds().ToList();
            List<FamilyInstance> listBeam = new List<FamilyInstance>();           
            foreach(var id in listIds)
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
            XYZ point1 = _uiApp.ActiveUIDocument.Selection.PickPoint();
            XYZ point2= _uiApp.ActiveUIDocument.Selection.PickPoint();            
            foreach (var item in listBeam)
            {
                try
                {
                    PointBeamAllign(point1,point2, item);
                }
                catch { continue; }
            }
           

        }

        public void PointBeamAllign(XYZ point1, XYZ point2,FamilyInstance beam)
        {
            double offset = 0.3;          
            LocationCurve locationBeam = beam.Location as LocationCurve;
            XYZ pointBeam1 = locationBeam.Curve.GetEndPoint(0);
            XYZ pointBeam2 = locationBeam.Curve.GetEndPoint(1);
            
            if (Math.Abs((pointBeam1.X - pointBeam2.X)* 0.3048 * 1000) < 2&&Math.Abs((point1.X-point2.X)*0.3048 * 1000)<100)
            {
                XYZ C = new XYZ(0, point1.Y, point1.Z);
                XYZ D = new XYZ(0, point2.Y, point2.Z);
                XYZ vLy = C - D;
                XYZ A = new XYZ(0, pointBeam1.Y, pointBeam1.Z);
                XYZ B = new XYZ(0, pointBeam2.Y, pointBeam2.Z);
                XYZ vByBeam = A - B;                
                if (vLy.Y * vByBeam.Y < 0)
                {
                    A= new XYZ(0, pointBeam2.Y, pointBeam2.Z);
                    B= new XYZ(0, pointBeam1.Y, pointBeam1.Z);
                    vByBeam = A - B;
                }
                XYZ vBy = new XYZ(0, 0,1);
                if (vByBeam.Z != 0)
                {
                    vBy = new XYZ(0, 1 / vByBeam.Y, -1 / vByBeam.Z);
                }

                double e1 = (C.Z - A.Z + vLy.Z * (A.Y - C.Y) / vLy.Y) / (vBy.Z - vLy.Z * vBy.Y / vLy.Y);
                XYZ Ag = new XYZ(pointBeam1.X, A.Y + vBy.Y * e1, A.Z + vBy.Z * e1);
                double e2 = (D.Z - B.Z + vLy.Z * (B.Y - D.Y) / vLy.Y) / (vBy.Z - vLy.Z * vBy.Y / vLy.Y);
                XYZ Bg = new XYZ(pointBeam2.X, B.Y + vBy.Y * e2, B.Z + vBy.Z * e2);
                using(Transaction t= new Transaction(_doc, "AllignBeam"))
                {
                    t.Start();                    
                    Curve curve = Line.CreateBound(Ag, Bg);
                    locationBeam.Curve = curve;
                    Parameter parameterStart = beam.LookupParameter("Start Level Offset");
                    double valueStart = parameterStart.AsDouble()- offset / (0.3048 * 1000);                  
                    SetValueParameterDouble(_doc, parameterStart, valueStart);
                    Parameter parameterEnd = beam.LookupParameter("End Level Offset");                   
                    double valueEnd = parameterEnd.AsDouble()- offset / (0.3048 * 1000);
                    SetValueParameterDouble(_doc, parameterEnd, valueEnd);
                    t.Commit();
                }
            }else if(Math.Abs((pointBeam1.Y - pointBeam2.Y) * 0.3048 * 1000) < 2 && Math.Abs((point1.Y - point2.Y) * 0.3048 * 1000) < 100)
            {
                XYZ C = new XYZ(point1.X, 0, point1.Z);
                XYZ D = new XYZ(point2.X, 0, point2.Z);
                XYZ vLy = C - D;
                XYZ A = new XYZ(pointBeam1.X, 0, pointBeam1.Z);
                XYZ B = new XYZ(pointBeam2.X, 0, pointBeam2.Z);
                XYZ vByBeam = A - B;
                if (vLy.X * vByBeam.X < 0)
                {
                    A = new XYZ(pointBeam2.X, 0, pointBeam2.Z);
                    B = new XYZ(pointBeam1.X, 0, pointBeam1.Z);
                    vByBeam = A - B;
                }
                XYZ vBy = new XYZ(0, 0, 1);
                if (vByBeam.Z != 0)
                {
                    vBy = new XYZ(1 / vByBeam.X, 0, -1 / vByBeam.Z);
                }

                double e1 = (C.Z - A.Z + vLy.Z * (A.X - C.X) / vLy.X) / (vBy.Z - vLy.Z * vBy.X / vLy.X);
                XYZ Ag = new XYZ(A.X + vBy.X * e1,pointBeam1.Y, A.Z + vBy.Z * e1);
                double e2 = (D.Z - B.Z + vLy.Z * (B.X - D.X) / vLy.X) / (vBy.Z - vLy.Z * vBy.X / vLy.X);
                XYZ Bg = new XYZ(B.X + vBy.X * e2,pointBeam2.Y, B.Z + vBy.Z * e2);
                using (Transaction t = new Transaction(_doc, "AllignBeam"))
                {
                    t.Start();
                    Curve curve = Line.CreateBound(Ag, Bg);
                    locationBeam.Curve = curve;
                    Parameter parameterStart = beam.LookupParameter("Start Level Offset");
                    double valueStart = parameterStart.AsDouble() - offset / (0.3048 * 1000);
                    SetValueParameterDouble(_doc, parameterStart, valueStart);
                    Parameter parameterEnd = beam.LookupParameter("End Level Offset");
                    double valueEnd = parameterEnd.AsDouble() - offset / (0.3048 * 1000);
                    SetValueParameterDouble(_doc, parameterEnd, valueEnd);
                    t.Commit();
                }

            }else if(Math.Abs((pointBeam1.Y - pointBeam2.Y) * 0.3048 * 1000) < 2 && Math.Abs((point1.X - point2.X) * 0.3048 * 1000) < 100)
            {
                using (Transaction t = new Transaction(_doc, "AllignBeam"))
                {
                    t.Start();
                    XYZ v1 = point1 - point2;                  
                    XYZ v2 = new XYZ(0, 1, 0);
                    double cos = (v1.Y) * 1 / (Math.Sqrt(v1.Y * v1.Y + v1.Z * v1.Z));
                    double radian = Math.Acos(cos);
                    XYZ A = new XYZ(0, pointBeam1.Y, pointBeam1.Z);
                    XYZ Ag = new XYZ(0, A.Y, point1.Z + v1.Z * (A.Y - point1.Y) / v1.Y);
                    XYZ At = new XYZ(pointBeam1.X, pointBeam1.Y, Ag.Z);
                    XYZ Ap = new XYZ(pointBeam2.X, pointBeam2.Y, Ag.Z);
                    Curve curve = Line.CreateBound(At, Ap);
                    locationBeam.Curve = curve;
                    Parameter parameterStart = beam.LookupParameter("Start Level Offset");
                    double valueStart = parameterStart.AsDouble() - offset / (0.3048 * 1000);
                    SetValueParameterDouble(_doc, parameterStart, valueStart);
                    Parameter parameterEnd = beam.LookupParameter("End Level Offset");
                    double valueEnd = parameterEnd.AsDouble() - offset / (0.3048 * 1000);
                    SetValueParameterDouble(_doc, parameterEnd, valueEnd);
                    Parameter parameterBeam = beam.LookupParameter("Cross-Section Rotation");
                    if (cos > 0)
                    {
                        parameterBeam.Set(radian);
                    }else
                    {
                        parameterBeam.Set(radian-Math.PI);
                    }
                   
                    t.Commit();
                }    

            }
            else if(Math.Abs((pointBeam1.X - pointBeam2.X) * 0.3048 * 1000) < 2 && Math.Abs((point1.Y - point2.Y) * 0.3048 * 1000) < 100)
            {
                using (Transaction t = new Transaction(_doc, "AllignBeam"))
                {
                    t.Start();
                    XYZ v1 = point1 - point2;
                    XYZ v2 = new XYZ(1, 0, 0);
                    double cos = (v1.X) * 1 / (Math.Sqrt(v1.X * v1.X + v1.Z * v1.Z));
                    double radian = Math.Acos(cos);
                    XYZ A = new XYZ(pointBeam1.X, 0, pointBeam1.Z);
                    XYZ Ag = new XYZ(A.X, 0, point1.Z + v1.Z * (A.X - point1.X) / v1.X);
                    XYZ At = new XYZ(pointBeam1.X, pointBeam1.Y, Ag.Z);
                    XYZ Ap = new XYZ(pointBeam2.X, pointBeam2.Y, Ag.Z);
                    Curve curve = Line.CreateBound(At, Ap);
                    locationBeam.Curve = curve;
                    Parameter parameterStart = beam.LookupParameter("Start Level Offset");
                    double valueStart = parameterStart.AsDouble() - offset / (0.3048 * 1000);
                    SetValueParameterDouble(_doc, parameterStart, valueStart);
                    Parameter parameterEnd = beam.LookupParameter("End Level Offset");
                    double valueEnd = parameterEnd.AsDouble() - offset / (0.3048 * 1000);
                    SetValueParameterDouble(_doc, parameterEnd, valueEnd);
                    Parameter parameterBeam = beam.LookupParameter("Cross-Section Rotation");
                    if (cos > 0)
                    {
                        parameterBeam.Set(radian);
                    }
                    else
                    {
                        parameterBeam.Set(radian - Math.PI);
                    }

                    t.Commit();
                }

            }
           
        }
        public void SetValueParameterDouble(Document doc, Parameter parameter, double value)
        {  
                try { parameter.Set(value); }
                catch (Exception ex) { };
              
        }


    }
}
