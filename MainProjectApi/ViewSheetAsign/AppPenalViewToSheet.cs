using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Collections.ObjectModel;

namespace MainProjectApi.ViewSheetAsign
{
   public static class AppPenalViewToSheet
    {
        public static ObservableCollection<ViewInotify> AllViewAssigns;
        public static ViewToSheetWpf myFormViewToSheet;
        public static int ChooseButtonClick;
        public static View ViewOrigin;
        public static void ShowViewToSheet()
        {
            AllViewAssigns = new ObservableCollection<ViewInotify>();
            ViewOrigin = null;
            ViewToSheetHandler handlerViewToSheet = new ViewToSheetHandler();
            ExternalEvent eventViewToSheet = ExternalEvent.Create(handlerViewToSheet);
            AddViewHandler handlerAddView = new AddViewHandler();
            ExternalEvent eventAddView = ExternalEvent.Create(handlerAddView);
            myFormViewToSheet = new ViewToSheetWpf(eventViewToSheet, handlerViewToSheet,eventAddView,handlerAddView);
            myFormViewToSheet.Show();
        }
    }
}
