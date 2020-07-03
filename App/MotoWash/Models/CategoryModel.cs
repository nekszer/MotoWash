using System;
using System.Collections.Generic;
using System.Text;

namespace MotoWash.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Selected { get; set; }
    }
}
