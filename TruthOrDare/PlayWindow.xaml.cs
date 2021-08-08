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
        int currentPlayerIndex = 0;

        public PlayWindow()
        {
            InitializeComponent();
            if (PlayerList != null)
            {
                currentPlayerLbl.Content = PlayerList[0].Name;
                prevPlayerLbl.Content = "First Player";
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
            if (currentPlayerIndex < PlayerList.Count - 1)
            {
                currentPlayerIndex++;
                UpdatePrevNext();
            }
        }

        private void PrevPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (currentPlayerIndex > 0)
            {
                currentPlayerIndex--;
                UpdatePrevNext();
            }
        }

        private void UpdatePlayerList()
        {
            string listText = string.Join("\n", PlayerList.Select(r => r.Name));
            playersTxtbox.Text = listText;
        }

        private void UpdatePrevNext()
        {
            currentPlayerLbl.Content = PlayerList[currentPlayerIndex].Name;
            if (currentPlayerIndex < PlayerList.Count -1)
            {
                nextPlayerLbl.Content = PlayerList[currentPlayerIndex + 1].Name;
            }
            else
            {
                nextPlayerLbl.Content = "Last Player";
            }

            if (currentPlayerIndex > 0)
            {
                prevPlayerLbl.Content = PlayerList[currentPlayerIndex - 1].Name;
            }
            else
            {
                prevPlayerLbl.Content = "First Player";
            }
        }

        private void macroBtn_Click(object sender, RoutedEventArgs e)
        {
            string listText = string.Join(", ", PlayerList.Select(r => r.Name));

            string macroText = String.Format("/yell Current players on the list: {0}.", listText);

            Clipboard.SetText(macroText);
        }

        private void remplayBtn_Click(object sender, RoutedEventArgs e)
        {
            string listText = string.Join(", ", PlayerList.Select(r => r.Name).Skip(currentPlayerIndex));

            string macroText = String.Format("/yell Remaining players on the list: {0}.", listText);

            Clipboard.SetText(macroText);
        }
    }
}
