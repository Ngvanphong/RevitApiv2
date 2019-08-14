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
using ProjectApiV3.Helper;

namespace ProjectApiV3.FilterElement
{
    public partial class frmFilerElement : System.Windows.Forms.Form
    {
        private ExternalEvent _event;
        private FilterElementHandler _handler;
        private ExternalEvent _eventCategory;
        private CategoryCheckedHandler _handlerCategory;
        private ExternalEvent _eventTypeName;
        private TypeNameCheckedHandler _handlerTypeName;
        private ExternalEvent _eventParameterType;
        private ParameterTypeCheckedHandler _handlerParameterType;
        public frmFilerElement(ExternalEvent myevent, FilterElementHandler handler, ExternalEvent eventCategory,
            CategoryCheckedHandler handlerCategory, ExternalEvent eventTypeName, TypeNameCheckedHandler handlerTypeName,
            ExternalEvent eventParameterType, ParameterTypeCheckedHandler handlerParameterType)
        {
            InitializeComponent();
            _event = myevent;
            _handler = handler;
            _eventCategory = eventCategory;
            _handlerCategory = handlerCategory;
            _eventTypeName = eventTypeName;
            _handlerTypeName = handlerTypeName;
            _eventParameterType = eventParameterType;
            _handlerParameterType = handlerParameterType;
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
                _eventCategory.Raise();
            }
        }



        private void listViewTypeName_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var listTypeChecked = AppPanelFilterElement.myFormFilterElement.listViewTypeName.CheckedItems;
            if (listTypeChecked.Count > 0)
            {
                _eventTypeName.Raise();
            }
        }

        private void listViewParameter_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var parameterChecked = AppPanelFilterElement.myFormFilterElement.listViewParameter.CheckedItems;
            if (parameterChecked.Count > 0)
            {
                _eventParameterType.Raise();
            }

        }
    }
}
