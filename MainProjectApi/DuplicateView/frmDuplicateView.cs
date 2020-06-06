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
namespace MainProjectApi.DuplicateView
{
    public partial class frmDuplicateView : Form
    {
        private DuplicateViewHandler _handlerDuplicateView;
        private ExternalEvent _eventDuplicate;
        public frmDuplicateView(ExternalEvent eventDuplicate, DuplicateViewHandler handlerDuplicateView)
        {
            InitializeComponent();
            _handlerDuplicateView = handlerDuplicateView;
            _eventDuplicate = eventDuplicate;
        }

        private void btnDuplicateView_Click(object sender, EventArgs e)
        {
            _eventDuplicate.Raise();
        }
    }
}
