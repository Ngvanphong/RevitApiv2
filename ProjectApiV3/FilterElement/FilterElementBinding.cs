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
            //Create collector to collect all elements on active view
            FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);               
            //get distinct categories of elements in the active view
            var categories =collector.ToElements().Select(x => x.Category).Distinct(new CategoryComparer()).OrderBy(x=>x.Name).ToList();      
            foreach (var cate in categories)
            {
                var name = cate.Name;
                var row = new string[] {name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelFilterElement.myFormFilterElement.listViewCategory.Items.Add(lvi);
            }
        }
    }
    class CategoryComparer : IEqualityComparer<Category>
    {
        #region Implementation of IEqualityComparer<in Category>

        public bool Equals(Category x, Category y)
        {
            if (x == null || y == null) return false;

            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Category obj)
        {
            return obj.Id.IntegerValue;
        }

        #endregion
    }
}
