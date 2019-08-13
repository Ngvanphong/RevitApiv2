using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProjectApiV3.FilterElement
{
    public class FilterElementHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
           
        }

        public string GetName()
        {
            return "FilterElement";
        }
    }
}
