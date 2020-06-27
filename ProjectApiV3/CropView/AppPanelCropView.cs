
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ProjectApiV3.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectApiV3.CropView
{
    public static class AppPanelCropView
    {
        public static wfpCropView myFormCropView;
        public static List<string> listAllCrops;
        public static int ChooseButton;
        public static void ShowFromCropView()
        {
            listAllCrops = new List<string>();
            CropViewHandler cropHandler = new CropViewHandler();
            ExternalEvent cropEvent = ExternalEvent.Create(cropHandler);
            AddViewHandler addViewHandler = new AddViewHandler();
            ExternalEvent addViewEvent = ExternalEvent.Create(addViewHandler);
            myFormCropView = new wfpCropView(cropEvent, cropHandler,addViewEvent,addViewHandler);
            myFormCropView.Show();
        }
    }
}