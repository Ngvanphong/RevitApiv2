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
        private UpdateValueParameterWpfHandler _updateValueParameter;
        private ExternalEvent _updateValueEvent;
        public wpfFilteredElement(ExternalEvent eventMain,FilteredWpfHandler handlerMain,ExternalEvent categoryEvent,CategoryCheckedWpfHandler categoryHandler,
            ExternalEvent typeNameEvent, TypeNameCheckedWpfHandler typeNameCheckedHandler, ExternalEvent parameterEvent, ParameterTypeCheckedWpfHandler parameterHandler,
            ExternalEvent updateValueEvent, UpdateValueParameterWpfHandler updateValueParameter)
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
            _updateValueEvent = updateValueEvent;
            _updateValueParameter = updateValueParameter;
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

        private void CategoryNone(object sender, RoutedEventArgs e)
        {
            AppPanelFilterWpf.myFormFilterElement.listViewCategory.SelectedValue = null ;
        }

        private void CategoryAll(object sender, RoutedEventArgs e)
        {
            AppPanelFilterWpf.myFormFilterElement.listViewCategory.SelectAll();
        }

        private void CategorySelect(object sender, RoutedEventArgs e)
        {
            AppPanelFilterWpf.numberButtonClick = 0;
            _event.Raise();
        }

        private void ElementTypeNone(object sender, RoutedEventArgs e)
        {
            AppPanelFilterWpf.myFormFilterElement.listViewElementType.SelectedValue = null;
        }

        private void ElementTypeAll(object sender, RoutedEventArgs e)
        {
            AppPanelFilterWpf.myFormFilterElement.listViewElementType.SelectAll();
        }

        private void ElementTypeSelect(object sender, RoutedEventArgs e)
        {
            AppPanelFilterWpf.numberButtonClick = 1;
            _event.Raise();
        }

        private void ParameterNone(object sender, RoutedEventArgs e)
        {
            AppPanelFilterWpf.myFormFilterElement.listViewParameter.SelectedValue = null;
        }

        private void ValueTypeNone(object sender, RoutedEventArgs e)
        {
            AppPanelFilterWpf.myFormFilterElement.listViewValueParameter.SelectedValue = null;
        }

        private void UpdateValue(object sender, RoutedEventArgs e)
        {
            _updateValueEvent.Raise();
        }

        private void ValueSelect(object sender, RoutedEventArgs e)
        {
            AppPanelFilterWpf.numberButtonClick = 2;
            _event.Raise();
        }
    }
}
