using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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


namespace WpfBindingINotifyApp
{
    public class Product
    {
        public string? Title { set; get; }
        public override string ToString()
        {
            return Title;
        }
    }
    public class User : INotifyPropertyChanged
    {
        string? name;
        string? company;
        //string position;

        public string? Name 
        { 
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }
        public string? Company 
        { 
            get => company;
            set
            {
                company = value;
                NotifyPropertyChanged(nameof(Company));
            }
        }
        public string? Position { set; get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user;
        ObservableCollection<Product> products;

        /*public static DependencyProperty UserProperty;
        public User User
        {
            get { return (User)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        static MainWindow()
        {
            UserProperty = DependencyProperty.Register(
                "User",
                typeof(User),
                typeof(MainWindow)
                );
        }
        */
        public MainWindow()
        {
            InitializeComponent();
            user = new User() { Name = "Tom", Company = "Yandex", Position = "Manager" };
            //grid.DataContext = user;
            products = new()
            {
                new(){ Title = "Computer" },
                new(){ Title = "Notebook" },
                new(){ Title = "Phone" },
                new(){ Title = "Table" },
            };
            listBox.ItemsSource = products;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //var user = (User)this.Resources["user"];
            //user.Name = "Bob";
            //MessageBox.Show(User.Name + " " + User.Company + " " + User.Position);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            products.Add(new Product { Title = textBox.Text });
            string str = "";
            foreach (var item in products)
                str += item.ToString() + "\n";
            //MessageBox.Show(str);
        }
    }
}
