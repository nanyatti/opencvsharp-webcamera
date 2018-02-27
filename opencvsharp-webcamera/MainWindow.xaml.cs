using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenCvSharp;

namespace opencvsharp_webcamera
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var capture = new VideoCapture(0);
            using (var win = new OpenCvSharp.Window("capture"))
            using (var mat = new Mat())
            {
                while (true)
                {
                    capture.Read(mat);
                    win.ShowImage(mat);
                    if (Cv2.WaitKey(30) >= 0) { break; }
                }
            }
        }
    }
}
