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
        private TypeNameCheckedWpfHandler _typeNameCheckedHandler;
        private ExternalEvent _typeNameEvent;
        private ParameterTypeCheckedWpfHandler _parameterHandler;
        private ExternalEvent _parameterEvent;
        public wpfFilteredElement(ExternalEvent eventMain,FilteredWpfHandler handlerMain,ExternalEvent categoryEvent,CategoryCheckedWpfHandler categoryHandler,
            ExternalEvent typeNameEvent, TypeNameCheckedWpfHandler typeNameCheckedHandler, ExternalEvent parameterEvent, ParameterTypeCheckedWpfHandler parameterHandler)
        {
            new MaterialDesignColors.SwatchesProvider();
            new MaterialDesignThemes.Wpf.Card();
            InitializeComponent();
            _handler = handlerMain;
            _event = eventMain;
            _categoryEvent = categoryEvent;
            _categoryHandler = categoryHandler;
            _typeNameEvent = typeNameEvent;
            _typeNameCheckedHandler = typeNameCheckedHandler;
            _parameterHandler = parameterHandler;
            _parameterEvent = parameterEvent;
        }

        private void ChangeSelectedCategory(object sender, SelectionChangedEventArgs e)
        {

            var listCategoryChecked = AppPanelFilterWpf.myFormFilterElement.listViewCategory.SelectedItems;
            if (listCategoryChecked.Count > 0)
            {
               _categoryEvent.Raise();
            }
        }

        private void ElementTypeChangeSelection(object sender, SelectionChangedEventArgs e)
        {
            var listTypeChecked = AppPanelFilterWpf.myFormFilterElement.listViewElementType.SelectedItems;
            if (listTypeChecked.Count > 0)
            {
                _typeNameEvent.Raise();
            }
        }

        private void ParameterChangeValue(object sender, SelectionChangedEventArgs e)
        {
            var listParameterChecked = AppPanelFilterWpf.myFormFilterElement.listViewParameter.SelectedItems;
            if (listParameterChecked.Count > 0)
            {
                _parameterEvent.Raise();
            }
        }
    }
}
