using auexpress.model;
using auexpress.ViewModel;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace auexpress.View
{
    /// <summary>
    /// WaybillArchive.xaml 的交互逻辑
    /// </summary>
    public partial class WaybillArchive : MetroWindow
    {

        private WaybillArchiveViewModel waybillArchiveViewModel = new WaybillArchiveViewModel();

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
            print.ShowDialog(); 
        }
    }
}
