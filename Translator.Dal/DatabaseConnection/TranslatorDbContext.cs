using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Entity;


namespace Translator.Dal.DatabaseConnection
{
    public class TranslatorDbContext : DbContext
    {
        public DbSet<TranslationLog> TranslationLogs { get; set; }
    }
}
