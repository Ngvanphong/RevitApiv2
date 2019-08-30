using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ProjectApiV3.Helper;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.ApplicationServices;

namespace ProjectApiV3.DimOffset
{
    [Transaction(TransactionMode.Manual)]
    public class DimOffsetBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Application app = uiapp.Application;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPanelDimOffset.ShowFormDimOffset();
                ElevationWatcherUpdater updater = new ElevationWatcherUpdater(app.ActiveAddInId);
                UpdaterRegistry.RegisterUpdater(updater);
                ElementCategoryFilter f = new ElementCategoryFilter(BuiltInCategory.OST_Dimensions);
                UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), f, Element.GetChangeTypeElementAddition());
                UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), f, Element.GetChangeTypeAny());
                AppPanelDimOffset._updater = updater;
            }
            return Result.Succeeded;
        }
    }
    public class ElevationWatcherUpdater : IUpdater
    {
        static AddInId _appId;
        static UpdaterId _updaterId;
        public ElevationWatcherUpdater(AddInId id)
        {
            _appId = id;
            _updaterId = new UpdaterId(_appId, new Guid("fafbf6b2-4c06-42d4-97c1-d1b4eb593eff"));
        }
        private static void DimOffset(Document doc, List<ElementId> listElementId, out bool isModifiledAdd)
        {
            isModifiledAdd = false;
            foreach (var id in listElementId)
            {
                Element element = doc.GetElement(id);
                Dimension dimension = null;
                try
                {
                    dimension = element as Dimension;
                }
                catch { }
                if (dimension != null)
                {
                    Line dimLine = dimension.Curve as Line;

                    if (dimLine == null)
                    {
                        continue;
                    }
                    else
                    {
                        XYZ vector = dimLine.Direction.Normalize();
                        bool vectorX = vector.IsAlmostEqualTo(XYZ.BasisX) || vector.IsAlmostEqualTo(-XYZ.BasisX);
                        bool vectorY = vector.IsAlmostEqualTo(XYZ.BasisY) || vector.IsAlmostEqualTo(-XYZ.BasisY);
                        var listSegments = dimension.Segments;
                        if (listSegments.Size == 0)
                        {
                            double valueText = double.Parse(dimension.ValueString);
                            if (valueText <= Constants.MinimumDistance)
                            {
                                var pointNowDim = dimension.Origin;
                                var pointOrigin = dimension.TextPosition;
                                if (vectorX)
                                {
                                    if (Math.Abs(pointNowDim.X - pointOrigin.X) < 0.0001)
                                    {
                                        XYZ newTextPosition = Transform.CreateTranslation(new XYZ(Constants.TrasformDistance, Constants.TrasformDistanceY, 0.0))
                                            .OfPoint(pointOrigin);
                                        dimension.TextPosition = newTextPosition;
                                        isModifiledAdd = true;
                                    }
                                }
                                else if (vectorY)
                                {
                                    if (Math.Abs(pointNowDim.Y - pointOrigin.Y) < 0.0001)
                                    {
                                        XYZ newTextPosition = Transform.CreateTranslation(new XYZ(-Constants.TrasformDistanceY, Constants.TrasformDistance, 0.0))
                                            .OfPoint(pointOrigin);
                                        dimension.TextPosition = newTextPosition;
                                        isModifiledAdd = true;
                                    }
                                }
                                //code
                                else
                                {
                                    DimNotXY dimNotXy = new DimNotXY();
                                    dimNotXy = GetPointInfor(pointOrigin, pointNowDim, vector, Constants.TrasformDistance, Constants.TrasformDistanceY, true);
                                    if (Math.Abs(pointNowDim.X - dimNotXy.Oorigin.X) < 0.1)
                                    {
                                        dimension.TextPosition = dimNotXy.Toffset;
                                        isModifiledAdd = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            List<DimensionPosition> listPositon = PositionDim(listSegments, vectorX, vectorY);
                            foreach (var item in listPositon)
                            {
                                if (item.right == true)
                                {
                                    var pointOrigin = item.DemissionSeg.TextPosition;
                                    var pointNowDim = item.DemissionSeg.Origin;

                                    if (vectorX == true)
                                    {
                                        if (Math.Abs(pointNowDim.X - pointOrigin.X) < (0.0001))
                                        {
                                            XYZ newTextPosition = Transform.CreateTranslation(new XYZ(Constants.TrasformDistance, Constants.TrasformDistanceY, 0.0))
                                                .OfPoint(pointOrigin);
                                            item.DemissionSeg.TextPosition = newTextPosition;
                                            isModifiledAdd = true;
                                        }
                                    }
                                    else if (vectorY == true)
                                    {
                                        if (Math.Abs(pointNowDim.Y - pointOrigin.Y) < (0.0001))
                                        {
                                            XYZ newTextPosition = Transform.CreateTranslation(new XYZ(-Constants.TrasformDistanceY, Constants.TrasformDistance, 0.0))
                                                .OfPoint(pointOrigin);
                                            item.DemissionSeg.TextPosition = newTextPosition;
                                            isModifiledAdd = true;
                                        }
                                    }
                                    //code 
                                    else
                                    {
                                        DimNotXY dimNotXy = new DimNotXY();
                                        dimNotXy = GetPointInfor(pointOrigin, pointNowDim, vector, Constants.TrasformDistance, Constants.TrasformDistanceY, item.right);
                                        if (Math.Abs(pointNowDim.X - dimNotXy.Oorigin.X) < 0.1)
                                        {
                                            item.DemissionSeg.TextPosition = dimNotXy.Toffset;
                                            isModifiledAdd = true;
                                        }
                                    }
                                }
                                else
                                {
                                    var pointOrigin = item.DemissionSeg.TextPosition;
                                    var pointNowDim = item.DemissionSeg.Origin;
                                    if (vectorX == true)
                                    {
                                        if (Math.Abs(pointNowDim.X - pointOrigin.X) < (0.0001))
                                        {
                                            XYZ newTextPosition = Transform.CreateTranslation(new XYZ(-Constants.TrasformDistance, Constants.TrasformDistanceY, 0.0)).OfPoint(pointOrigin);
                                            item.DemissionSeg.TextPosition = newTextPosition;
                                            isModifiledAdd = true;
                                        }
                                        else if (pointOrigin.X - pointNowDim.X > 0)
                                        {
                                            XYZ newTextPosition = Transform.CreateTranslation(new XYZ(-Constants.TrasformDistance, 0.0, 0.0))
                                                .OfPoint(new XYZ(pointNowDim.X, pointOrigin.Y, pointOrigin.Z));
                                            item.DemissionSeg.TextPosition = newTextPosition;
                                            isModifiledAdd = true;
                                        }
                                    }
                                    else if (vectorY == true)
                                    {
                                        if (Math.Abs(pointNowDim.Y - pointOrigin.Y) < (0.0001))
                                        {
                                            XYZ newTextPosition = Transform.CreateTranslation(new XYZ(-Constants.TrasformDistanceY, -Constants.TrasformDistance, 0.0)).OfPoint(pointOrigin);
                                            item.DemissionSeg.TextPosition = newTextPosition;
                                            isModifiledAdd = true;
                                        }
                                        else if (pointOrigin.Y - pointNowDim.Y > 0)
                                        {
                                            XYZ newTextPosition = Transform.CreateTranslation(new XYZ(0.0, -Constants.TrasformDistance, 0.0))
                                                .OfPoint(new XYZ(pointOrigin.X, pointNowDim.Y, pointOrigin.Z));
                                            item.DemissionSeg.TextPosition = newTextPosition;
                                            isModifiledAdd = true;
                                        }
                                    }
                                    //code
                                    else
                                    {
                                        DimNotXY dimNotXy = new DimNotXY();
                                        dimNotXy = GetPointInfor(pointOrigin, pointNowDim, vector, Constants.TrasformDistance, Constants.TrasformDistanceY, item.right);
                                        if (Math.Abs(pointNowDim.X - dimNotXy.Oorigin.X) < 0.1)
                                        {
                                            item.DemissionSeg.TextPosition = dimNotXy.Toffset;
                                            isModifiledAdd = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
        private static List<DimensionPosition> PositionDim(DimensionSegmentArray arrayDim, bool vectorX, bool vectorY)
        {
            List<DimensionPosition> listResult = new List<DimensionPosition>();
            if (vectorX == true)
            {
                List<DimensionSegment> listSegment = arrayDim.Cast<DimensionSegment>().OrderBy(x => x.Origin.X).ToList();
                List<DimensionPosition> listSegmentNeed = new List<DimensionPosition>();
                for (int i = 0; i < listSegment.Count; i++)
                {
                    double valueText = double.Parse(listSegment[i].ValueString);
                    if (valueText <= Constants.MinimumDistance)
                    {
                        DimensionPosition item = new DimensionPosition();
                        item.DemissionSeg = listSegment[i];
                        item.index = i;
                        listSegmentNeed.Add(item);
                    }
                }
                listSegmentNeed = listSegmentNeed.OrderBy(x => x.index).ToList();
                for (int i = 0; i < listSegmentNeed.Count; i++)
                {
                    if (i == 0)
                    {
                        listSegmentNeed[i].right = false;
                    }
                    else
                    {
                        if (listSegmentNeed[i - 1].right == false && listSegmentNeed[i - 1].index == (listSegmentNeed[i].index - 1))
                        {
                            listSegmentNeed[i].right = true;
                        }
                    }
                }
                listResult = listSegmentNeed;
            }
            else if (vectorY == true)
            {
                List<DimensionSegment> listSegment = arrayDim.Cast<DimensionSegment>().OrderBy(x => x.Origin.Y).ToList();
                List<DimensionPosition> listSegmentNeed = new List<DimensionPosition>();
                for (int i = 0; i < listSegment.Count; i++)
                {
                    double valueText = double.Parse(listSegment[i].ValueString);
                    if (valueText <= Constants.MinimumDistance)
                    {
                        DimensionPosition item = new DimensionPosition();
                        item.DemissionSeg = listSegment[i];
                        item.index = i;
                        listSegmentNeed.Add(item);
                    }
                }
                listSegmentNeed = listSegmentNeed.OrderBy(x => x.index).ToList();
                for (int i = 0; i < listSegmentNeed.Count; i++)
                {
                    if (i == 0)
                    {
                        listSegmentNeed[i].right = false;
                    }
                    else
                    {
                        if (listSegmentNeed[i - 1].right == false && listSegmentNeed[i - 1].index == (listSegmentNeed[i].index - 1))
                        {
                            listSegmentNeed[i].right = true;
                        }
                    }
                }
                listResult = listSegmentNeed;
            }
            else
            {
                List<DimensionSegment> listSegment = arrayDim.Cast<DimensionSegment>().OrderBy(x => x.Origin.X).ToList();
                List<DimensionPosition> listSegmentNeed = new List<DimensionPosition>();
                for (int i = 0; i < listSegment.Count; i++)
                {
                    double valueText = double.Parse(listSegment[i].ValueString);
                    if (valueText <= Constants.MinimumDistance)
                    {
                        DimensionPosition item = new DimensionPosition();
                        item.DemissionSeg = listSegment[i];
                        item.index = i;
                        listSegmentNeed.Add(item);
                    }
                }
                listSegmentNeed = listSegmentNeed.OrderBy(x => x.index).ToList();
                for (int i = 0; i < listSegmentNeed.Count; i++)
                {
                    if (i == 0)
                    {
                        listSegmentNeed[i].right = false;
                    }
                    else
                    {
                        if (listSegmentNeed[i - 1].right == false && listSegmentNeed[i - 1].index == (listSegmentNeed[i].index - 1))
                        {
                            listSegmentNeed[i].right = true;
                        }
                    }
                }
                listResult = listSegmentNeed;
            }
            return listResult;
        }
        public static bool breakEvent = false;
        public void Execute(UpdaterData data)
        {
            Document doc = data.GetDocument();
            Application app = doc.Application;
            var listElementIdAdd = data.GetAddedElementIds().ToList();
            var listElementModifile = data.GetModifiedElementIds().ToList();
            if (listElementIdAdd.Count == 1)
            {
                bool isModified = false;
                DimOffset(doc, listElementIdAdd, out isModified);
                if (isModified == true)
                {
                    breakEvent = true;
                }
                else
                {
                    breakEvent = false;
                }
            }
            else if (listElementModifile.Count == 1 && breakEvent == false)
            {
                bool isModified = false;
                DimOffset(doc, listElementModifile, out isModified);
                if (isModified == true)
                {
                    breakEvent = true;
                }
                else
                {
                    breakEvent = false;
                }
            }
            else if (breakEvent == true)
            {
                breakEvent = false;
            }
        }

        public string GetAdditionalInformation()
        {
            return "ngvanphong2012@gmail.com";
        }

        public ChangePriority GetChangePriority()
        {
            return ChangePriority.Annotations;
        }

        public UpdaterId GetUpdaterId()
        {
            return _updaterId;
        }

        public string GetUpdaterName()
        {
            return "DimensionUpdater";
        }

        public static DimNotXY GetPointInfor(XYZ T, XYZ O, XYZ v, double x, double y, bool right)
        {
            DimNotXY result = new DimNotXY();
            double a = v.X;
            double b = v.Y;
            double cos = Math.Sqrt(1 / (b * b / a * a + 1));
            double xk1 = T.X + Math.Sqrt(y * y / (1 + a * a / (b * b)));
            double xk2 = T.X - Math.Sqrt(y * y / (1 + a * a / (b * b)));
            double yk1 = T.Y - (xk1 - T.X) * a / b;
            double yk2 = T.Y - (xk2 - T.X) * a / b;
            double xk = xk1;
            double yk = yk1;
            double d1 = Math.Abs(b * xk1 - a * yk1 - b * O.X + a * O.Y) / Math.Sqrt(a * a + b * b);
            double d2 = Math.Abs(b * xk2 - a * yk2 - b * O.X + a * O.Y) / Math.Sqrt(a * a + b * b);
            if (d1 < d2)
            {
                xk = xk2;
                yk = yk2;
            }
            double xg1 = T.X + Math.Sqrt(x * x / (1 + b * b / (a * a)));
            double xg2 = T.X - Math.Sqrt(x * x / (1 + b * b / (a * a)));
            double yg1 = T.Y + (xg1 - T.X) * b / a;
            double yg2 = T.Y + (xg2 - T.X) * b / a;
            double xg = xg1;
            double yg = yg1;
            if (right == false)
            {
                xg = xg2;
                yg = yg2;
            }
            double kg = (yk - yg + b * (xg - xk) / a) / (a + b * b / a);
            XYZ Tn = new XYZ(xg - b * kg, yg + a * kg, T.Z);
            double k = (O.Y + b * (T.X - O.X) / a - T.Y) / (a + b * b / a);
            result.Oorigin = new XYZ(T.X - k * b, T.Y + k * a, T.Z);
            result.Toffset = Tn;
            return result;
        }
    }

    public class DimensionPosition
    {
        public DimensionSegment DemissionSeg { get; set; }
        public int index { get; set; }
        public bool right { get; set; }
    }
    public class DimNotXY
    {
        public XYZ Toffset { get; set; }

        public XYZ Oorigin { set; get; }
    }
}
