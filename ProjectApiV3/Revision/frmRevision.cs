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
using ProjectApiV3.Helper;
namespace ProjectApiV3.Revision
{
    public partial class frmRevision : Form
    {
        private RevisionHandler _revisionHandler;
        private ExternalEvent _myEvent;
        public frmRevision(ExternalEvent myEvent, RevisionHandler revisionHandler)
        {
            InitializeComponent();
            _myEvent = myEvent;
            _revisionHandler = revisionHandler;
        }

        private void frmRevision_Load(object sender, EventArgs e)
        {

        }
    }
}
