using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Threading;
using ProjectApiV3.Helper;
using System.IO;
using System.Windows.Forms;
namespace ProjectApiV3.FilterElement
{
   public static class AppPanelFilterElement
    {
        public static frmFilerElement myFormFilterElement;
        public static int numberButtonClick;
        public static List<ElementType> listTypeOfCategory = new List<ElementType>();
        public static List<ElementType> listElementTypeChecked = new List<ElementType>();
        public static List<Category> listCategoryChecked = new List<Category>();
        public static List<Parameter> listParameterChecked = new List<Parameter>();
        public static List<Element> listElementCategory = new List<Element>();
        public static List<Element> listElementTypeName = new List<Element>();
        public static List<Element> listElementParameter = new List<Element>();

        public static void ShowFormFilterElement()
        {
            FilterElementHandler handler = new FilterElementHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);         
            
            CategoryCheckedHandler _handlerCategory= new CategoryCheckedHandler();
            ExternalEvent _eventCategory= ExternalEvent.Create(_handlerCategory);
            
            TypeNameCheckedHandler _handlerTypeName= new TypeNameCheckedHandler();
            ExternalEvent _eventTypeName= ExternalEvent.Create(_handlerTypeName);
           
            ParameterTypeCheckedHandler _handlerParameterType= new ParameterTypeCheckedHandler();
            ExternalEvent _eventParameterType= ExternalEvent.Create(_handlerParameterType);

            myFormFilterElement = new frmFilerElement(myEvent, handler,_eventCategory,_handlerCategory,_eventTypeName,_handlerTypeName,_eventParameterType,_handlerParameterType);
            myFormFilterElement.Show();

        }

    }
}
