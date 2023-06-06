﻿using Dapper;
using tester.api.Infrastructure.Models.Main;
using tester.api.Infrastructure.Models.Helpers;
using tester.api.Infrastructure.Data.Interface.Main;

namespace tester.api.Infrastructure.Data.Repo.Main
{
    public class MainRepository : AppSettings, IMain
    {
        public async Task<Flags> GetRandomFlag(int? difficulty)
        {
            try
            {
                string query = $@"select * from flags f where f.difficulty = {difficulty} order by RANDOM() LIMIT 1;";

                using (var connection = GetConnection)
                {
                    var res = await connection.QueryFirstOrDefaultAsync<Flags>(query);
                    return res;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Flags>> GetCountries()
        {
            try
            {
                string query = $@"Select f.country from flags f;";

                using (var connection = GetConnection)
                {
                    var res = await connection.QueryAsync<Flags>(query);
                    return res.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
