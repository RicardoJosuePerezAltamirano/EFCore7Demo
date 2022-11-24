using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
