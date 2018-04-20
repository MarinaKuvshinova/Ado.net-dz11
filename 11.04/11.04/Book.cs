using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._04
{
    public class Book
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public int Page { get; set; }
        public float Price { get; set; }
        public int AuthorId { get; set; }
        public Book() { }
    }
}
