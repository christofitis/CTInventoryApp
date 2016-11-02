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
using System.Data;

namespace CTInventoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseAccessor databaseAccessor = new DatabaseAccessor();
        public MainWindow()
        {
            InitializeComponent();
            mfgNumTextBox.Focus();
            //partSearchComboBox_GotFocus(null, null);
            //partSearchComboBox.Items.Add("1");

        }
        private void partSearchComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            partSearchComboBox.Items.Clear();
            DataTable dt = new DataTable();
            databaseAccessor.UserSqlCommand = "SELECT Mfg_Num FROM Parts";
            // MessageBox.Show(databaseAccessor.DbUserName);
            dt = databaseAccessor.RunSqlCommand();
            // MessageBox.Show(dt.Rows.Count.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                partSearchComboBox.Items.Add(dt.Rows[i]["Mfg_Num"].ToString());
            }

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

        private void addPartButton_Click(object sender, RoutedEventArgs e)
        {
            int i = -1;
            Int32.TryParse(onHandTextBox.Text.ToString(), out i);
            
            if (Int32.TryParse(onHandTextBox.Text.ToString(), out i))
            {
                databaseAccessor.RunSqlCommand(string.Format(@"INSERT INTO Parts (Mfg_Num, Description, On_Hand) VALUES ('{0}', '{1}', {2})", mfgNumTextBox.Text, descriptionTextBox.Text, i));

            }

        }

        private void onHandTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                addPartButton_Click(null, null);
            }
        }
    }
}
