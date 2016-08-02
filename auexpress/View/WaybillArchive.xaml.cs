using auexpress.model;
using auexpress.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace auexpress.View
{
    /// <summary>
    /// WaybillArchive.xaml 的交互逻辑
    /// </summary>
    public partial class WaybillArchive : MetroWindow
    {

        private WaybillArchiveViewModel waybillArchiveViewModel = new WaybillArchiveViewModel();
        private delegate void UpdateDelegate();  

        public WaybillArchive()
        {
            InitializeComponent();
            this.DataContext = waybillArchiveViewModel;
            this.waybillArchiveViewModel.printEvent += new WaybillArchiveViewModel.printDelegate(showPrint); 
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="serch"></param>
        private void showPrint(string serch) {

            AppGlobal.serch = serch;
            Print print = new Print();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Refresh));
            this.serch.Text = "";
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            var mySelectedElement = exlist.SelectedItem as ExpressMenuItemViewModel;
            Int64 result = mySelectedElement.Express.iid;
            AppGlobal.iid = result;
            AppGlobal.serch = null; 
            Print print = new Print(); 
        }

        private void Refresh(object state)
        {
            Thread.Sleep(3000);
            // UI thread dispatch the event into the event queue Async  
            this.Dispatcher.BeginInvoke(new UpdateDelegate(loadRefresh));

        } 

        private void loadRefresh() {

            waybillArchiveViewModel.refresh();
        }
    }
}
