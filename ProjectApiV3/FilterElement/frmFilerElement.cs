using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;

namespace ProjectApiV3.FilterElement
{
    public partial class frmFilerElement : System.Windows.Forms.Form
    {
        private ExternalEvent _event;
        private FilterElementHandler _handler;
        List<ElementType> listTypeOfCategory = new List<ElementType>();
        public frmFilerElement(ExternalEvent myevent, FilterElementHandler handler)
        {
            InitializeComponent();
            _event = myevent;
            _handler = handler;
        }

        private void frmFilerElement_Load(object sender, EventArgs e)
        {

        }

        private void btnFilterElement_Click(object sender, EventArgs e)
        {
            AppPanelFilterElement.numberButtonClick = 0;
            _event.Raise();
        }

        private void btnFilterElement1_Click(object sender, EventArgs e)
        {
            AppPanelFilterElement.numberButtonClick = 1;
            _event.Raise();
        }

        private void btnFilterElement2_Click(object sender, EventArgs e)
        {
            AppPanelFilterElement.numberButtonClick = 2;
            _event.Raise();
        }

        private void btnFilterElement3_Click(object sender, EventArgs e)
        {
            AppPanelFilterElement.numberButtonClick = 3;
            _event.Raise();
        }

        private void btnFilterElement4_Click(object sender, EventArgs e)
        {
            AppPanelFilterElement.numberButtonClick = 4;
            _event.Raise();
        }

        private void listViewCategory_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            var listCategoryChecked = AppPanelFilterElement.myFormFilterElement.listViewCategory.CheckedItems;
            if (listCategoryChecked.Count > 0)
            {
                var listElementType = new FilteredElementCollector(FilterElementBinding.documentProject).OfClass(typeof(ElementType)).Cast<ElementType>().OrderBy(x => x.Name);
                List<ElementType> listTypeChecked = new List<ElementType>();
                foreach (ListViewItem item in listCategoryChecked)
                {
                    var name = item.Text;
                    foreach (var ty in listElementType)
                    {
                        try
                        {
                            Category category = null;
                            category = ty.Category;
                            if (category != null)
                            {
                                if (name == category.Name)
                                {
                                    listTypeChecked.Add(ty);
                                }
                            }
                        }
                        catch { continue; }

                    }
                }
                ////Load typeName
                AppPanelFilterElement.myFormFilterElement.listViewTypeName.Items.Clear();
                listTypeOfCategory = listTypeChecked;
                foreach (var type in listTypeChecked)
                {
                    var name = type.FamilyName + "/" + type.Name;
                    var row = new string[] { name };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = lvi;
                    AppPanelFilterElement.myFormFilterElement.listViewTypeName.Items.Add(lvi);
                }
            }


        }



        private void listViewTypeName_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var listTypeChecked = AppPanelFilterElement.myFormFilterElement.listViewTypeName.CheckedItems;           
            if (listTypeChecked.Count > 0)
            {
                List<ElementType> elementTypeSelect = new List<ElementType>();           
                foreach (ListViewItem item in listTypeChecked)
                {
                    string[] typeFa = item.Text.Split('/');
                    string fami = typeFa[0];
                    string nameType = typeFa[1];
                    foreach (var type in listTypeOfCategory)
                    {
                        if (type.Name == nameType && type.FamilyName == fami)
                        {
                            elementTypeSelect.Add(type);
                        }
                     }
                }
                AppPanelFilterElement.myFormFilterElement.listViewParameter.Items.Clear();
                List<string> nameParameteres = new List<string>();
                foreach(var typeSelect in elementTypeSelect)
                {
                    var parameteres = typeSelect.Parameters;
                    foreach(Parameter para in parameteres)
                    {
                        string namePa = para.Definition.Name;
                        if (!nameParameteres.Exists(x => x == namePa))
                        {
                            nameParameteres.Add(namePa);
                        }                      
                    }
                }
                foreach (var nameP in nameParameteres.OrderBy(x=>x))
                {
                    var name =nameP;
                    var row = new string[] { name };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = lvi;
                    AppPanelFilterElement.myFormFilterElement.listViewParameter.Items.Add(lvi);
                }

            }
        }

        private void listViewParameter_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //var listTypeChecked = AppPanelFilterElement.myFormFilterElement.listViewParameter.CheckedItems;
            //if (listTypeChecked.Count > 0)
            //{
            //    List<ElementType> elementParameterSelect = new List<ElementType>();
            //    foreach (ListViewItem item in listTypeChecked)
            //    {
            //        string[] typeFa = item.Text.Split('/');
            //        string fami = typeFa[0];
            //        string nameType = typeFa[1];
            //        foreach (var type in listTypeOfCategory)
            //        {
            //            if (type.Name == nameType && type.FamilyName == fami)
            //            {
            //                elementTypeSelect.Add(type);
            //            }
            //        }
            //    }
            //    AppPanelFilterElement.myFormFilterElement.listViewParameter.Items.Clear();
            //    foreach (var type in elementTypeSelect)
            //    {
            //        var name = type.FamilyName + "/" + type.Name;
            //        var row = new string[] { name };
            //        var lvi = new ListViewItem(row);
            //        lvi.Tag = lvi;
            //        AppPanelFilterElement.myFormFilterElement.listViewParameter.Items.Add(lvi);
            //    }

            //}

        }
    }
}
