using Microsoft.AspNetCore.Mvc;
using OlympicGamesDBApp.Helpers;
using OlympicGamesDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGamesDBApp.Controllers
{
    public class EditController : Controller
    {

        private readonly DBContext _dbContext;
        public EditController(DBContext context)
        {
            _dbContext = context;
        }

        #region Athlete
        public void DeleteAthlete(int athleteId)
        {
            _dbContext.DeleteById("Athletes", athleteId);
        }

        public IActionResult AddAthlete(int countryId, int sportId, string fullName, DateTime birthDate)
        {
            _dbContext.InsertIntoAthletes(countryId, sportId, fullName, birthDate);
            return RedirectToAction("Athletes", "Data");
        }

        public IActionResult UpdateAthlete(int id, int countryId, int sportId, string fullName, DateTime birthDate)
        {
            _dbContext.UpdateAthletes(id, countryId, sportId, fullName, birthDate);
            return RedirectToAction("Athletes", "Data");
        }
        #endregion Athlete

        #region Country
        public void DeleteCountry(int countryId)
        {
            _dbContext.DeleteById("Countries", countryId);
        }

        public IActionResult AddCountry(string countryName, string region)
        {
            _dbContext.InsertIntoCountries(countryName, region);
            return RedirectToAction("Countries", "Data");
        }

        public IActionResult UpdateCountry(int id, string countryName, string region)
        {
            _dbContext.UpdateCountries(id, countryName, region);
            return RedirectToAction("Countries", "Data");
        }

        #endregion Country

        #region Result

        public void DeleteResult(int resultId)
        {
            _dbContext.DeleteById("Results", resultId);
        }

        public IActionResult AddResult(int sportId, int athleteId, int placement, string result)
        {
            _dbContext.InsertIntoResults(sportId, athleteId, placement, result);
            return RedirectToAction("Results", "Data");
        }

        public IActionResult UpdateResult(int id, int sportId, int athleteId, int placement, string result)
        {
            _dbContext.UpdateResults(id, sportId, athleteId, placement, result);
            return RedirectToAction("Results", "Data");
        }

        #endregion Result

        #region Schedule
        public void DeleteSchedule(int scheduleId)
        {
            _dbContext.DeleteById("Schedules", scheduleId);
        }

        public IActionResult AddSchedule(int sportId, DateTime startDate, DateTime startTime, int sportgroundId)
        {
            _dbContext.InsertIntoSchedules(sportId, startDate, startTime, sportgroundId);
            return RedirectToAction("Schedules", "Data");
        }

        public IActionResult UpdateSchedule(int id, int sportId, DateTime startDate, DateTime startTime, int sportgroundId)
        {
            _dbContext.UpdateSchedules(id, sportId, startDate, startTime, sportgroundId);
            return RedirectToAction("Schedules", "Data");
        }

        #endregion Schedule

        #region Sportgrounds
        public void DeleteSportground(int sportgroundId)
        {
            _dbContext.DeleteById("Sportgrounds", sportgroundId);
        }

        public IActionResult AddSportground(string sportgroundName, string address)
        {
            _dbContext.InsertIntoSportgrounds(sportgroundName, address);
            return RedirectToAction("Sportgrounds", "Data");
        }

        public IActionResult UpdateSportground(int id, string sportgroundName, string address)
        {
            _dbContext.UpdateSportgrounds(id, sportgroundName, address);
            return RedirectToAction("Sportgrounds", "Data");
        }

        #endregion Sportgrounds

        #region Sports
        public void DeleteSport(int sportId)
        {
            _dbContext.DeleteById("Sports", sportId);
        }

        public IActionResult AddSport(string sportName, int isIndividual)
        {
            _dbContext.InsertIntoSports(sportName, isIndividual);
            return RedirectToAction("Sports", "Data");
        }

        public IActionResult UpdateSport(int id, string sportName, int isIndividual)
        {
            _dbContext.UpdateSports(id, sportName, isIndividual);
            return RedirectToAction("Sports", "Data");
        }

        #endregion Sports
    }
}
