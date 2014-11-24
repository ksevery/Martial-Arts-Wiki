using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parse;
using SQLite;

namespace MartialArtsWiki.Models
{
    public enum Categories
    {
        MartialArts = 0,
        FightingSports = 1
    }

    [Table("Category")]
    [ParseClassName("Category")]
    public class Category : ParseObject
    {
        private Categories categoryType;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public Categories CategoryType 
        {
            get 
            {
                return (Categories)this.CategoryInParse;
            }
            set 
            {
                this.CategoryInParse = (int)value; 
            }
        }

        [Ignore]
        [ParseFieldName("categoryType")]
        public int CategoryInParse
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }
    }
}
