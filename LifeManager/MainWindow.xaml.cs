using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LifeManager.Models;

namespace LifeManager
{

    public partial class MainWindow : Window
    {

        private int? _edit = null;
        public MainWindow()
        {

            
            InitializeComponent();

            using AppDbContext db = new AppDbContext();
            db.Database.EnsureCreated();
            LoadExpenses();
            System.Diagnostics.Debug.WriteLine("DATABASE READY!");
        }

        private void LoadExpenses()
        {
            using AppDbContext db = new AppDbContext();
            gridExpenses.ItemsSource = db.Expenses.ToList();
        }

        private void btnAddExpense_Click(object sender, RoutedEventArgs e)
        {
            if(decimal.TryParse(txtAmount.Text, out decimal _amount))
            {
                using AppDbContext db = new AppDbContext();

                if (_edit == null)
                {
                    Expense newExpense = new Expense
                    {
                        Title = txtTitle.Text,
                        Amount = _amount,
                        Category = txtCategory.Text,
                        Date = DateTime.Now
                    };

                    db.Expenses.Add(newExpense);
                }
                else
                {
                    Expense expenseToUpdate = db.Expenses.Find(_edit);


                    expenseToUpdate.Title = txtTitle.Text;
                    expenseToUpdate.Amount = _amount;
                    expenseToUpdate.Category = txtCategory.Text;

                    btnAddExpense.Content = "ADD EXPENSE";
                    _edit = null;

                }


                db.SaveChanges();

                txtTitle.Clear();txtAmount.Clear();txtCategory.Clear();

                LoadExpenses();
                
                //MessageBox.Show("The expense has been added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Please enter a valid number for Amount!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (gridExpenses.SelectedItem is Expense selectedExpense)
            {
                txtTitle.Text = selectedExpense.Title;
                txtAmount.Text = selectedExpense.Amount.ToString();
                txtCategory.Text = selectedExpense.Category;

                _edit = selectedExpense.Id;
                btnAddExpense.Content = "UPDATE EXPENSE";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gridExpenses.SelectedItem is Expense selectedExpense)
            {
                using AppDbContext db = new AppDbContext();

                db.Expenses.Remove(selectedExpense);
                db.SaveChanges();

                LoadExpenses();

            }
            else MessageBox.Show("Please select an expense from the table first.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

    }
}