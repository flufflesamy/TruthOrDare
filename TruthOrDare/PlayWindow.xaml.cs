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
using static TruthOrDare.ApplicationContext;

namespace TruthOrDare
{
    /// <summary>
    /// Interaction logic for PlayWindow.xaml
    /// </summary>
    public partial class PlayWindow : Window
    {
        public int currentPlayerIndex = 0;

        public PlayWindow()
        {
            InitializeComponent();
            if (PlayerList != null)
            {
                currentPlayerLbl.Content = PlayerList[0].Name;
                if (PlayerList.Count > 1)
                {
                    nextPlayerLbl.Content = PlayerList[1].Name;
                }
            }

            UpdatePlayerList();
        }
        private void Append_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new InputDialog();

            if(dialog.ShowDialog() == true)
            {
                PlayerList.Add(new Player(dialog.ResponseText));
            }

            UpdatePlayerList();
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            PlayerList = new List<Player>();

            var mainWindow = new MainWindow();
            mainWindow.Show();

            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void NextPlayer_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PrevPlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdatePlayerList()
        {
            string listText = string.Join("\n", PlayerList.Select(r => r.Name));
            playersTxtbox.Text = listText;
        }

    }
}
