using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using System.Drawing;
using System.Windows.Media;
using System.Reflection;

namespace MainProjectApi.Button
{
   public class AssignViewButton
    {
        public void CreateAssignView(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn";
            const string ribbonPanel = "View&Sheet";
            try
            {
                application.CreateRibbonTab(ribbonTag);
            }
            catch (Exception ex) { }
            RibbonPanel panel = null;
            List<RibbonPanel> panels = application.GetRibbonPanels(ribbonTag);
            foreach (RibbonPanel pl in panels)
            {
                if (pl.Name == ribbonPanel)
                {
                    panel = pl;
                    break;
                }
            }
            if (panel == null)
            {
                panel = application.CreateRibbonPanel(ribbonTag, ribbonPanel);
            }


            Image img = MainProjectApi.Properties.Resources.iconfinder_62_62719;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("AssignView", "ViewSheet",
                Assembly.GetExecutingAssembly().Location, "MainProjectApi.AssignView.AssignViewBinding")
            {
                ToolTip = "Assign view to sheet",
                LongDescription = "Assign view to sheet",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            Image img2 = MainProjectApi.Properties.Resources.rename;
            ImageSource imgSrc2 = Helper.Extension.GetImageSource(img2);
            PushButtonData btnData2 = new PushButtonData("SheetNumber", "SheetNumber",
                Assembly.GetExecutingAssembly().Location, "MainProjectApi.ChangeSheetNumber.ChangeSheetNumberBinding")
            {
                ToolTip = "Rename sheet number",
                LongDescription = "Rename sheet number",
                Image = imgSrc2,
                LargeImage = imgSrc2,
            };

            Image img3 = MainProjectApi.Properties.Resources.insurance;
            ImageSource imgSrc3 = Helper.Extension.GetImageSource(img3);
            PushButtonData btnData3 = new PushButtonData("DuplicateSheet", "DuplicateSheet",
                Assembly.GetExecutingAssembly().Location, "MainProjectApi.DuplicateSheet.DuplicateSheetBinding")
            {
                ToolTip = "Duplicate sheet",
                LongDescription = "Duplicate sheet",
                Image = imgSrc3,
                LargeImage = imgSrc3,
            };

            Image img4 = MainProjectApi.Properties.Resources.Copy;
            ImageSource imgSrc4 = Helper.Extension.GetImageSource(img4);
            PushButtonData btnData4 = new PushButtonData("AssignLegend", "LegendSheet",
                Assembly.GetExecutingAssembly().Location, "MainProjectApi.LegendSheet.LegendToSheetBinding")
            {
                ToolTip = "Assign legend to sheet",
                LongDescription = "Assign legend to sheet",
                Image = imgSrc4,
                LargeImage = imgSrc4,
            };

            Image img5 = MainProjectApi.Properties.Resources.sort_by_numeric_order;
            ImageSource imgSrc5 = Helper.Extension.GetImageSource(img5);
            PushButtonData btnData5 = new PushButtonData("No.Sheets", "No.Sheets",
                Assembly.GetExecutingAssembly().Location, "MainProjectApi.NoNumberSheet.NoNumberSheetBinding")
            {
                ToolTip = "Create number for sheet",
                LongDescription = "Create number for sheet",
                Image = imgSrc5,
                LargeImage = imgSrc5,
            };

            Image img6 = MainProjectApi.Properties.Resources.icons8_duplicate_32;
            ImageSource imgSrc6 = Helper.Extension.GetImageSource(img6);
            PushButtonData btnData6 = new PushButtonData("DuplicateView", "DuplicateView",
                Assembly.GetExecutingAssembly().Location, "MainProjectApi.DuplicateView.DuplicateViewBinding")
            {
                ToolTip = "Duplicate for view",
                LongDescription = "Duplicate for view",
                Image = imgSrc6,
                LargeImage = imgSrc6,
            };

            Image img7 = MainProjectApi.Properties.Resources.icons8_email_document_32;
            ImageSource imgSrc7 = Helper.Extension.GetImageSource(img7);
            PushButtonData btnData7 = new PushButtonData("ViewToSheet", "ViewToSheet",
                Assembly.GetExecutingAssembly().Location, "MainProjectApi.ViewSheetAsign.ViewToSheetBinding")
            {
                ToolTip = "Assign view to sheet",
                LongDescription = "Assign view to sheet",
                Image = imgSrc7,
                LargeImage = imgSrc7,
            };

            SplitButtonData splitData = new SplitButtonData("ViewSheets", "ViewSheets");
            SplitButton splitButton = panel.AddItem(splitData) as SplitButton;
            splitButton.IsSynchronizedWithCurrentItem = true;
            splitButton.AddPushButton(btnData);
            splitButton.AddPushButton(btnData2);
            splitButton.AddPushButton(btnData3);
            splitButton.AddPushButton(btnData4);
            splitButton.AddPushButton(btnData5);
            splitButton.AddPushButton(btnData6);
            splitButton.AddPushButton(btnData7);
        }

    }
}
