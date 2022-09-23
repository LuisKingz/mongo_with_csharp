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
using MongoDB.Bson;
using MongoDB.Driver;

namespace WPF_APP_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("libaryDB");
        static IMongoCollection<Book> collection = db.GetCollection<Book>("books");

        public void ReadAllDocuments()
        {
            List<Book> list = collection.AsQueryable().ToList<Book>();
            DataTable.ItemsSource = list;
            Book b = (Book)DataTable.Items.GetItemAt(0);
            tbxId.Text = b.Id.ToString();
            tbxTitle.Text = b.Title;
            tbxPrice.Text = b.Price.ToString();

        }
        public MainWindow()
        {
            InitializeComponent();
            ReadAllDocuments();
        }

        private void DataTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Book b = (Book)DataTable.SelectedItem; ;
            tbxId.Text = b.Id.ToString();
            tbxTitle.Text = b.Title;
            tbxPrice.Text = b.Price.ToString();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Book b = new Book(int.Parse(tbxPrice.Text), tbxTitle.Text);
            collection.InsertOne(b);
            ReadAllDocuments();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var updateDef = Builders<Book>.Update.Set("title", tbxTitle.Text).Set("price", tbxPrice.Text);
            collection.UpdateOne(b => b.Id == ObjectId.Parse(tbxId.Text), updateDef);
            ReadAllDocuments();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            collection.DeleteOne(b => b.Id == ObjectId.Parse(tbxId.Text));
            ReadAllDocuments();
        }
    }
}
