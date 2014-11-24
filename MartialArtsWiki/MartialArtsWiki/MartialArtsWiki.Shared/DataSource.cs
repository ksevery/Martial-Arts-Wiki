using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Parse;

using MartialArtsWiki.Models;
using System.Threading.Tasks;
using SQLite;
using MartialArtsWiki.ViewModels;

namespace MartialArtsWiki
{
    public class DataSource
    {
        private const string DbName = "MartialArts.db";

        private static DataSource instance;

        private DataSource ()
        {
            this.CreateSqliteDatabase();
        }

        public static DataSource Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataSource();
                }

                return instance;
            }
        }

        public SQLiteAsyncConnection SqliteConnection { get; set; }

        private IEnumerable<Category> Categories{ get; set; }

        public async Task<Category> GetCategory (Categories categoryType)
        {
            if (this.Categories == null)
            {
                var categories = await new ParseQuery<Category>()
                .FindAsync();

                this.Categories = categories;
            }

            return this.Categories.First(c => c.CategoryType == categoryType);
        }

        public async Task<IEnumerable<MartialArtViewModel>> GetLocalMartialArts ()
        {
            var martialArts = await this.SqliteConnection.Table<MartialArtViewModel>().ToListAsync();
            return martialArts;
        }

        public async Task<bool> AddMartialArtToLocal (MartialArtViewModel martialArt)
        {
            int key = await this.SqliteConnection.InsertAsync(martialArt);
            if (key == null)
            {
                return false;
            }

            return true;
        }

        private async void CreateSqliteDatabase ()
        {
            if (this.SqliteConnection != null)
            {
                return;
            }

            this.SqliteConnection = new SQLiteAsyncConnection(DbName);
            await this.SqliteConnection.CreateTableAsync<MartialArtViewModel>();
        }
    }
}
