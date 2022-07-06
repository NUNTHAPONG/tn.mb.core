using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Web.Models
{
    public partial class CleanDbContext : DbContext
    {
        public Task<int> ExecuteAsync(string sql, object param = null, CancellationToken token = default, bool isStore = false)
        {
            return this.Database.GetDbConnection().ExecuteAsync(new CommandDefinition(sql, param, cancellationToken: token, commandType: isStore ? CommandType.StoredProcedure : CommandType.Text));
        }

        public Task<T> ExecuteScalarAsync<T>(string sql, object param = null, CancellationToken token = default, bool isStore = false)
        {
            return this.Database.GetDbConnection().ExecuteScalarAsync<T>(new CommandDefinition(sql, param, cancellationToken: token, commandType: isStore ? CommandType.StoredProcedure : CommandType.Text));
        }

        public Task<T> QueryFirstAsync<T>(string sql, object param = null, CancellationToken token = default, bool isStore = false)
        {
            return this.Database.GetDbConnection().QueryFirstAsync<T>(new CommandDefinition(sql, param, cancellationToken: token, commandType: isStore ? CommandType.StoredProcedure : CommandType.Text));
        }

        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CancellationToken token = default, bool isStore = false)
        {
            return this.Database.GetDbConnection().QueryFirstOrDefaultAsync<T>(new CommandDefinition(sql, param, cancellationToken: token, commandType: isStore ? CommandType.StoredProcedure : CommandType.Text));
        }

        public Task<T> QuerySingleAsync<T>(string sql, object param = null, CancellationToken token = default, bool isStore = false)
        {
            return this.Database.GetDbConnection().QuerySingleAsync<T>(new CommandDefinition(sql, param, cancellationToken: token, commandType: isStore ? CommandType.StoredProcedure : CommandType.Text));
        }

        public Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, CancellationToken token = default, bool isStore = false)
        {
            return this.Database.GetDbConnection().QuerySingleOrDefaultAsync<T>(new CommandDefinition(sql, param, cancellationToken: token, commandType: isStore ? CommandType.StoredProcedure : CommandType.Text));
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CancellationToken token = default, bool isStore = false)
        {
            return this.Database.GetDbConnection().QueryAsync<T>(new CommandDefinition(sql, param, cancellationToken: token, commandType: isStore ? CommandType.StoredProcedure : CommandType.Text));
        }

    }
}
