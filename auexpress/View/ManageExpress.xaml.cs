using auexpress.model;
using auexpress.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace auexpress.View
{
    /// <summary>
    /// ManageExpress.xaml 的交互逻辑
    /// </summary>
    public partial class ManageExpress : Page
    {

        private ManageExpressViewModel manageExpressViewModel = new ManageExpressViewModel();

        public ManageExpress()
        {
            InitializeComponent();
            this.DataContext = manageExpressViewModel;
            this.manageExpressViewModel.ShowAddSmsBatchEvent += new ManageExpressViewModel.ShowAddSmsBatchDelegate(AddWindow);
        }

        private void AddWindow() {
            AddSmsBatch addSmsBatch = new AddSmsBatch();
            addSmsBatch.ChangeTextEvent += new ChangeText(loadView);
            addSmsBatch.ShowDialog();
        }

        private void loadView() {

            manageExpressViewModel.RefreshView();
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            var mySelectedElement = exlist.SelectedItem as ManageExpressMenuItemViewModel;
            Int64 result = mySelectedElement.SmsBatch.id;
            AppGlobal.SmsBatchId = result;
            WaybillArchive waybillArchive = new WaybillArchive(); 
            waybillArchive.ShowDialog(); 
        }
    }
}
