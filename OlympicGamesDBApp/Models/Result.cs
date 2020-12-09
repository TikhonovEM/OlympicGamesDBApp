using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGamesDBApp.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public int AthleteId { get; set; }
        public int Placement { get; set; }
        public string ResultValue { get; set; }
    }
}
