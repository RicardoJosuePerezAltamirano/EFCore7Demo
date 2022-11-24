using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int TrademarkId { get; set; }
        public int ModelId { get; set; }
        public string Description { get; set; }
        public Model Model { get; set; }
        public Trademark Trademark { get; set; }
    }
}
