using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthContract.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public List<Region> Childs { get; set; }
    }
}
