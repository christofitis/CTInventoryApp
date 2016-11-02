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

namespace CTInventoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void partSearchComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            this.partSearchComboBox.ApplyTemplate();
            TextBox textBox = this.partSearchComboBox.Template.FindName("PART_EditableTextBox", this.partSearchComboBox) as TextBox;
            textBox.SelectionLength = 0;

            if (textBox != null)
            {
                textBox.TextChanged += delegate
                {
                    this.partSearchComboBox.IsDropDownOpen = true;

                    this.partSearchComboBox.SelectedIndex = -1;

                    this.partSearchComboBox.Items.Filter += a =>
                    {
                        if (a.ToString().ToUpper().Contains(textBox.Text.ToUpper()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    };

                    textBox.SelectionLength = 0;
                    textBox.CaretIndex = textBox.Text.Length;
                };
            }
        }

        private void partSearchComboBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
