using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using ProjectApiV3.Helper;

namespace ProjectApiV3.RevisionCloud
{
    [Transaction(TransactionMode.Manual)]
    public class RevisionCloudBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPanelRevisionCloud.ShowFormRevisionCloud();
                GetInforRevisionCloud.GetInforRevionCloud(doc);
                GetInforRevisionCloud.GetInforChoice(doc);
            }
            return Result.Succeeded;
        }

    }

    public class GetInforRevisionCloud
    {
        public static void GetInforRevionCloud(Document doc)
        {
            var revisionClouds = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.RevisionCloud)).Cast<Autodesk.Revit.DB.RevisionCloud>().ToList();
            List<RevisionInfor> listCloud = new List<RevisionInfor>();
            foreach (var cloud in revisionClouds)
            {
                Autodesk.Revit.DB.Revision revision = doc.GetElement(cloud.RevisionId) as Autodesk.Revit.DB.Revision;
                string revisionNumber = revision.Name;
                string revisionDate = revision.RevisionDate.ToString();
                string issuedBy = revision.IssuedBy.ToString();
                string issuedTo = revision.IssuedTo.ToString();
                Parameter para = cloud.LookupParameter("Comments");
                string comments = para.AsString();
                Parameter paraMark = cloud.LookupParameter("Mark");
                string mark = paraMark.AsString();
                string sheetName = string.Empty;
                string sheetNumber = string.Empty;
                try
                {
                    var sheetIds = cloud.GetSheetIds();
                    if (sheetIds.Count() == 0)
                    {
                        RevisionInfor infor = new RevisionInfor(cloud.Id,revisionNumber, revisionDate, issuedBy, issuedTo, sheetNumber, sheetName, comments, mark);
                        listCloud.Add(infor);
                    }
                    else
                    {
                        foreach (var id in sheetIds)
                        {
                            ViewSheet sheet = doc.GetElement(id) as ViewSheet;
                            sheetName = sheet.Name;
                            sheetNumber = sheet.SheetNumber;
                            RevisionInfor infor = new RevisionInfor(cloud.Id,revisionNumber, revisionDate, issuedBy, issuedTo, sheetNumber, sheetName, comments, mark);
                            listCloud.Add(infor);
                        }
                    }
                    

                }
                catch
                {
                    RevisionInfor infor = new RevisionInfor(cloud.Id,revisionNumber, revisionDate, issuedBy, issuedTo, sheetNumber, sheetName, comments, mark);
                    listCloud.Add(infor);
                }
            }
            foreach (var item in listCloud.OrderBy(x=>x.RevisionNumber))
            {

                var row = new string[] { item.RevisionNumber,item.RevisionDate,item.IssuedBy,item.IssuedTo,item.SheetNumber,item.SheetName,item.Comments,item.Mark,item.Id.ToString()};
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelRevisionCloud.myFormRevisionCloud.listViewRevisionCloud.Items.Add(lvi);
            }

        }
        public static void GetInforChoice(Document doc)
        {
            List<string> listChoice = new List<string>()
            {
               "All",
               "Cloud revision have on sheet",
               "Cloud revision haven't on sheet",
            };
            foreach (var item in listChoice)
            {    
                AppPanelRevisionCloud.myFormRevisionCloud.dropChooseFilterCloud.Items.Add(item);
            }
        }
    }
    public class RevisionInfor
    {
        public RevisionInfor()
        {

        }
        public RevisionInfor(ElementId id,string revisionNumber, string revisionDate, string issuedBy, string issuedTo,
            string sheetNumber, string sheetName, string comments, string mark)
        {
            Id = id;
            RevisionNumber = revisionNumber;
            RevisionDate = revisionDate;
            IssuedBy = issuedBy;
            IssuedTo = issuedTo;
            SheetNumber = sheetNumber;
            SheetName = sheetName;
            Comments = comments;
            Mark = mark;
        }
        public ElementId Id { set; get; }
        public string RevisionNumber { set; get; }
        public string RevisionDate { get; set; }
        public string IssuedBy { set; get; }
        public string IssuedTo { get; set; }
        public string SheetNumber { set; get; }
        public string SheetName { get; set; }
        public string Comments { set; get; }
        public string Mark { get; set; }
    }


}
