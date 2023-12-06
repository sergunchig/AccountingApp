using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Models
{
    public class Cathegory
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public List<Cost> Costs { get; set; }
    }
}
