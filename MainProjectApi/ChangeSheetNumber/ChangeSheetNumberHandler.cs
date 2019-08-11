using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Text.RegularExpressions;
using MainProjectApi.Helper;
using System.Windows.Forms;

namespace MainProjectApi.ChangeSheetNumber
{
   public class ChangeSheetNumberHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {          
            Document doc = app.ActiveUIDocument.Document;
            List<ViewSheet> listViewSheet= GetListSheet(app);
            string numberOrigin = null;
            string sheetNumberStart = AppPanelChangeSheetNumber.myFormChangeSheetNumber.txtSheetNumberStart.Text;
            int resetNumber = 111111111;
            foreach (var item in listViewSheet)
            {
                if (numberOrigin == null)
                {
                    numberOrigin = item.SheetNumber;
                }
                using (Transaction t2 = new Transaction(doc, "ResetSetNumber"))
                {
                    t2.Start();
                    item.SheetNumber =resetNumber.ToString() ;
                    resetNumber += 1;
                    t2.Commit();
                }
            }
            try
            {
                string numberInput = null;
                bool isStart = true;
                if (sheetNumberStart != "" && !string.IsNullOrEmpty(sheetNumberStart))
                {
                    if (numberInput == null)
                    {
                        numberInput = sheetNumberStart;
                    }
                    foreach (var sheet in listViewSheet)
                    {
                        
                        string sheetNumberNew = CreateNumberSheet(numberInput,ref isStart);
                        using (Transaction t = new Transaction(doc, "ChangeSheet"))
                        {
                            t.Start();
                            sheet.SheetNumber = sheetNumberNew;
                            numberInput = sheetNumberNew;
                            if (isStart == true) isStart = false;
                            t.Commit();
                        }                       
                       
                    }
                }
                else
                {
                    foreach (var sheet in listViewSheet)
                    {
                        if (numberInput == null)
                        {
                            numberInput = numberOrigin;
                        }
                        string sheetNumberNew = CreateNumberSheet(numberInput, ref isStart);
                        using (Transaction t = new Transaction(doc, "ChangeSheet"))
                        {
                            t.Start();
                            sheet.SheetNumber = sheetNumberNew;
                            numberInput = sheetNumberNew;
                            if (isStart == true) isStart = false;
                            t.Commit();
                        }
                        
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: Not success, You must input start number");                
                return;                
            }


        }

        public List<ViewSheet> GetListSheet(UIApplication uIapp)
        {
            Document doc = uIapp.ActiveUIDocument.Document;            
            UIDocument uIDoc = uIapp.ActiveUIDocument;
            ICollection<ElementId> listIdSelect = uIDoc.Selection.GetElementIds();
            List<ViewSheet> listViewSheet = new List<ViewSheet>();
             foreach(var id in listIdSelect)
            {
                ViewSheet viewsheet = doc.GetElement(id) as ViewSheet;
                if (viewsheet != null)
                {
                    listViewSheet.Add(viewsheet);
                }
            }
            IOrderedEnumerable<ViewSheet> vps =from ViewSheet vp in listViewSheet  orderby vp.SheetNumber ascending select vp;
            //listViewSheet.OrderBy(x => x.SheetNumber);
            listViewSheet = vps.ToList();

            return listViewSheet;
        }

        public string CreateNumberSheet(string sheetNumber,ref bool isBegin)
        {
           
            string sheetNumberResult = null;
            int lengthNumber = sheetNumber.Length;
            string start = Regex.Replace(sheetNumber, @"[\d-]", string.Empty);
            int end = int.Parse(Regex.Match(sheetNumber, @"\d+").Value);
            if (isBegin==false)
            {
                end = end + 1;
            }                    
            int countEnd = end.ToString().Length;
            sheetNumberResult = sheetNumber.Remove(lengthNumber - countEnd) + end.ToString();
            return sheetNumberResult;
        }

        public string GetName()
        {
            return "ChangeSheetNumber";
        }

    }
}
