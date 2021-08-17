﻿using System;
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

namespace TruthOrDare
{
    /// <summary>
    /// Interaction logic for ComboDialog.xaml
    /// </summary>
    public partial class ComboDialog : Window
    {
        public ComboDialog(List<Player> players)
        {
            InitializeComponent();
            ResponseComboBox.ItemsSource = players.Select(o => o.Name);
            ResponseComboBox.SelectedIndex = 0;
        }
        public string ResponseText
        {
            get { return ResponseComboBox.Text; }
            set { ResponseComboBox.Text = value; }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
