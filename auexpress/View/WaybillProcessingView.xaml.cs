using auexpress.ViewModel;
using System;
using System.Collections.Generic;
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
    /// WaybillProcessingView.xaml 的交互逻辑
    /// </summary>
    public partial class WaybillProcessingView : Page
    {

        private WaybillProcessingViewModel waybillProcessingViewModel = new WaybillProcessingViewModel();
        public WaybillProcessingView()
        {
            InitializeComponent();
            this.DataContext = waybillProcessingViewModel;
            waybillProcessingViewModel.EditShow += new WaybillProcessingViewModel.EditEventDelegate(ShowEdit);
        }

        public void ShowEdit() {

            EditExpress edit = new EditExpress();
            edit.ShowDialog();
        }

    }
}
