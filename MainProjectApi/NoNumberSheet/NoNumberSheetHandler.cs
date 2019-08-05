using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Threading;
using MainProjectApi.Helper;
using System.IO;
using System.Text.RegularExpressions;

namespace MainProjectApi.NoNumberSheet
{
    public class NoNumberSheetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            bool isBegin = true;
            string noNumberStart = AppPanelNoNumberSheet.myFormNoNumberSheet.txtNoStartNumber.Text;
            List<ViewSheet> listViewSheet = GetListSheetInSchedule(app);
           
        }

        public string GetName()
        {
            return "NoNumberSheet";
        }

        public string GetNumber(string noNumber, ref bool isBegin)
        {
            string noNumberResult = null;
            int lengthNumber = noNumber.Length;
            string start = Regex.Replace(noNumber, @"[\d-]", string.Empty);
            int end = int.Parse(Regex.Match(noNumber, @"\d+").Value);
            if (isBegin == false)
            {
                end = end + 1;
            }
            int countEnd = end.ToString().Length;
            noNumberResult = noNumber.Remove(lengthNumber - countEnd) + end.ToString();
            return noNumberResult;
        }
        public List<ViewSheet> GetListSheetInSchedule(UIApplication uIapp)
        {
            Document doc = uIapp.ActiveUIDocument.Document;
            UIDocument uIDoc = uIapp.ActiveUIDocument;
            ICollection<ElementId> listIdSelect = uIDoc.Selection.GetElementIds();
            List<ViewSheet> listViewSheet = new List<ViewSheet>();
            ParameterRevit paramaterRevit = new ParameterRevit(uIapp);
            foreach (var id in listIdSelect)
            {
                ViewSheet viewsheet = doc.GetElement(id) as ViewSheet;
                Parameter parameter = viewsheet.LookupParameter("Appears In Sheet List");
                var isChecked = ParameterRevit.ParameterToString(parameter);
                if (viewsheet != null&&isChecked!="0")
                {
                    listViewSheet.Add(viewsheet);
                }
            }
            IOrderedEnumerable<ViewSheet> vps = from ViewSheet vp in listViewSheet orderby vp.SheetNumber ascending select vp;
           
            listViewSheet = vps.ToList();
            return listViewSheet;
        }
    }
}
