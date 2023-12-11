using AccountingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.ViewModels
{
    public class CostDisplay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public string Cathegory { get; set; }
        public int CathegoryId { get; set; }
        //public CostDisplay() { }
        public CostDisplay(Cost cost = null) 
        {
            if(cost != null)
            {
                Id = cost.Id;
                Date = cost.Date;
                Price = cost.Price;
                Description = cost.Description;
                CathegoryId = cost.CathegoryId;
                Cathegory = cost.Cathegory?.Title!;
            }
        }
    }
}
