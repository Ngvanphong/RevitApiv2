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

namespace ProjectApiV3.DimOffset
{

    public static class AppPanelDimOffset
    {
        public static frmDimOffset myFormDimOffset;
        public static ElevationWatcherUpdater _updater = null;
        public static void ShowFormDimOffset()
        {
            CancelDimOffsetHandler cancelHandler = new CancelDimOffsetHandler();
            ExternalEvent cancelEvent = ExternalEvent.Create(cancelHandler);
            myFormDimOffset = new frmDimOffset(cancelEvent,cancelHandler);
            myFormDimOffset.Show();
        }
    }
}
