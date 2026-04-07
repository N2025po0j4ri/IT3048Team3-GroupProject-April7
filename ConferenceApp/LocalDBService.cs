using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceApp
{
    public class LocalDBService
    {
        private const string DB_NAME = "demo_db.db4";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Session>();

        }

        public async Task<List<Session>> GetSessions()
        {
            return await _connection.Table<Session>().ToListAsync();
        }
        public async Task<Session> GetById(int id)
        {
            return await _connection.Table<Session>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Session session)
        {
            await _connection.InsertAsync(session);
        }

        public async Task Update(Session session)
        {
            await _connection.UpdateAsync(session);
        }

        public async Task Delete(Session session)
        {
            await _connection.DeleteAsync(session);
        }
    }
}

