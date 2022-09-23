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
using MongoDB.Driver;

namespace WPF_APP_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("libraryDB");
        static IMongoCollection<Book> collection = db.GetCollection<Book>("books");

        public void ReadAllDocuments()
        {
            List<Book> list = collection.AsQueryable().ToList<Book>();
            DataTable.ItemsSource = list;
            Book b = (Book)DataTable.Items.GetItemAt(0);
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
