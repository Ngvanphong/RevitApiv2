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
            Document doc = app.ActiveUIDocument.Document;
            string noNumberStart = AppPanelNoNumberSheet.myFormNoNumberSheet.txtNoStartNumber.Text;

            List<ViewSheet> listViewSheet = GetListSheetInSchedule(app);
            Parameter paramter = listViewSheet.First().LookupParameter("STT");
            ParameterRevit paraRevit = new ParameterRevit(app);
            if (paramter == null)
            {
                paraRevit.CreateParameterRevit("Sheet", "STT", BuiltInCategory.OST_Sheets, BuiltInParameterGroup.PG_IDENTITY_DATA);
            }
            string inputNumber = noNumberStart;
            foreach (var sheet in listViewSheet)
            {
                Parameter para = sheet.LookupParameter("STT");
                string newNoNumber = SetNumber(inputNumber, ref isBegin);
                if (isBegin == true)
                {
                    isBegin = false;
                }
                paraRevit.SetValueParameter(para, newNoNumber);
                inputNumber = newNoNumber;
            }

        }

        public string GetName()
        {
            return "NoNumberSheet";
        }

        public string SetNumber(string noNumber, ref bool isBegin)
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
            if (lengthNumber >= countEnd)
            {
                noNumberResult = noNumber.Remove(lengthNumber - countEnd) + end.ToString();
            }else
            {
                noNumberResult =  end.ToString();
            }
            
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
                if (viewsheet != null && isChecked == "1")
                {
                    listViewSheet.Add(viewsheet);
                }
            };
            if (listViewSheet.Count() == 0)
            {
                var allSheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
                foreach (var item in allSheets)
                {
                    Parameter parameter = item.LookupParameter("Appears In Sheet List");
                    var isChecked = ParameterRevit.ParameterToString(parameter);
                    if (isChecked == "1")
                    {
                        listViewSheet.Add(item);
                    }
                }
            }
            IOrderedEnumerable<ViewSheet> vps = from ViewSheet vp in listViewSheet orderby vp.SheetNumber ascending select vp;

            listViewSheet = vps.ToList();
            return listViewSheet;
        }
    }
}
