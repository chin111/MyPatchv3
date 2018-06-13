using System;
using System.IO;

namespace MyPatchV3.DL
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using SQLite;
    using Newtonsoft.Json;

    using MyPatchV3.DL;
    using MyPatchV3.DL.Models;
    using MyPatchV3.BL.Contracts;
    using MyPatchV3.BL.Enums;
    using MyPatchV3.BL.Constants;
    using MyPatchV3.BL.Globals;
    using MyPatchV3.BL.Managers;

    using Xamarin.Forms;


    public sealed class MyPatchV3Database
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private SQLiteAsyncConnection database;

        private static volatile MyPatchV3Database sharedInstance;
        private static readonly object syncRoot = new object();

        /// <summary>
        /// Initializes a new instance of the GrocerManiaDatabase class.
        /// </summary>
        private MyPatchV3Database()
        {
            database = DependencyService.Get<IDBConnection>().GetConnection();
            Task.Run(() => CreateDatabaseAsync()).ConfigureAwait(false);
            Task.Run(() => InitializeDatabaseAsync()).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the shared instance.
        /// </summary>
        /// <value>The shared instance of GrocerManiaDatabase.</value>
        public static MyPatchV3Database SharedInstance
        {
            get
            {
                if (sharedInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (sharedInstance == null)
                            sharedInstance = new MyPatchV3Database();
                    }
                }

                return sharedInstance;
            }
        }

        static object locker = new object();

        public List<T> GetItems<T>() where T : class, IEntity, new()
        {
            lock (locker)
            {
                return database.Table<T>().ToListAsync().Result;
            }
        }

        public T GetItem<T>(int id) where T : class, IEntity, new()
        {
            lock (locker)
            {
                var query = database.Table<T>().Where(x => x.ID == id);
                var result = query.FirstOrDefaultAsync();

                return result.Result;
            }
        }

        /// <summary>
        /// Creates the database asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task CreateDatabaseAsync()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                //Create the Tables
                await database.CreateTableAsync<User>().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Initializes the database asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task InitializeDatabaseAsync()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                
            }
        }


    }
}

