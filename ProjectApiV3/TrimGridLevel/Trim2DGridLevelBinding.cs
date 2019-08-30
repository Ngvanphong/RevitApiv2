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
using ProjectApiV3.Helper;
namespace ProjectApiV3.TrimGridLevel
{
    [Transaction(TransactionMode.Manual)]
    public class Trim2DGridLevelBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                var selectElmentIds = uiApp.ActiveUIDocument.Selection.GetElementIds();
                List<Grid> listGrid = new List<Grid>();
                List<Level> listLevel = new List<Level>();
                foreach (var id in selectElmentIds)
                {
                    Element element = doc.GetElement(id);
                    Grid grid = element as Grid;
                    Level level = element as Level;
                    if (grid != null)
                    {
                        listGrid.Add(grid);
                    }
                    if (level != null)
                    {
                        listLevel.Add(level);
                    }
                }
                if (listLevel.Count > 0 || listGrid.Count > 0)
                {
                    var lineExend = uiApp.ActiveUIDocument.Selection.PickObject(ObjectType.Element, new filterReplanceLine());
                    var elementEx = doc.GetElement(lineExend);
                    ReferencePlane refplance = elementEx as ReferencePlane;
                    Curve curve = null;
                    if (refplance == null)
                    {
                        LocationCurve locationCurve = elementEx.Location as LocationCurve;
                        curve = locationCurve.Curve;
                    }
                    else
                    {
                        curve = refplance.GetCurvesInView(DatumExtentType.ViewSpecific, doc.ActiveView).First();
                    }


                    if (listGrid.Count > 0)
                    {
                        foreach (Grid grid in listGrid)
                        {
                            using (Transaction t = new Transaction(doc, "Extend2DGrid"))
                            {
                                t.Start();
                                IList<Curve> curvasGrid = grid.GetCurvesInView(DatumExtentType.ViewSpecific, doc.ActiveView);
                                Curve linea = curvasGrid.First();
                                IList<XYZ> listPoint = curve.Tessellate();
                                if (listPoint.Count == 2)
                                {
                                    AssigTowPoint(doc, listPoint[0], listPoint[1], grid);
                                }else
                                {

                                }
                                t.Commit();
                            }

                        }
                    }

                }
                else
                {
                    TaskDialog.Show("error", "Choose grid or level");
                }
            }
            return Result.Succeeded;
        }

        public void AssigTowPoint(Document doc, XYZ p1, XYZ p2, Grid grid)
        {
            XYZ v = (p1 - p2).Normalize();
            Curve curegr = grid.GetCurvesInView(DatumExtentType.ViewSpecific, doc.ActiveView).First();
            XYZ g1 = curegr.GetEndPoint(0);
            XYZ g2 = curegr.GetEndPoint(1);
            XYZ u = (g1 - g2).Normalize();
            double k = 0;
            try
            {
                if (u.X == 0 && u.Y == 0)
                {
                    if (Math.Abs(v.X) > 0)
                    {
                        k = (p1.Z + v.Z * (g1.X - p1.X) / v.X - g1.Z) / (u.Z - u.X * v.Z / v.X);
                    }else{
                        k = (p1.Z + v.Z * (g1.Y - p1.Y) / v.Y - g1.Z) / (u.Z - u.Y * v.Z / v.Y);
                    }
                }
                else if (Math.Abs(v.X) > 0)
                {
                    k = (p1.Y + v.Y * (g1.X - p1.X) / v.X - g1.Y) / (u.Y - u.X * v.Y / v.X);
                }
                else if (Math.Abs(v.Y) > 0)
                {

                    k = (p1.X + v.X * (g1.Y - p1.Y) / v.Y - g1.X) / (u.X - u.Y * v.X / v.Y);
                }

                XYZ G = new XYZ(g1.X + u.X * k, g1.Y + u.Y * k, g1.Z + u.Z * k);  
                double d1 = (g1.X - G.X) * (g1.X - G.X) + (g1.Y - G.Y) * (g1.Y - G.Y) + (g1.Z - G.Z) * (g1.Z - G.Z);
                double d2 = (g2.X - G.X) * (g2.X - G.X) + (g2.Y - G.Y) * (g2.Y - G.Y) + (g2.Z - G.Z) * (g2.Z - G.Z);
               if(Math.Sqrt(d1)<10000000&& Math.Sqrt(d2)< 10000000)
                {
                    Curve curve = Line.CreateBound(g1, G);
                    if (d1 < d2)
                    {
                        curve = Line.CreateBound(G, g2);
                    }      
                    grid.SetCurveInView(DatumExtentType.ViewSpecific, doc.ActiveView, curve);
                }
                
            }
            catch (Exception e){ };
        }

        public void AssginManyPoint(Document doc, List<XYZ> listPoints, Grid grid)
        {

        }

    }
    public class filterReplanceLine : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            DetailCurve line = elem as DetailCurve;
            ReferencePlane replance = elem as ReferencePlane;
            if (line != null || replance != null)
            { return true; }
            else
            {
                return false;
            }

        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
