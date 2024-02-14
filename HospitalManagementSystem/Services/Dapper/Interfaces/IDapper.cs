using Dapper;
using System.Data;
using System.Data.Common;

namespace HospitalManagementSystem.Services.Dapper.Interfaces
{
    public interface IDapper : IDisposable
    {
        DbConnection GetDbconnection();
        List<T> FromSql<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text);
        Task<List<T>> FromSqlAsync<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text);
        //Task<List<T>> FromSqlAsync<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text);
        Task<T> FromSqlFirstOrDefaultAsync<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text);
        Task<T> FromSqlSingleOrDefaultAsync<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text);
        T FromSqlFirstOrDefault<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text);
        T FromSqlSingleOrDefault<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text);
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    }
}
