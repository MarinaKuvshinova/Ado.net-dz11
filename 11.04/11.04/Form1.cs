using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Author author = new Author {FirstName = "Иванов", LastName = "Иван"};
            AddAuthor(author);
            author = new Author { FirstName = "Ивнов", LastName = "Антон" };
            AddAuthor(author);
            Book book = new Book { Name ="Book1", Page = 20, Price = 200 , AuthorId = 1 };
            AddBook(book);
            book = new Book { Name = "Book11", Page = 20, Price = 200, AuthorId = 1 };
            AddBook(book);
            book = new Book { Name = "Book2", Page = 20, Price = 200, AuthorId = 2 };
            AddBook(book);
            using (LibContext db = new LibContext())
            {
                var text = (from b in db.Books
                           select
                           new {Name = b.Name, Page = b.Page, Price = b.Price } 
                           ).ToList();
                dataGridFind.DataSource = null;
                dataGridFind.DataSource = text;
            }
        }

        private void AddBook(Book book)
        {
            using (LibContext db = new LibContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        private void AddAuthor(Author author)
        {
            using (LibContext db = new LibContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            using (LibContext db = new LibContext())
            {
                var list = (from a in db.Authors
                           from b in db.Books
                           where b.AuthorId == a.Id && a.FirstName.Contains(tbFind.Text) == true
                           select ( new { Name = b.Name, Page = b.Page, Price = b.Price }
                           )).ToList();

                dataGridFind.DataSource = null;
                dataGridFind.DataSource = list;
            }
        }
    }
}
