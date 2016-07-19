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
    /// EditInfo.xaml 的交互逻辑
    /// </summary>
    public partial class EditInfo : Page
    {

        private EditInfoViewModel editInfoViewModel = new EditInfoViewModel();

        public EditInfo()
        {
            InitializeComponent();

            this.DataContext = editInfoViewModel;
            this.editInfoViewModel.AddUIEvent += new EditInfoViewModel.AddUIdelegate(AddUI);
        }

        public void AddUI() {

            RowDefinition cd = new RowDefinition(); 
            cd.Height =new GridLength(40);  
            addui.RowDefinitions.Add(cd); 

            var rowCount = addui.RowDefinitions.Count();
            Label lb = new Label();
            lb.HorizontalAlignment = HorizontalAlignment.Left;
            lb.VerticalAlignment = VerticalAlignment.Center; 
            addui.Children.Add(lb);
            Grid.SetColumn(lb, 0);
            Grid.SetRow(lb, rowCount - 1);

            Label lb2 = new Label();
            lb2.HorizontalAlignment = HorizontalAlignment.Left;
            lb2.VerticalAlignment = VerticalAlignment.Center;
            addui.Children.Add(lb2);
            Grid.SetColumn(lb2, 1);
            Grid.SetRow(lb2, rowCount - 1);

            Label lb3 = new Label();
            lb3.HorizontalAlignment = HorizontalAlignment.Left;
            lb3.VerticalAlignment = VerticalAlignment.Center;
            addui.Children.Add(lb3);
            Grid.SetColumn(lb3, 2);
            Grid.SetRow(lb3, rowCount - 1);

            Label lb4 = new Label();
            lb4.HorizontalAlignment = HorizontalAlignment.Left;
            lb4.VerticalAlignment = VerticalAlignment.Center;
            addui.Children.Add(lb4);
            Grid.SetColumn(lb4, 3);
            Grid.SetRow(lb4, rowCount - 1);

            TextBox tb = new TextBox();
            tb.Width = 150;
            lb.Content = tb;

            TextBox tb2 = new TextBox();
            tb2.Width = 150;
            lb2.Content = tb2;

            TextBox tb3 = new TextBox();
            tb3.Width = 60;
            lb3.Content = tb3;

            TextBox tb4 = new TextBox();
            tb4.Width = 60;
            lb4.Content = tb4;
              
        }
    }
}
