using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Markup;


namespace Patient_File
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string DIR_PATH = @"C:\\Users\\Yoela\\source\\repos\\Patient File\\Patient File\\bin\\Debug\\net8.0-windows\\Test\\";
        public const string FILE_EXT = ".txt"; // File Extension
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string fileName = textBoxFileName.Text;

            using (FileStream fs = File.Create(DIR_PATH + fileName + FILE_EXT))
            {
                byte[] contentConvertedToBytes = Encoding.ASCII.GetBytes(content);
                fs.Write(contentConvertedToBytes, 0, contentConvertedToBytes.Length);
            }

            MessageBox.Show("File created!");
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string fileName = textBoxFileName.Text;

            using (FileStream fs = File.OpenRead(DIR_PATH + fileName + FILE_EXT))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    textBoxContent.Text = content;
                }
            }
        }
    }
}