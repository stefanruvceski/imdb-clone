using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace update_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Movie> movies = new List<Movie>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "\nXML database has been updated.";

            string[] lines = System.IO.File.ReadAllLines("text.txt");
            int ind = 1;

            for (int i = 0; i < lines.Count() - 12; i = i + 12)
            {
                Movie m = new Movie();
                m.ID = ind;
                m.Name = lines[i];
                m.Year = int.Parse(lines[i + 1]);
                m.Producent = lines[i + 2];
                m.Genre = lines[i + 3];
                m.Score = float.Parse(lines[i + 4]);
                m.Breaf = lines[i + 5];
                m.Description = lines[i + 6];
                m.Image1 = lines[i + 7];
                m.Image2 = lines[i + 8];
                m.Trailer = lines[i + 9];
                m.MovieVideo = lines[i + 10];
                ind++;
                movies.Add(m);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Movie>));
            using (TextWriter textWriter = new StreamWriter(@"C:\Users\STEFAN\Documents\Visual Studio 2015\Projects\Project1\Project1\bin\Debug\movies.xml"))
            {
                serializer.Serialize(textWriter, movies);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
