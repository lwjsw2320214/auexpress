using auexpress.model;
using auexpress.Service;
using auexpress.ViewModel;
using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        private RecPreInputService service = new RecPreInputService();
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

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var mySelectedElement = exlist.SelectedItem as ManageExpressMenuItemViewModel;
            Int64 result = mySelectedElement.SmsBatch.id;
            var count= manageExpressViewModel.delete(result);
            if (count == 0)
            {

                MessageBox.Show("删除失败，请检查当前批次号下面是否有运单！");
            }
            else {
                 
                MessageBox.Show("删除成功！");
                manageExpressViewModel.RefreshView();

            }
            
        }

        private void download_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mySelectedElement = exlist.SelectedItem as ManageExpressMenuItemViewModel;
                string result = mySelectedElement.SmsBatch.batchNumber;
                AppGlobal.SmsBatchId = mySelectedElement.SmsBatch.id;
                var list = service.getAllBatcrRec();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xls";
                saveFileDialog.Filter = "Excel文件|*.xls";
                saveFileDialog.FileName = result + "批次运单.xls";
                var isShowDialog = saveFileDialog.ShowDialog();
                if (isShowDialog.Value)
                {
                    //MessageBox.Show(saveFileDialog.FileName);
                    if (!File.Exists(@"Resources/Template.xls"))
                    {

                        MessageBox.Show("模板不存在");
                        return;
                    }
                    HSSFWorkbook hssfworkbook;
                    using (FileStream fileStream = new FileStream(@"Resources/Template.xls", FileMode.Open, FileAccess.Read))
                    {
                        var d = fileStream.Name;
                        hssfworkbook = new HSSFWorkbook(fileStream);

                    }
                    ISheet sheet = hssfworkbook.GetSheet("Sheet1");

                    var rowIndex = 1;
                    foreach (var item in list.obj)
                    {
                        IRow row = sheet.CreateRow(rowIndex);
                        row.CreateCell(0).SetCellValue(rowIndex);
                        row.CreateCell(2).SetCellValue(item.cnum);
                        row.CreateCell(4).SetCellValue(item.caddr);
                        row.CreateCell(5).SetCellValue(item.creceiver);
                        row.CreateCell(7).SetCellValue(item.cphone);
                        row.CreateCell(10).SetCellValue(item.fweight.ToString());
                        row.CreateCell(12).SetCellValue(item.cgoods);
                        row.CreateCell(14).SetCellValue(item.iitem);
                        row.CreateCell(21).SetCellValue(item.cmemo);
                        rowIndex++;
                    }
                    sheet.ForceFormulaRecalculation = true;
                    FileStream fi = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    hssfworkbook.Write(fi);
                    fi.Close();
                    MessageBox.Show("导出运单完成！");
                }
            }catch{

                MessageBox.Show("导出模板错误！");
                return;
                }
        }
    }
}
