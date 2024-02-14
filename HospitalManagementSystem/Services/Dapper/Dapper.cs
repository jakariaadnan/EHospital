using Dapper;
using HospitalManagementSystem.Services.Dapper.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Services.Dapper
{
    public class Dapper : IDapper
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "LAFConnection";

        public Dapper(IConfiguration config)
        {
            _config = config;
        }
        public void Dispose()
        {

        }

        public async Task<List<T>> FromSqlAsync<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            var query = SqlQuery.ToString();
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = await db.QueryAsync<T>(query, commandType: commandType);
            return result.ToList();
        }
        public List<T> FromSql<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = db.Query<T>(SqlQuery.ToString(), commandType: commandType);
            return result.ToList();
        }
        public async Task<T> FromSqlFirstOrDefaultAsync<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = await db.QueryFirstOrDefaultAsync<T>(SqlQuery.ToString(), commandType: commandType);
            return result;
        }
        public T FromSqlFirstOrDefault<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = db.QueryFirstOrDefault<T>(SqlQuery.ToString(), commandType: commandType);
            return result;
        }

        public async Task<T> FromSqlSingleOrDefaultAsync<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = await db.QuerySingleOrDefaultAsync<T>(SqlQuery.ToString(), commandType: commandType);
            return result;
        }
        public T FromSqlSingleOrDefault<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = db.QuerySingleOrDefault<T>(SqlQuery.ToString(), commandType: commandType);
            return result;
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }



        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
    }
}
