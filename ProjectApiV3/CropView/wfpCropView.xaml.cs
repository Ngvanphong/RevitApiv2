using Autodesk.Revit.UI;
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

namespace ProjectApiV3.CropView
{
    /// <summary>
    /// Interaction logic for wfpCropView.xaml
    /// </summary>
    ///
    public partial class wfpCropView : Window
    {
        private CropViewHandler _cropHandler;
        private ExternalEvent _cropEvent;
        private AddViewHandler _addViewHandler;
        private ExternalEvent _addViewEvent;

        public wfpCropView(ExternalEvent cropEvent, CropViewHandler cropHandler, ExternalEvent addViewEvent, AddViewHandler addViewHandler)
        {
            new MaterialDesignColors.SwatchesProvider();
            new MaterialDesignThemes.Wpf.Card();
            InitializeComponent();
            Topmost = true;
            _cropEvent = cropEvent;
            _cropHandler = cropHandler;
            _addViewHandler = addViewHandler;
            _addViewEvent = addViewEvent;
        }

        private void btnAddViewCrop(object sender, RoutedEventArgs e)
        {
            AppPanelCropView.ChooseButton = 1;
            _addViewEvent.Raise();
        }

        private void btnViewExample(object sender, RoutedEventArgs e)
        {
            AppPanelCropView.ChooseButton = 3;
            _addViewEvent.Raise();
        }

        private void btnRemoveView(object sender, RoutedEventArgs e)
        {
            AppPanelCropView.ChooseButton = 2;
            _addViewEvent.Raise();
        }

        private void btnCropView(object sender, RoutedEventArgs e)
        {
            _cropEvent.Raise();
        }
    }
}