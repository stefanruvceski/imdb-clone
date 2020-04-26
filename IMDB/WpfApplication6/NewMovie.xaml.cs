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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApplication6
{
    /// <summary>
    /// Interaction logic for NewMovie.xaml
    /// </summary>
    public partial class NewMovie : Window
    {
        string[] genres = { "Action", "Adventure", "Comedy", "Mystery", "Drama", "Horror", "Romance" };
        int s, ss;
        static BitmapImage bmp1 = new BitmapImage();
        static BitmapImage bmp2 = new BitmapImage();
        static  OpenFileDialog op1 = new OpenFileDialog();
        
        static OpenFileDialog op2 = new OpenFileDialog();

        public NewMovie(int par)
        {
            InitializeComponent();
            comboBox.ItemsSource = genres;
            op1.FileName = "X";
            op2.FileName = "X";
            if (par == -1)
            {
                s = -1;
            }
            else
            {
                add.Content = "Change";
                s = par;
                textBoxTitle.Text = MainWindow.movies[s].Name;
                textBoxYear.Text = MainWindow.movies[s].Year.ToString();
                textBoxProducer.Text = MainWindow.movies[s].Producent;
                textBoxScore.Text = MainWindow.movies[s].Score.ToString();
                comboBox.SelectedItem =  MainWindow.movies[s].Genre;
                textBoxBrief.Text =   MainWindow.movies[s].Breaf;
                textBoxDescription.Text = MainWindow.movies[s].Description;
                image1.Source = new BitmapImage(new Uri(MainWindow.movies[s].Image1));
                image2.Source = new BitmapImage(new Uri(MainWindow.movies[s].Image2));
            }
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            bool res = validation();

            if(res == true )
            {
                if (s == -1)
                {
                    Movie m = new Movie();
                    m.Name = textBoxTitle.Text;
                    m.Year = int.Parse(textBoxYear.Text);
                    m.Producent = textBoxProducer.Text;
                    m.Score = float.Parse(textBoxScore.Text);
                    m.Genre = comboBox.SelectedItem.ToString();
                    m.Breaf = textBoxBrief.Text;
                    m.Description = textBoxDescription.Text;
                    m.Image1 = image1.Source.ToString();
                    m.Image2 = image2.Source.ToString() ;
                    MainWindow.movies.Add(m);
                    this.Close();
                }
                else
                {
                    
                    Movie m = new Movie();
                    m.Name = textBoxTitle.Text;
                    m.Year = int.Parse(textBoxYear.Text);
                    m.Producent = textBoxProducer.Text;
                    m.Score = float.Parse(textBoxScore.Text);
                    m.Genre = comboBox.SelectedItem.ToString();
                    m.Breaf = textBoxBrief.Text;
                    m.Description = textBoxDescription.Text;
                    m.Image1 = image1.Source.ToString();
                    m.Image2 = image2.Source.ToString();
                    m.Trailer = MainWindow.movies[s].Trailer;
                    m.MovieVideo = MainWindow.movies[s].MovieVideo;
                    MainWindow.movies[s] = m;
                    this.Close();
                }
            }
        } //Dodavanje Filma

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            op1.FileName = "X";
            op1.InitialDirectory = @"C:\IMDB\Image";
            op1.Title = "Select a picture";
            op1.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op1.ShowDialog() == true)
            {
                image1.Source = new BitmapImage(new Uri(op1.FileName));
                bmp1 = new BitmapImage(new Uri(op1.FileName));
            }
        } //Browse za prvu sliku

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            op2.FileName = "X";
            op2.InitialDirectory = @"C:\IMDB\Cover";
            op2.Title = "Select a picture";
            op2.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op2.ShowDialog() == true)
            {
                image2.Source = new BitmapImage(new Uri(op2.FileName));
                bmp2 = new BitmapImage(new Uri(op2.FileName));
            }
        } //Browse za drugu sliku

        private bool validation()
        {
            bool result = true;
            /////////////////////////////////////////////////////////////////
           
            if (textBoxTitle.Text.Trim().Equals(""))
            {
                labelErrorTitle.Content = "Please fill in the box!";
                textBoxTitle.BorderBrush = Brushes.Red;
                result = false;
            }
            else
            {
                labelErrorTitle.Content = "";
                textBoxTitle.BorderBrush = Brushes.Black;
            }
            /////////////////////////////////////////////////////////////////
            if (textBoxYear.Text.Trim().Equals(""))
            {
                labelErrorYear.Content = "Please fill in the box";
                textBoxYear.BorderBrush = Brushes.Red;
                result = false;
            }
            else
            {
                labelErrorYear.Content = "";
                textBoxYear.BorderBrush = Brushes.Black;

                try
                {
                    int pom = int.Parse(textBoxYear.Text.Trim());

                    if (pom > 1896 && pom < 2018)
                    {

                    }
                    else
                    {
                        labelErrorYear.Content = "Must be number beetwen 1896 and 2018!";
                        textBoxYear.BorderBrush = Brushes.Red;

                        result = false;
                    }
                   
                }
                catch (Exception e)
                {
                    labelErrorYear.Content = "Must be number!";
                    textBoxYear.BorderBrush = Brushes.Red;
                    
                    result = false;
                }

                
            }

            
            /////////////////////////////////////////////////////////////////
            if (comboBox.SelectedItem == null)
            {
                labelErrorGenre.Content = "Please choose option!";
                comboBox.BorderBrush = Brushes.Red;
                result = false;
            }
            else
            {
                labelErrorGenre.Content = "";
                comboBox.BorderBrush = Brushes.Black;
            }
            /////////////////////////////////////////////////////////////////
            if (textBoxProducer.Text.Trim().Equals(""))
            {
                labelErrorProducer.Content = "Please fill in the box!";
                textBoxProducer.BorderBrush = Brushes.Red;
                result = false;
            }
            else
            {
                labelErrorProducer.Content = "";
                textBoxProducer.BorderBrush = Brushes.Black;
            }
            /////////////////////////////////////////////////////////////////
            if (textBoxScore.Text.Trim().Equals(""))
            {
                labelErrorScore.Content = "Please fill in the box";
                textBoxScore.BorderBrush = Brushes.Red;
                result = false;
            }
            else
            {
                labelErrorScore.Content = "";
                textBoxScore.BorderBrush = Brushes.Black;

                try
                {
                     float pom = float.Parse(textBoxScore.Text.Trim());

                    if (pom >= 1 && pom <= 10)
                    {

                    }
                    else
                    {
                        labelErrorScore.Content = "Must be number beetwen 1 and 10!";
                        textBoxScore.BorderBrush = Brushes.Red; 
                        

                        result = false;
                    }

                }
                catch (Exception e)
                {
                    labelErrorScore.Content = "Must be number!";
                    textBoxScore.BorderBrush = Brushes.Red;
                    result = false;
                }
            }
           
            /////////////////////////////////////////////////////////////////
            if (textBoxBrief.Text.Trim().Equals(""))
            {
                labelErrorBrief.Content = "Please fill in the box!";
                textBoxBrief.BorderBrush = Brushes.Red;
                result = false;
            }
            else
            {
                labelErrorBrief.Content = "";
                textBoxBrief.BorderBrush = Brushes.Black;
            }
            /////////////////////////////////////////////////////////////////
            if (textBoxDescription.Text.Trim().Equals(""))
            {
                labelErrorDescription.Content = "Please fill in the box!";
                textBoxDescription.BorderBrush = Brushes.Red;
                result = false;
            }
            else
            {
                labelErrorDescription.Content = "";
                textBoxDescription.BorderBrush = Brushes.Black;
            }
             
            if(op1.FileName == "X" && s == -1)
            {
                labelErrorPic1.Content = "Please choose image.";
                labelErrorPic1.BorderBrush = Brushes.Red;
                button1.BorderBrush = Brushes.Red;
                result = false;
            }
            else
            {
                labelErrorPic1.Content = "";
                button1.BorderBrush = Brushes.Yellow;
            }

            if (op2.FileName == "X" && s == -1)
            {
                labelErrorPic2.Content = "Please choose image.";
                labelErrorPic2.BorderBrush = Brushes.Red;
                button2.BorderBrush = Brushes.Red;
                result = false;
            }
            else
            {
                labelErrorPic2.Content = "";
                button2.BorderBrush = Brushes.Yellow;
            }


            return result;
        } //Validacija svih polja poziva se u metodi dodavanja filma
    }
}
