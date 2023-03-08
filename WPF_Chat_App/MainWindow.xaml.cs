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
using System.Windows.Media;

namespace WPF_Chat_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer mediaPlayer = new MediaPlayer();
        public MainWindow()
        {

            InitializeComponent();
            mediaPlayer.Open(new Uri(@"C:\Users\Standard Computer's\OneDrive\Pictures\Снимки экрана\nerbala.mp4"));
            mediaPlayer.MediaEnded += new EventHandler(Media_Ended);
        }


        
        public class Message
        {
            public string Text { get; set; }
            public DateTime SentDate { get; set; }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
          
            string[] words = Chat.Text.Split(' ');

            foreach (string word in words)
            {


                string inputText = Chat.Text;
                if (!string.IsNullOrEmpty(inputText))
                {


                    string message = Chat.Text;
                    DateTime now = DateTime.Now;
                    string time = now.ToString("HH:mm");

                    string text = Chat.Text;
                    TextBlock mytextBlock = new TextBlock();
                    mytextBlock.Name = "myTextBlock";
                    mytextBlock.Text = text;

                    Wiew.Items.Add(time + " " + mytextBlock.Text);
                    

                    if (Chat.Text == "sen kimsen")
                    {
                      
                        mediaPlayer.Play();
                        Wiew.Items.Add("▶ Ses qeydi");

                    }
                    Chat.Clear();

                }

            }

        }





        private void Media_Ended(object sender, EventArgs e)
        {
            mediaPlayer.Stop(); 
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem clickedItem = sender as MenuItem;
            string header = clickedItem.Header.ToString();

            switch (header)
            {
                case "Sil":
                    Wiew.Items.Remove(Wiew.SelectedItem);
                    break;
                case "Kopyala":
                    Clipboard.SetText((string)Wiew.SelectedItem);
                    break;
            }
        }


    }
}
