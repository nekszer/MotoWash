using LightForms.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotoWash.Models
{
    public class ServiceModel : ModelBase
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Html { get; set; }
        public string Image { get; set; }
        public ICommand Select { get; set; }
    }
}
