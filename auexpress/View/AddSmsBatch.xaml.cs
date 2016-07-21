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

    public delegate void ChangeText();
    /// <summary>
    /// AddSmsBatch.xaml 的交互逻辑
    /// </summary>
    public partial class AddSmsBatch : MetroWindow
    {

        public event ChangeText ChangeTextEvent;

        private AddSmsBatchViewModel addSmsBatchViewModel = new AddSmsBatchViewModel();

        public AddSmsBatch()
        {
            InitializeComponent();
            this.DataContext = addSmsBatchViewModel;
            this.addSmsBatchViewModel.MessageEvent += new AddSmsBatchViewModel.MessageDelegate(message);
        }

        public void message(Boolean isSuccess, string message)
        {
            if (isSuccess)
            {
                MessageBox.Show(message);
                this.Close();
                StrikeEvent();
            }
            else {
                MessageBox.Show(message);
            }
        }

        private void StrikeEvent() {

            if (ChangeTextEvent != null) {

                ChangeTextEvent();
            }
        }
    }
}
