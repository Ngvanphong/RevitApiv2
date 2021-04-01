using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace MainProjectApi.DuplicateView
{
  public static  class AppPenalDuplicateView
    {
        public static frmDuplicateView myFormDuplicateView;
        public static void ShowDuplicateForm()
        {
            DuplicateViewHandler handlerDuplicateView = new DuplicateViewHandler();
            ExternalEvent eventDuplicteView = ExternalEvent.Create(handlerDuplicateView);
            myFormDuplicateView = new frmDuplicateView(eventDuplicteView, handlerDuplicateView);
            myFormDuplicateView.Show();
        }
    }
}
