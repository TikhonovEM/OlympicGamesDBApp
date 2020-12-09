using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGamesDBApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public int SportgroundId { get; set; }
        public DateTime StartDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
    }
}
