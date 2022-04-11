using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FPProjectStudentSuccess.Entities;
using FPProjectStudentSuccessBSA.Data;
using IGDB;
using IGDB.Models;

namespace FPProjectStudentSuccessBSA.Service
{
    public class IGDBService
    {
        public static SQLConnectionConfig _conn;
        public SqlConnection connection;
        public IGDBService(SQLConnectionConfig conn)
        {
            _conn = conn;
            connection = new SqlConnection(_conn.Value);
        }
        public async Task<List<Product>> GetIGDB(string gamename)
        {
            List<Product> IGDBList = new List<Product>();

            //IGDB authentication
            string id;
            string key;

            IGDBClient igdb = new IGDBClient(
            id = "40qvr1xgdik3vrgmpv01ecmjsa7vxd",
            key = "gskpm91w1b5cll78hws2nhvjbewaul"
           );


            //Game query and validation
            string gameName = gamename;
            var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields name, " +
                $"involved_companies,release_dates; search \"{gameName}\";");
            
            //Keep within free account requests
            var gamesDistincts = games.Distinct().Take(5);

            foreach (var g in gamesDistincts)
            {
                string date;
                string companieN;
                string dateYearFinal;
                Product newGame = new Product();

                //Validates/clean data
                if (g.ReleaseDates != null)
                {
                    var releaseDate = await igdb.QueryAsync<ReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields date; where id = {g.ReleaseDates.Ids.GetValue(0)};");
                    var rD = releaseDate.First();
                    date = rD.Date.ToString();
                    string[] dateSplit = date.Split(' ');
                    string[] dateYear = dateSplit[0].Split('/');
                    if (dateYear.Length < 2)
                    {
                        dateYearFinal = "2022";
                    }
                    else
                    {
                        dateYearFinal = dateYear[2];
                    }
                }
                else
                {
                    dateYearFinal = "2022";
                }
                if (g.InvolvedCompanies != null)
                {
                    var gamesInvolvedCompany = await igdb.QueryAsync<InvolvedCompany>(IGDBClient.Endpoints.InvolvedCompanies, query: $"fields company; where id = {g.InvolvedCompanies.Ids.GetValue(0)};");
                    var comp = gamesInvolvedCompany.First();
                    var gamesCompany = await igdb.QueryAsync<Company>(IGDBClient.Endpoints.Companies, query: $"fields name; where id = {comp.Company.Id};");
                    var compN = gamesCompany.First();
                    companieN = compN.Name;
                }
                else
                {
                    companieN = "";
                }
                newGame.Name = g.Name;
                newGame.Publisher = companieN;
                newGame.PlataformId = 3;
                newGame.Quantity = 0;
                newGame.Year = Convert.ToInt32(dateYearFinal);
                newGame.Price = 0;
                newGame.ShelfId = 2;

                //add to List to display on views
                IGDBList.Add(newGame);
            }
        return IGDBList;
        }
    }
}
