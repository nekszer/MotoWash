using LightForms.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotoWash.Models
{
    public class ExtraModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Html { get; set; }
        public bool Selected { get; set; }
        public ICommand ExtraSelected { get; set; }
    }
}
