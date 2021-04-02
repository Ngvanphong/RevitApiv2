using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.UI;
namespace ProjectApiV3.FilterElementWpf
{
    /// <summary>
    /// Interaction logic for wpfFilteredElement.xaml
    /// </summary>
    public partial class wpfFilteredElement : Window
    {
        private FilteredWpfHandler _handler;
        private ExternalEvent _event;
        private CategoryCheckedWpfHandler _categoryHandler;
        private ExternalEvent _categoryEvent;
        public wpfFilteredElement(ExternalEvent eventMain,FilteredWpfHandler handlerMain,ExternalEvent categoryEvent,CategoryCheckedWpfHandler categoryHandler)
        {
            new MaterialDesignColors.SwatchesProvider();
            new MaterialDesignThemes.Wpf.Card();
            InitializeComponent();
            _handler = handlerMain;
            _event = eventMain;
            _categoryEvent = categoryEvent;
            _categoryHandler = categoryHandler;
        }

        private void ChangeSelectedCategory(object sender, SelectionChangedEventArgs e)
        {

            var listCategoryChecked = AppPanelFilterWpf.myFormFilterElement.listViewCategory.SelectedItems;

            if (listCategoryChecked.Count > 0)
            {
               _categoryEvent.Raise();
            }
        }
    }
}
