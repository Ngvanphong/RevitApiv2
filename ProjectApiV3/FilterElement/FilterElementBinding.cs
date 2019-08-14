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
namespace ProjectApiV3.FilterElement
{
    [Transaction(TransactionMode.Manual)]
    public class FilterElementBinding : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;

            if (CheckAccess.CheckLicense() == true)
            {
                AppPanelFilterElement.ShowFormFilterElement();
                CategoryInfor(doc);               
            }
            return Result.Succeeded;
        }
        public void CategoryInfor(Document doc)
        {
            var listCategories = doc.Settings.Categories.Cast<Category>().OrderBy(x=>x.Name);
            foreach (var cate in listCategories)
            {
                var name = cate.Name;
                var row = new string[] {name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelFilterElement.myFormFilterElement.listViewCategory.Items.Add(lvi);
            }
        }
    }
}
