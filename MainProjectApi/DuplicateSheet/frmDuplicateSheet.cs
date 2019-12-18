using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProjectApi.DuplicateSheet
{
    public partial class frmDuplicateSheet : Form
    {
        private ExternalEvent _myEvent;
        private DuplicateSheetHandler _handler;
        public frmDuplicateSheet(ExternalEvent myEvent, DuplicateSheetHandler handler)
        {
            InitializeComponent();
            _myEvent = myEvent;
            _handler = handler;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmDuplicateSheet_Load(object sender, EventArgs e)
        {

        }

        private void btnStartDuplicate_Click(object sender, EventArgs e)
        {
            _myEvent.Raise();
        }

        private void radioButtonDuplicatewithdetailing_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
