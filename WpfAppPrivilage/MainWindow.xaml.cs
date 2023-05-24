using System.IO;
using System.Windows;

namespace WpfAppPrivilage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var fullPath = Path.Combine(Properties.Settings.Default.FilePath, Properties.Settings.Default.FileName);

            if (!File.Exists(fullPath))
            {
                MessageBox.Show($"Could not find shapes file here: {fullPath}\nChange the path from app.config");
                return;
            }

            vectorGraphicViewer.ReadShapes(fullPath);
        }
    }
}
