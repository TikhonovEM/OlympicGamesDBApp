using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using OlympicGamesDBApp.Models;

namespace OlympicGamesDBApp.Helpers
{
    public class DBContext
    {
        private string connStr = @"Data Source=localhost;Initial Catalog=OlympicGames;Persist Security Info=True;User ID=sa;Password=123";

        private readonly SqlConnection SqlConnection;

        private SqlDataReader SqlDataReader = null;

        private SqlCommand SqlCommand = null;

        public DBContext()
        {
            SqlConnection = new SqlConnection(connStr);
        }

        public void Open()
        {
            if (SqlConnection.State != ConnectionState.Open)
                SqlConnection.Open();
        }

        public void Close()
        {
            if (SqlConnection.State == ConnectionState.Open)
                SqlConnection.Close();
        }

        public void DeleteById(string table, int id)
        {
            Open();
            SqlCommand = new SqlCommand($"DELETE FROM {table} WHERE Id = {id}", SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }
        #region Athletes
        public void InsertIntoAthletes(int countryId, int sportId, string fullName, DateTime birthDate)
        {
            Open();
            var com = $"INSERT INTO Athletes(CountryId, SportId, FullName, BirthDate)" +
                $"VALUES({countryId}, {sportId}, '{fullName}', '{birthDate:yyyyMMdd}')";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public void UpdateAthletes(int id, int countryId, int sportId, string fullName, DateTime birthDate)
        {
            Open();
            var com = $"UPDATE Athletes SET CountryId = {countryId}, SportId = {sportId}, FullName = '{fullName}', BirthDate = '{birthDate:yyyyMMdd}'" +
                $"WHERE Id = {id}";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public IQueryable<Athlete> GetAthleteTableData()
        {
            Open();

            SqlCommand = new SqlCommand($"SELECT * FROM Athletes", SqlConnection);

            SqlDataReader = SqlCommand.ExecuteReader();

            var list = new List<Athlete>();
            while (SqlDataReader.Read())
            {
                var row = new Athlete
                {
                    Id = Convert.ToInt32(SqlDataReader["Id"]),
                    CountryId = Convert.ToInt32(SqlDataReader["CountryId"]),
                    SportId = Convert.ToInt32(SqlDataReader["SportId"]),
                    FullName = Convert.ToString(SqlDataReader["FullName"]),
                    BirthDate = Convert.ToDateTime(SqlDataReader["BirthDate"])
                };
                list.Add(row);
            }

            Close();
            return list.AsQueryable();           
        }
        #endregion Athletes

        #region Countries
        public void InsertIntoCountries(string countryName, string region)
        {
            Open();
            var com = $"INSERT INTO Countries(Name, Region)" +
                $"VALUES('{countryName}', '{region}')";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public void UpdateCountries(int id, string countryName, string region)
        {
            Open();
            var com = $"UPDATE Countries SET Name = '{countryName}', Region = '{region}' WHERE Id = {id}";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public IQueryable<Country> GetCountryTableData()
        {
            Open();

            SqlCommand = new SqlCommand($"SELECT * FROM Countries", SqlConnection);

            SqlDataReader = SqlCommand.ExecuteReader();

            var list = new List<Country>();
            while (SqlDataReader.Read())
            {
                var row = new Country
                {
                    Id = Convert.ToInt32(SqlDataReader["Id"]),
                    Name = Convert.ToString(SqlDataReader["Name"]),
                    Region = Convert.ToString(SqlDataReader["Region"])
                };
                list.Add(row);
            }

            Close();
            return list.AsQueryable();
        }
        #endregion Countries

        #region Results
        public void InsertIntoResults(int sportId, int athleteId, int placement, string result)
        {
            Open();
            var com = $"INSERT INTO Results(SportId, AthleteId, Placement, Result)" +
                $"VALUES({sportId}, {athleteId}, '{placement}', '{result}')";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public void UpdateResults(int id, int sportId, int athleteId, int placement, string result)
        {
            Open();
            var com = $"UPDATE Results SET SportId = {sportId}, AthleteId = {athleteId}, Placement = {placement}, Result = '{result}' WHERE Id = {id}";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public IQueryable<Result> GetResultTableData()
        {
            Open();

            SqlCommand = new SqlCommand($"SELECT * FROM Results", SqlConnection);

            SqlDataReader = SqlCommand.ExecuteReader();

            var list = new List<Result>();
            while (SqlDataReader.Read())
            {
                var row = new Result
                {
                    Id = Convert.ToInt32(SqlDataReader["Id"]),
                    AthleteId = Convert.ToInt32(SqlDataReader["AthleteId"]),
                    SportId = Convert.ToInt32(SqlDataReader["SportId"]),
                    Placement = Convert.ToInt32(SqlDataReader["Placement"]),
                    ResultValue = Convert.ToString(SqlDataReader["Result"])
                };
                list.Add(row);
            }

            Close();
            return list.AsQueryable();
        }

        #endregion Results

        #region Schedule
        public void InsertIntoSchedules(int sportId, DateTime startDate, DateTime startTime, int sportgroundId)
        {
            Open();
            var com = $"INSERT INTO Schedules(SportId, StartDate, StartTime, SportgroundId)" +
                $"VALUES({sportId}, '{startDate:yyyyMMdd}', '{startTime:HH:mm:ss}', {sportgroundId})";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public void UpdateSchedules(int id, int sportId, DateTime startDate, DateTime startTime, int sportgroundId)
        {
            Open();
            var com = $"UPDATE Schedules SET SportId = {sportId}, StartDate = '{startDate:yyyyMMdd}', StartTime = '{startTime:HH:mm:ss}', SportgroundId = {sportgroundId} WHERE Id = {id}";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }


        public IQueryable<Schedule> GetScheduleTableData()
        {
            Open();

            SqlCommand = new SqlCommand($"SELECT * FROM Schedules", SqlConnection);

            SqlDataReader = SqlCommand.ExecuteReader();

            var list = new List<Schedule>();
            while (SqlDataReader.Read())
            {
                var row = new Schedule
                {
                    Id = Convert.ToInt32(SqlDataReader["Id"]),
                    SportgroundId = Convert.ToInt32(SqlDataReader["SportgroundId"]),
                    SportId = Convert.ToInt32(SqlDataReader["SportId"]),
                    StartDate = Convert.ToDateTime(SqlDataReader["StartDate"]),
                    StartTime = Convert.ToDateTime(SqlDataReader["StartTime"].ToString())
                };
                list.Add(row);
            }

            Close();
            return list.AsQueryable();
        }

        #endregion Schedule

        #region Sportgrounds

        public void InsertIntoSportgrounds(string sportgroundName, string address)
        {
            Open();
            var com = $"INSERT INTO Sportgrounds(Name, Address)" +
                $"VALUES('{sportgroundName}', '{address}')";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public void UpdateSportgrounds(int id, string sportgroundName, string address)
        {
            Open();
            var com = $"UPDATE Sportgrounds SET Name = '{sportgroundName}', Address = '{address}' WHERE Id = {id}";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public IQueryable<Sportground> GetSportgroundTableData()
        {
            Open();

            SqlCommand = new SqlCommand($"SELECT * FROM Sportgrounds", SqlConnection);

            SqlDataReader = SqlCommand.ExecuteReader();

            var list = new List<Sportground>();
            while (SqlDataReader.Read())
            {
                var row = new Sportground
                {
                    Id = Convert.ToInt32(SqlDataReader["Id"]),
                    Name = Convert.ToString(SqlDataReader["Name"]),
                    Address = Convert.ToString(SqlDataReader["Address"])
                };
                list.Add(row);
            }

            Close();
            return list.AsQueryable();
        }

        #endregion Sportgrounds

        #region Sports

        public void InsertIntoSports(string sportName, int isIndividual)
        {
            Open();
            var com = $"INSERT INTO Sports(Name, IsIndividual)" +
                $"VALUES('{sportName}', {isIndividual})";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public void UpdateSports(int id, string sportName, int isIndividual)
        {
            Open();
            var com = $"UPDATE Sports SET Name = '{sportName}', IsIndividual = {isIndividual} WHERE Id = {id}";
            SqlCommand = new SqlCommand(com, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Close();
        }

        public IQueryable<Sport> GetSportTableData()
        {
            Open();

            SqlCommand = new SqlCommand($"SELECT * FROM Sports", SqlConnection);

            SqlDataReader = SqlCommand.ExecuteReader();

            var list = new List<Sport>();
            while (SqlDataReader.Read())
            {
                var row = new Sport
                {
                    Id = Convert.ToInt32(SqlDataReader["Id"]),
                    Name = Convert.ToString(SqlDataReader["Name"]),
                    IsIndividual = Convert.ToInt32(SqlDataReader["IsIndividual"])
                };
                list.Add(row);
            }

            Close();
            return list.AsQueryable();
        }

        #endregion Sports

        public IQueryable<Report1> GetReport1Data()
        {
            Open();

            SqlCommand = new SqlCommand("SELECT a.FullName AS[FullName], c.Name AS[CountryName], r.Result AS[Result] " +
                "FROM dbo.Results AS r " +
                "INNER JOIN dbo.Athletes AS a ON r.AthleteId = a.Id " +
                "INNER JOIN dbo.Countries AS c ON a.CountryId = c.Id", SqlConnection);

            SqlDataReader = SqlCommand.ExecuteReader();

            var list = new List<Report1>();
            while (SqlDataReader.Read())
            {
                var row = new Report1
                {
                    FullName = Convert.ToString(SqlDataReader["FullName"]),
                    CountryName = Convert.ToString(SqlDataReader["CountryName"]),
                    Result = Convert.ToString(SqlDataReader["Result"])
                };
                list.Add(row);
            }

            Close();
            return list.AsQueryable();
        }

        public IQueryable<Report2> GetReport2Data()
        {
            Open();

            SqlCommand = new SqlCommand("SELECT c.Name AS[Name], AVG(DATEDIFF(YEAR, a.BirthDate, GETDATE())) AS[AverageAge] " +
                "FROM dbo.Athletes AS a " +
                "INNER JOIN dbo.Countries AS c ON a.CountryId = c.Id " +
                "GROUP BY c.Name", SqlConnection);

            SqlDataReader = SqlCommand.ExecuteReader();

            var list = new List<Report2>();
            while (SqlDataReader.Read())
            {
                var row = new Report2
                {
                    Name = Convert.ToString(SqlDataReader["Name"]),
                    AverageAge = Convert.ToInt32(SqlDataReader["AverageAge"])
                };
                list.Add(row);
            }

            Close();
            return list.AsQueryable();
        }

        public IQueryable<Report3> GetReport3Data(string date)
        {
            Open();

            SqlCommand = new SqlCommand($"SELECT * FROM dbo.GetScheduleByDate('{date}')", SqlConnection);

            SqlDataReader = SqlCommand.ExecuteReader();

            var list = new List<Report3>();
            while (SqlDataReader.Read())
            {
                var row = new Report3
                {
                    SportName = Convert.ToString(SqlDataReader["SportName"]),
                    StartDate = Convert.ToDateTime(SqlDataReader["StartDate"].ToString()).ToString("dd.MM.yyyy"),
                    StartTime = Convert.ToDateTime(SqlDataReader["StartTime"].ToString()).ToString("HH:mm"),
                    SportgroundName = Convert.ToString(SqlDataReader["SportgroundName"]),
                    Address = Convert.ToString(SqlDataReader["Address"])
                };
                list.Add(row);
            }

            Close();
            return list.AsQueryable();
        }

    }
}
