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
namespace ProjectApiV3.CropView
{
    public static class AppPanelCropView
    {
        public static frmCropView myFormCropView;
        public static void ShowFromCropView()
        {
            CropViewHandler cropHandler = new CropViewHandler();
            ExternalEvent cropEvent = ExternalEvent.Create(cropHandler);
            myFormCropView = new frmCropView(cropEvent, cropHandler);
            myFormCropView.Show();
        }
    }
}
