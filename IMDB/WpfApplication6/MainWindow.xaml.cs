using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApplication6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DataIO serializer = new DataIO();
        public static List<Movie> DataBase = new List<Movie>();
        public static BindingList<Movie> movies { get; set; }
        public MainWindow()
        {
            //loadDatabase();
            DataBase = serializer.DeSerializeObject<List<Movie>>("movies.xml");
            movies = serializer.DeSerializeObject<BindingList<Movie>>("state.xml");


            

            if (movies == null)
            {
                movies = new BindingList<Movie>();
            }
            if(movies.Count() == 0)
            {
                movies.Add(DataBase[0]);
                movies.Add(DataBase[1]);
                movies.Add(DataBase[2]);
            }
            DataContext = this;
            InitializeComponent();
        }

        //Na closing event ce se pozvati save funkcija
        private void save(object sender, CancelEventArgs e)
        {
            serializer.SerializeObject<BindingList<Movie>>(movies, "state.xml");
        }

        private void loadDatabase()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Movie>));

            using (TextReader reader = new StreamReader("movies.xml"))
            {
                object o = deserializer.Deserialize(reader);
                DataBase = ((List<Movie>)o);
            }
            DataBase = DataBase.OrderBy(o => o.Name).ToList();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Movie knjiga = (Movie)dataGridMovies.CurrentItem;
            movies.Remove(knjiga);
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            int i = dataGridMovies.SelectedIndex;
            NewMovie nm = new NewMovie(i);
            nm.ShowDialog();
        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            int i = dataGridMovies.SelectedIndex;
           
            ExistingMovie em = new ExistingMovie(i);
            em.ShowDialog();
        }

        private void existing_Click(object sender, RoutedEventArgs e)
        {
            ExistingMovie em = new ExistingMovie(-1);
            em.ShowDialog();
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            NewMovie nm = new NewMovie(-1);
            nm.ShowDialog();
        }

        private void x_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
