using Dapper;
using tester.api.Infrastructure.Models.Main;
using tester.api.Infrastructure.Models.Tests;
using tester.api.Infrastructure.Models.Helpers;
using tester.api.Infrastructure.Data.Interface.Main;

namespace tester.api.Infrastructure.Data.Repo.Main
{
    public class MainRepository : AppSettings, IMain
    {
        public async Task<Flagger> GetFlaggerRound(int? round, int? difficulty, string? prevFlag)
        {
            try
            {
                string query = $@"select * from flags f where f.difficulty <= {difficulty} and f.country NOT LIKE ALL(ARRAY[{prevFlag ?? "' '"}]) order by RANDOM() LIMIT 4;";
                using (var connection = GetConnection)
                {
                    var res = await connection.QueryAsync<Flags>(query);
                    var newRound = new Flagger();
                    newRound.Round += round.HasValue ? round.Value : 1;
                    newRound.Flags = res.ToList();
                    var random = new Random();
                    int index = random.Next(res.ToList().Count);
                    newRound.Correct = res.ToList()[index];
                    return newRound;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Langger> GetLanggerRound(int? round, int? difficulty, string? prevLang)
        {
            try
            {
                string query = $@"select * from languages f where f.difficulty <= {difficulty} and f.language NOT LIKE ALL(ARRAY[{prevLang ?? "' '"}]) order by RANDOM() LIMIT 4;";
                using (var connection = GetConnection)
                {
                    var res = await connection.QueryAsync<Languages>(query);
                    var newRound = new Langger();
                    newRound.Round += round.HasValue ? round.Value : 1;
                    newRound.Languages = res.ToList();
                    var random = new Random();
                    int index = random.Next(res.ToList().Count);
                    newRound.Correct = res.ToList()[index];
                    return newRound;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
