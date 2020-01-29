using System;
using System.Collections.Generic;
namespace DbManager.Models
{
    public class DailyMenu
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid DmId { get; set; }
        public string DmItems { get; set; }
        public DateTime DmDate { get; set; }
    }
}
