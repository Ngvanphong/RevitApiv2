using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace MainProjectApi.ViewSheetAsign
{
    public class AddViewHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc =uiDoc.Document;
            var listViewWpf = AppPenalViewToSheet.myFormViewToSheet.FindName("lvViewSelect") as ListView;
           
            if (AppPenalViewToSheet.ChooseButtonClick == 1)
            {
                var idViewChoose = uiDoc.Selection.GetElementIds();              
                foreach(var id in idViewChoose)
                {
                    View viewSelected = doc.GetElement(id) as View;
                    if (viewSelected != null)
                    {
                        ViewInotify viewNotify = new ViewInotify();
                        viewNotify.Name = viewSelected.Name;
                        viewNotify.Id = id.ToString();
                        AppPenalViewToSheet.AllViewAssigns.Add(viewNotify);     
                    }
                }
                listViewWpf.ItemsSource = AppPenalViewToSheet.AllViewAssigns;
            }else if (AppPenalViewToSheet.ChooseButtonClick == 3)
            {
                var selectedIndex = listViewWpf.SelectedIndex;
                if (selectedIndex > 0)
                {
                    var itemToMoveUp = AppPenalViewToSheet.AllViewAssigns[selectedIndex];
                    AppPenalViewToSheet.AllViewAssigns.RemoveAt(selectedIndex);
                    AppPenalViewToSheet.AllViewAssigns.Insert(selectedIndex - 1, itemToMoveUp);
                    listViewWpf.SelectedIndex = selectedIndex - 1;
                }
            } 
            else if (AppPenalViewToSheet.ChooseButtonClick == 2)
            {
                var selectedIndex = listViewWpf.SelectedIndex;
                if (selectedIndex + 1 < AppPenalViewToSheet.AllViewAssigns.Count)
                {
                    var itemToMoveDown = AppPenalViewToSheet.AllViewAssigns[selectedIndex];
                    AppPenalViewToSheet.AllViewAssigns.RemoveAt(selectedIndex);
                    AppPenalViewToSheet.AllViewAssigns.Insert(selectedIndex + 1, itemToMoveDown);
                    listViewWpf.SelectedIndex = selectedIndex + 1;
                }
            }else if (AppPenalViewToSheet.ChooseButtonClick == 4)
            {
                var selectItems = listViewWpf.SelectedItems;
                List<ViewInotify> listRemove = new List<ViewInotify>();
                foreach(var item in selectItems)
                {
                    listRemove.Add(item as ViewInotify);
                }
                foreach(var item in listRemove)
                {
                    AppPenalViewToSheet.AllViewAssigns.Remove(item as ViewInotify);
                }                
            }
            if(AppPenalViewToSheet.ChooseButtonClick == 5)
            {
                var selectId = uiDoc.Selection.GetElementIds();
                if (selectId.Count==0)
                {
                    MessageBox.Show("You must select a view");
                    return;
                }
                foreach(var id in selectId)
                {
                    View view = doc.GetElement(id) as View;
                    if (view != null)
                    {
                        AppPenalViewToSheet.ViewOrigin = view;
                        ViewInotify viewNoti = new ViewInotify();
                        viewNoti.Id = view.Id.ToString();
                        viewNoti.Name = view.Name;
                        var listViewOriginWpf = AppPenalViewToSheet.myFormViewToSheet.FindName("lvViewOrigin") as ListView;
                        listViewOriginWpf.ItemsSource = null;
                        listViewOriginWpf.ItemsSource = new List<ViewInotify> { viewNoti };
                        break;
                    }
                }
            }
        }

        public string GetName()
        {
            return "AddViewSheetHandler";
        }
    }


    public class ViewInotify 
    {
        public string Name { set; get; }
        public string Id { set; get; }
        public override string ToString()
        {
            return Name+ " ID=" + Id;
        }
    }
}
