using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace WpfApplication6
{
    /// <summary>
    /// Interaction logic for ExistingMovie.xaml
    /// </summary>
    public partial class ExistingMovie : Window
    {
        public static List<Movie> list = new List<Movie>();
        public int s,ss;
        WebBrowser w = new WebBrowser();

        public ExistingMovie(int par)
        {
            InitializeComponent();
            if (par == -1)
            {
                s = -1;
                textBlock3.Visibility = Visibility.Hidden;
                textBlock2.Visibility = Visibility.Hidden;
                textBlock.Visibility = Visibility.Hidden;
                textBlock4.Visibility = Visibility.Hidden;
                trailer.Visibility = Visibility.Hidden;
                movie.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                comboBox.ItemsSource = MainWindow.DataBase.Select(x => x.Name).ToArray();

                win.Height = 400;
                
                
            }
            else
            {
                choose.Visibility = Visibility.Hidden;
                comboBox.Visibility = Visibility.Hidden;
                exit.Content = "_Exit";
                s = par;
                infoMov();
            }

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            existMov();
        }

        private void existMov()
        {
            textBlock3.Visibility = Visibility.Visible;
            textBlock2.Visibility = Visibility.Visible;
            textBlock.Visibility = Visibility.Visible;
            trailer.Visibility = Visibility.Visible;
            movie.Visibility = Visibility.Visible;
            exit.Visibility = Visibility.Visible;

           
                 ss = comboBox.SelectedIndex;
            

            comboBox.Visibility = Visibility.Hidden;
            choose.Visibility = Visibility.Hidden;
            win.Height = 800;
            image.Source = new BitmapImage(new Uri(MainWindow.DataBase[ss].Image2));
            image1.Source = new BitmapImage(new Uri(MainWindow.DataBase[ss].Image1));
            textBlock1.Text = MainWindow.DataBase[ss].Name + "(" + MainWindow.DataBase[ss].Year.ToString() + ")";
            textBlock.Text = MainWindow.DataBase[ss].Description;
            textBlock2.Text = MainWindow.DataBase[ss].Score.ToString();
            textBlock3.Text = MainWindow.DataBase[ss].Producent;
            textBlock4.Text = MainWindow.DataBase[ss].Genre;
        }

        private void infoMov()
        {
            comboBox.Visibility = Visibility.Hidden;

            if(MainWindow.movies[s].MovieVideo == "")
            {
                movie.Visibility = Visibility.Hidden;
                trailer.Visibility = Visibility.Hidden;
            }

            if(MainWindow.movies[s].Image2 != "")
            {
                image.Source = new BitmapImage(new Uri(MainWindow.movies[s].Image2));
            }
            
            if(MainWindow.movies[s].Image1 != "")
            {
                image1.Source = new BitmapImage(new Uri(MainWindow.movies[s].Image1));
            }
            
            textBlock1.Text = MainWindow.movies[s].Name + "(" + MainWindow.movies[s].Year.ToString() + ")";
            textBlock.Text = MainWindow.movies[s].Description;
            textBlock2.Text = MainWindow.movies[s].Score.ToString();
            textBlock3.Text = MainWindow.movies[s].Producent;
            textBlock4.Text = MainWindow.movies[s].Genre;
        } //Prikaz svih informacija o filmu

        private void close(object sender, RoutedEventArgs e)
        {
            if(s == -1)
            {
                MainWindow.movies.Add(MainWindow.DataBase[ss]);
            }
           

            w.Navigate("https://www.google.rs/");
          
            this.Close();
        } //Vezano za gledanje trailera

        private void watchTrailer(object sender, RoutedEventArgs e)
        {
            if(s == -1)
            {
                w.Navigate(MainWindow.DataBase[s].Trailer);
                grid.Children.Add(w);
                Grid.SetRow(win, 1);
                exit.Foreground = new SolidColorBrush(Colors.Black);
                win.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                if (MainWindow.movies[s].Trailer != "")
                {
                    w.Navigate(MainWindow.movies[s].Trailer);
                    grid.Children.Add(w);
                    Grid.SetRow(win, 1);
                    exit.Foreground = new SolidColorBrush(Colors.Black);
                    win.WindowState = System.Windows.WindowState.Maximized;
                }

                
            }

        } //Gledanje trailera 

        private void watchMovie(object sender, RoutedEventArgs e)
        {
            if(s == -1)
            {
                Process Chrome = new Process();
                try
                {
                    Chrome.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";  // Needs to be full path
                    Chrome.StartInfo.Arguments = MainWindow.DataBase[s].MovieVideo;
                    Chrome.Start();
                }
                catch (Exception ee)
                {
                    try
                    {
                        Chrome.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";  // Needs to be full path
                        Chrome.StartInfo.Arguments = MainWindow.DataBase[s].MovieVideo;
                        Chrome.Start();
                    }
                    catch(Exception eee)
                    {

                    }
                }

               
                
            }
            else
            {
                if(MainWindow.movies[s].MovieVideo != "")
                {
                    Process Chrome = new Process();

                    
                    try
                    {
                        Chrome.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";  // Needs to be full path
                        Chrome.StartInfo.Arguments = MainWindow.movies[s].MovieVideo;
                        Chrome.Start();
                    }
                    catch (Exception ee)
                    {
                        try
                        {
                            Chrome.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";  // Needs to be full path
                            Chrome.StartInfo.Arguments = MainWindow.movies[s].MovieVideo;
                            Chrome.Start();
                        }
                        catch (Exception eee)
                        {

                        }
                    }
                   
                }
                
            }

        } //Gledanje filma
    }
}
