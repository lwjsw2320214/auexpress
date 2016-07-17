using auexpress.model;
using auexpress.Utils;
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
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : MetroWindow
    {
        private MainViewModel mainViewModel= new MainViewModel();
        public Main()
        {
            InitializeComponent();
             
            this.DataContext = mainViewModel;
             
            mainViewModel.ShowSend += new MainViewModel.ShowWindowsDelegate(showInformationImport);
            this.mainCount.Content = new Wecome();
        }

        void showInformationImport(PapgeEnum papgeEnum)
        {
            
                this.mainCount.Content =new WaybillProcessingView();   
        }
    }
}
