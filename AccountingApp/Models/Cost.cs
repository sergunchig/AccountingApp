using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Models
{
    public class Cost
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public int CathegoryId { get; set; }

        public Cathegory Cathegory { get; set; }
    }
}
