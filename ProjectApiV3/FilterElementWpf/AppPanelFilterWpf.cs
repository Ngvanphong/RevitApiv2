using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ProjectApiV3.FilterElementWpf
{
   
    public static class AppPanelFilterWpf
    {
        public static wpfFilteredElement myFormFilterElement;
        public static int numberButtonClick;
        public static ObservableCollection<CategoryType> listTypeOfCategory = new ObservableCollection<CategoryType>();
        public static ObservableCollection<ParameterUser> listParameter = new ObservableCollection<ParameterUser>();
        public static List<Element> listElementName = new List<Element>();
        public static void ShowFormFilterElement()
        {
            FilteredWpfHandler handler = new FilteredWpfHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);

            CategoryCheckedWpfHandler _handlerCategory = new CategoryCheckedWpfHandler();
            ExternalEvent _eventCategory = ExternalEvent.Create(_handlerCategory);

            //TypeNameCheckedHandler _handlerTypeName = new TypeNameCheckedHandler();
            //ExternalEvent _eventTypeName = ExternalEvent.Create(_handlerTypeName);

            //ParameterTypeCheckedHandler _handlerParameterType = new ParameterTypeCheckedHandler();
            //ExternalEvent _eventParameterType = ExternalEvent.Create(_handlerParameterType);

            //UpdateValueParameterHandler _updateValueParameter = new UpdateValueParameterHandler();
            //ExternalEvent _eventValueParameter = ExternalEvent.Create(_updateValueParameter);

            myFormFilterElement = new wpfFilteredElement(myEvent, handler, _eventCategory, _handlerCategory);
            myFormFilterElement.Show();

        }
    }
}
