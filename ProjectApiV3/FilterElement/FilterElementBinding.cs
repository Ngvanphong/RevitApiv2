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
            var collector = new FilteredElementCollector(doc, doc.ActiveView.Id).ToElements();
            //get distinct categories of elements in the active view
            List<Category> categories = new List<Category>();
            foreach(Element ele in collector)
            {
                try
                {
                    Category cate = null;
                    cate = ele.Category;
                    if (cate != null)
                    {
                        if (!categories.Exists(x => x.Name == cate.Name))
                        {
                            categories.Add(cate);
                        }                       
                    }
                }
                catch { continue; }
            }
               
            foreach (var cate in categories.OrderBy(x=>x.Name))
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
