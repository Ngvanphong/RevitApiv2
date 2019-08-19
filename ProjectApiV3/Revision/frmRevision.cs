﻿using System;
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
        private GetSheetByRevisionHandler _getSheetHandler;
        private ExternalEvent _myGetSheetEvent;
        public frmRevision(ExternalEvent myEvent, RevisionHandler revisionHandler, ExternalEvent myGetSheetEvent, GetSheetByRevisionHandler getSheetHandler)
        {
            InitializeComponent();
            _myEvent = myEvent;
            _revisionHandler = revisionHandler;
            _myGetSheetEvent = myGetSheetEvent;
            _getSheetHandler = getSheetHandler;
        }

        private void frmRevision_Load(object sender, EventArgs e)
        {

        }

        private void listViewRevisionInfor_ItemChecked(object sender, ItemCheckedEventArgs e)
        {         
            var listItem = AppPanelRevision.myFormRevision.listViewRevisionInfor.CheckedItems;
            if (listItem.Count > 0)
            {
                _myGetSheetEvent.Raise();
            }
           
        }
    }
}
