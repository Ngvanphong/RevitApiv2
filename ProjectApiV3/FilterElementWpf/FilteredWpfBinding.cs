using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;

namespace ProjectApiV3.FilterElementWpf
{
    [Transaction(TransactionMode.Manual)]
    public class FilteredWpfBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            AppPanelFilterWpf.ShowFormFilterElement();
            CategoryInfor(doc);
            return Result.Succeeded;
        }

        public void CategoryInfor(Document doc)
        {
            var collector = new FilteredElementCollector(doc, doc.ActiveView.Id).ToElements();
            List<Category> categories = new List<Category>();
            foreach (Element ele in collector)
            {
                try
                {
                    Category cate = null;
                    cate = ele.Category;
                    if (cate != null)
                    {
                        if (!categories.Exists(x => x.Id == cate.Id))
                        {
                            categories.Add(cate);
                        }
                    }
                }
                catch { continue; }
            }
            AppPanelFilterWpf.myFormFilterElement.listViewCategory.Items.Clear();
            foreach (var cate in categories.OrderBy(x => x.Name))
            {
                CategoryUser cateUser = new CategoryUser(cate);
                AppPanelFilterWpf.myFormFilterElement.listViewCategory.Items.Add(cateUser);
            }
        }
    }
}
