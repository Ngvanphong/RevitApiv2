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

namespace ProjectApiV3.RevisionCloud
{
   public static class AppPanelRevisionCloud
    {
        public static frmRevisionCloud myFormRevisionCloud;
        public static void ShowFormRevisionCloud()
        {            
            ReloadRevisionCloudHandler handlerReloadRevisonCloud = new ReloadRevisionCloudHandler();
            ExternalEvent eventReloadCloud = ExternalEvent.Create(handlerReloadRevisonCloud);
            SelectRevisionCloudHandler handlerSelectRevisionClound = new SelectRevisionCloudHandler();
            ExternalEvent eventSelectCloud = ExternalEvent.Create(handlerSelectRevisionClound);
            myFormRevisionCloud = new frmRevisionCloud(eventReloadCloud,handlerReloadRevisonCloud,eventSelectCloud,handlerSelectRevisionClound);
            myFormRevisionCloud.Show();
        }
    }
}
