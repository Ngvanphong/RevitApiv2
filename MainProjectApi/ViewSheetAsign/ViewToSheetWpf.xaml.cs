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

namespace MainProjectApi.ViewSheetAsign
{
    /// <summary>
    /// Interaction logic for ViewToSheetWpf.xaml
    /// </summary>
    public partial class ViewToSheetWpf : Window
    {
        private ViewToSheetHandler _handlerViewToSheet;
        private ExternalEvent _eventViewToSheet;
        private AddViewHandler _handlerAddView;
        private ExternalEvent _eventAddView;
        public ViewToSheetWpf(ExternalEvent eventViewToSheet, ViewToSheetHandler handlerViewToSheet,
            ExternalEvent eventAddView, AddViewHandler handlerAddView)
        {
            new MaterialDesignColors.SwatchesProvider();
            new MaterialDesignThemes.Wpf.Card();
            InitializeComponent();
            Topmost = true;
            
            _eventViewToSheet = eventViewToSheet;
            _handlerViewToSheet = handlerViewToSheet;
            _eventAddView = eventAddView;
            _handlerAddView = handlerAddView;
        }

        private void btnAddView(object sender, RoutedEventArgs e)
        {
            AppPenalViewToSheet.ChooseButtonClick = 1;
            _eventAddView.Raise();
        }

        private void btnAssignView(object sender, RoutedEventArgs e)
        {
            _eventViewToSheet.Raise();
        }

        private void btnDownView(object sender, RoutedEventArgs e)
        {
            AppPenalViewToSheet.ChooseButtonClick = 2;
            _eventAddView.Raise();
        }

        private void btnUpView(object sender, RoutedEventArgs e)
        {
            AppPenalViewToSheet.ChooseButtonClick = 3;
            _eventAddView.Raise();
        }

        private void btnRemoveView(object sender, RoutedEventArgs e)
        {
            AppPenalViewToSheet.ChooseButtonClick = 4;
            _eventAddView.Raise();
        }

        private void btnAddViewOrigin(object sender, RoutedEventArgs e)
        {
            AppPenalViewToSheet.ChooseButtonClick = 5;
            _eventAddView.Raise();
        }
    }
}
