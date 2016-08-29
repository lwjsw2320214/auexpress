using auexpress.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        private delegate void UpdateDelegate();

        public delegate void ResetInput();
        public event ResetInput ResetInputEvent;

        private PrintViewModel printViewModel = new PrintViewModel();   
        public Print()
        {
            InitializeComponent();
            var width = 0d;
            double.TryParse(ConfigurationManager.AppSettings["width"], out width);
            this.printBox.Width = width; 
            var height = 0d;
            double.TryParse(ConfigurationManager.AppSettings["height"], out height);
            this.printBox.Height = height;  
            var left = 0d;
            double.TryParse(ConfigurationManager.AppSettings["left"],out left); 
            var top =0d;
            double.TryParse(ConfigurationManager.AppSettings["top"], out top);
            var right = 0d;
            double.TryParse(ConfigurationManager.AppSettings["right"], out right); 
            var bottom = 0d;
            double.TryParse(ConfigurationManager.AppSettings["bottom"], out bottom);
            this.printBox.Margin = new Thickness(left, top, right, bottom);
            
            this.DataContext = printViewModel;
           
            try
            {
                if (null != printViewModel.PrintMenu.Express)
                {
                    if (printViewModel.PrintMenu.Express.cemskind == "圆通快递")
                    {
                        this.backImg.ImageSource = new BitmapImage(new Uri(@"Resources\printback\YT.png", UriKind.Relative));
                        this.cdes.FontSize = 16;
                    }
                    else {
                        this.backImg.ImageSource = new BitmapImage(new Uri(@"Resources\printback\AU.png", UriKind.Relative));
                        this.cdes.FontSize = 23;
                    }
                    SoundPlayer sp = new SoundPlayer("Resources/6063.wav");
                    sp.Play();
                    printBarCode(printViewModel.PrintMenu.Express.cnum);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(pt));
                     
                }
                else {
                    SoundPlayer sp = new SoundPlayer("Resources/6579.wav");
                    sp.Play(); 
                    this.Close();
                }
                // this.printViewModel.barCodeEvent += new PrintViewModel.barCodeDelegate(printBarCode); 
            }
            catch {
                SoundPlayer sp = new SoundPlayer("Resources/6579.wav");
                sp.Play(); 
                this.Close();
            }
            
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

        private void pt(object state)
        {
            var ti = 0;
            int.TryParse(ConfigurationManager.AppSettings["startTime"], out ti);
            Thread.Sleep(ti);
            // UI thread dispatch the event into the event queue Async  
            this.Dispatcher.BeginInvoke(new UpdateDelegate(prints));

        }

        public void prints() {
            PrintDialog pd = new PrintDialog();
            pd.PrintVisual(printBox, "运单打印");
            this.Close();
            TiggerResetInput();
        }

        public void TiggerResetInput() {
            if (ResetInputEvent != null) { 
                ResetInputEvent();
            }
        }
         
    }
}
