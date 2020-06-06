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
   public class NoNumberSheetButton
    {
        public void CreateNoNumber(UIControlledApplication application)
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
            Image img = MainProjectApi.Properties.Resources.sort_by_numeric_order;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("No.Sheets", "No.Sheets",
                Assembly.GetExecutingAssembly().Location, "MainProjectApi.NoNumberSheet.NoNumberSheetBinding")
            {
                ToolTip = "Create number for sheet",
                LongDescription = "Create number for sheet",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;
        }
    }
}
