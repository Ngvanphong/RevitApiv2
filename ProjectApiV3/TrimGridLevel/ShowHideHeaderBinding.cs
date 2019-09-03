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
    public class ShowHideHeaderBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                var selectElmentIds = uiApp.ActiveUIDocument.Selection.GetElementIds();
                using (Transaction t = new Transaction(doc, "Create WorkPlane"))
                {
                    t.Start();
                    Plane plane = Plane.CreateByNormalAndOrigin(doc.ActiveView.ViewDirection, doc.ActiveView.Origin);
                    SketchPlane sp = SketchPlane.Create(doc, plane);
                    doc.ActiveView.SketchPlane = sp;
                    t.Commit();
                }
                var selectPoint = uiApp.ActiveUIDocument.Selection.PickPoint();
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
                    if (listGrid.Count > 0)
                    {
                        foreach (Grid grid in listGrid)
                        {
                            using (Transaction t = new Transaction(doc, "ShowGridHide"))
                            {
                                t.Start();
                                try
                                {
                                    ShowHide(doc, selectPoint, grid);
                                    t.Commit();
                                }
                                catch
                                {
                                    t.Commit();
                                    continue;
                                }                               
                            }
                        }
                    }else if (listLevel.Count > 0)
                    {
                        foreach (Level level in listLevel)
                        {
                            using (Transaction t = new Transaction(doc, "ShowLevelHide"))
                            {
                                t.Start();
                                try
                                {
                                    ShowHide(doc, selectPoint, level);
                                    t.Commit();
                                }
                                catch
                                {
                                    t.Commit();
                                    continue;
                                }
                            }
                        }
                    }
                }

            }
            return Result.Succeeded;
        }

        public void ShowHide(Document doc, XYZ G, Element element)
        {
            var grid = element as Grid;
            var level = element as Level;
            if (grid != null)
            {
                Curve curegr = grid.GetCurvesInView(DatumExtentType.ViewSpecific, doc.ActiveView).First();
                XYZ g1 = curegr.GetEndPoint(0);
                XYZ g2 = curegr.GetEndPoint(1);
                XYZ C = g1;
                double d1 = (g1.X - G.X) * (g1.X - G.X) + (g1.Y - G.Y) * (g1.Y - G.Y) + (g1.Z - G.Z) * (g1.Z - G.Z);
                double d2 = (g2.X - G.X) * (g2.X - G.X) + (g2.Y - G.Y) * (g2.Y - G.Y) + (g2.Z - G.Z) * (g2.Z - G.Z);
                if (d2 < d1)
                {
                    C = g2;
                    bool isShow = grid.IsBubbleVisibleInView(DatumEnds.End1, doc.ActiveView);
                    if (isShow == false)
                    {
                        grid.ShowBubbleInView(DatumEnds.End1, doc.ActiveView);
                    }
                    else
                    {
                        grid.HideBubbleInView(DatumEnds.End1, doc.ActiveView);
                    }
                }
                else
                {
                    bool isShow = grid.IsBubbleVisibleInView(DatumEnds.End0, doc.ActiveView);
                    if (isShow == false)
                    {
                        grid.ShowBubbleInView(DatumEnds.End0, doc.ActiveView);
                    }
                    else
                    {
                        grid.HideBubbleInView(DatumEnds.End0, doc.ActiveView);
                    }
                }
            }
            else if (level != null)
            {

                Curve curegr = level.GetCurvesInView(DatumExtentType.ViewSpecific, doc.ActiveView).First();
                XYZ g1 = curegr.GetEndPoint(0);
                XYZ g2 = curegr.GetEndPoint(1);
                XYZ C = g1;
                double d1 = (g1.X - G.X) * (g1.X - G.X) + (g1.Y - G.Y) * (g1.Y - G.Y) + (g1.Z - G.Z) * (g1.Z - G.Z);
                double d2 = (g2.X - G.X) * (g2.X - G.X) + (g2.Y - G.Y) * (g2.Y - G.Y) + (g2.Z - G.Z) * (g2.Z - G.Z);
                if (d2 < d1)
                {
                    C = g2;
                    bool isShow = level.IsBubbleVisibleInView(DatumEnds.End1, doc.ActiveView);
                    if (isShow == false)
                    {
                        level.ShowBubbleInView(DatumEnds.End1, doc.ActiveView);
                    }
                    else
                    {
                        level.HideBubbleInView(DatumEnds.End1, doc.ActiveView);
                    }
                }
                else
                {
                    bool isShow = level.IsBubbleVisibleInView(DatumEnds.End0, doc.ActiveView);
                    if (isShow == false)
                    {
                        level.ShowBubbleInView(DatumEnds.End0, doc.ActiveView);
                    }
                    else
                    {
                        level.HideBubbleInView(DatumEnds.End0, doc.ActiveView);
                    }
                }
            }

        }

    }
}
