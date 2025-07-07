using AndradeEexamen3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndradeEexamen3.Services
{
    class VehiculoDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public VehiculoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Vehiculo>().Wait();
        }

        public Task<List<Vehiculo>> GetVehiculosAsync() =>
            _database.Table<Vehiculo>().ToListAsync();

        public Task<int> SaveVehiculoAsync(Vehiculo vehiculo) =>
            _database.InsertAsync(vehiculo);
    }
}
