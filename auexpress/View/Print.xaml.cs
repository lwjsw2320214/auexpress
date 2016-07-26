using auexpress.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace auexpress.View
{
    /// <summary>
    /// Print.xaml 的交互逻辑
    /// </summary>
    public partial class Print : MetroWindow
    {
        private PrintViewModel printViewModel = new PrintViewModel();
        public Print()
        {
            InitializeComponent();
            this.DataContext = printViewModel;
            if (!String.IsNullOrEmpty(printViewModel.PrintMenu.Express.cnum)) {
                printBarCode(printViewModel.PrintMenu.Express.cnum);
            }
           // this.printViewModel.barCodeEvent += new PrintViewModel.barCodeDelegate(printBarCode); 
            PrintDialog pd = new PrintDialog(); 
            //pd.PrintVisual(printBox, "test");
        }

        public void printBarCode(string Contents)
        {
            Regex rg = new Regex("^[0-9]{12}$");

            MultiFormatWriter mutiWriter = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> dc = new Dictionary<EncodeHintType, object>();
            dc.Add(EncodeHintType.MAX_SIZE, 16);
            dc.Add(EncodeHintType.MARGIN, 0);
            dc.Add(EncodeHintType.DISABLE_ECI, true);
            BitMatrix bm = mutiWriter.encode(Contents, BarcodeFormat.CODE_128, 700, 140, dc);
            Bitmap bitmap = new BarcodeWriter().Write(bm);

            //bc.Source = (BitmapImage)img;
            IntPtr ip = bitmap.GetHbitmap();
            ImageSource bc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            barcode.Source = bc;
            barcode_text.Text = Contents;
            barcode_t.Source = bc;
            barcode_t_text.Text = Contents;
        }
    }
}
