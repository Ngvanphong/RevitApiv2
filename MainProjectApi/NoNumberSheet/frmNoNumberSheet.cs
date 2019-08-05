using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace MainProjectApi.NoNumberSheet
{
    public partial class frmNoNumberSheet : Form
    {
        private ExternalEvent _myEvent;
        private NoNumberSheetHandler _handler;
        public frmNoNumberSheet(ExternalEvent myEvent, NoNumberSheetHandler handler)
        {
            InitializeComponent();
            _myEvent = myEvent;
            _handler = handler;
        }

        private void frmNoNumberSheet_Load(object sender, EventArgs e)
        {

        }

        private void btnStartNoNumber_Click(object sender, EventArgs e)
        {
            _myEvent.Raise();
        }
    }
}
