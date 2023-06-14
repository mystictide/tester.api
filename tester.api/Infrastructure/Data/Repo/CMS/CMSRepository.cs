using Dapper;
using tester.api.Infrastructure.Models.Main;
using tester.api.Infrastructure.Models.Helpers;
using tester.api.Infrastructure.Data.Interface.CMS;

namespace tester.api.Infrastructure.Data.Repo.Main
{
    public class CMSRepository : AppSettings, ICMS
    {
        public async Task<Flags> ManageFlag(Flags entity)
        {
            try
            {
                dynamic identity = entity.ID.HasValue ? entity.ID.Value : "default";

                if (entity.Country.Contains("'"))
                {
                    entity.Country = entity.Country.Replace("'", "''");
                }

                string query = $@"
                INSERT INTO flags (id, country, difficulty, url)
	 	                VALUES (
                {identity}, '{entity.Country}', '{entity.Difficulty}', '{entity.URL}')
                ON CONFLICT (id) DO UPDATE 
                SET country = '
                {entity.Country}',
                       difficulty = '
                {entity.Difficulty}',
                       url = '
                {entity.URL}'
                RETURNING *;";

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

        public async Task<Languages> ManageLanguage(Languages entity)
        {
            try
            {
                dynamic identity = entity.ID.HasValue ? entity.ID.Value : "default";

                if (entity.Language.Contains("'"))
                {
                    entity.Language = entity.Language.Replace("'", "''");
                }

                string query = $@"
                INSERT INTO languages (id, language, difficulty, url)
	 	                VALUES (
                {identity}, '{entity.Language}', '{entity.Difficulty}', '{entity.URL}')
                ON CONFLICT (id) DO UPDATE 
                SET language = '
                {entity.Language}',
                       difficulty = '
                {entity.Difficulty}',
                       url = '
                {entity.URL}'
                RETURNING *;";

                using (var connection = GetConnection)
                {
                    var res = await connection.QueryFirstOrDefaultAsync<Languages>(query);
                    return res;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
