using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ProjectApiV3.FilterElement
{
    public class TypeNameCheckedHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            var listTypeChecked = AppPanelFilterElement.myFormFilterElement.listViewTypeName.CheckedItems;
            List<ElementType> elementTypeSelect = new List<ElementType>();
            foreach (ListViewItem item in listTypeChecked)
            {
                string[] typeFa = item.Text.Split('/');
                string fami = typeFa[0];
                string nameType = typeFa[1];
                foreach (var type in AppPanelFilterElement.listTypeOfCategory)
                {
                    if (type.Name == nameType && type.FamilyName == fami)
                    {
                        elementTypeSelect.Add(type);
                    }
                }
            }
            AppPanelFilterElement.listElementTypeChecked = elementTypeSelect;
            AppPanelFilterElement.myFormFilterElement.listViewParameter.Items.Clear();
            List<string> nameParameteres = new List<string>();
            foreach (var typeSelect in elementTypeSelect)
            {
                var parameteres = typeSelect.Parameters;
                foreach (Parameter para in parameteres)
                {
                    string namePa = para.Definition.Name;
                    if (!nameParameteres.Exists(x => x == namePa))
                    {
                        nameParameteres.Add(namePa);
                    }
                }
            }
            foreach (var nameP in nameParameteres.OrderBy(x => x))
            {
                var name = nameP;
                var row = new string[] { name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelFilterElement.myFormFilterElement.listViewParameter.Items.Add(lvi);
            }
        }

        public string GetName()
        {
            return "TypeNameChecked";
        }
    }
}
