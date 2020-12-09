using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGamesDBApp.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int SportId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
