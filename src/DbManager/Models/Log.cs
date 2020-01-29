using System;

namespace DbManager.Models
{
    public class Log
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int LogId { get; set; }
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
    }
}
