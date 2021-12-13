using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookManagement.Services.Entities.Enums;

namespace WebBookManagement.Services.Entities
{
    public class InfoBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Stats Stats { get; set; }
        public InfoBook(int id, string title, Stats stats)
        {
            Id = id;
            Title = title;
            Stats = stats;
        }
    }
}
