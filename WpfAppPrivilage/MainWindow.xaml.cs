using Dynamitey;
using Microsoft.Win32;
using Nancy;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfAppPrivilage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Shape> _shapes;
        public MainWindow()
        {
            InitializeComponent();

            var fullPath = System.IO.Path.Combine(Properties.Settings.Default.FilePath, Properties.Settings.Default.FileName);
            var shapes = LoadShapesFromFile(fullPath);

            vectorGraphicViewer.Shapes = shapes;

        }







        private List<Shape> LoadShapesFromFile(string filePath)
        {
            // Read the JSON file and deserialize its contents into a list of shape objects
            string json = File.ReadAllText(filePath);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new ShapeConverter(), new PointConverter(),new ColorConverter() }
            };

            List<Shape> shapes = JsonConvert.DeserializeObject<List<Shape>>(json, settings);

            return shapes;
        }
    }
}
