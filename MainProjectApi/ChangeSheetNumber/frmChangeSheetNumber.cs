using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
namespace MainProjectApi.ChangeSheetNumber
{
    public partial class frmChangeSheetNumber : Form
    {
        private ExternalEvent _myEvent;
        private ChangeSheetNumberHandler _handler;
        public frmChangeSheetNumber(ExternalEvent myEvent, ChangeSheetNumberHandler handler)
        {
            InitializeComponent();
            _myEvent = myEvent;
            _handler = handler;

        }

        private void btnChangeSheetNumber_Click(object sender, EventArgs e)
        {
            _myEvent.Raise();
        }
    }
}
