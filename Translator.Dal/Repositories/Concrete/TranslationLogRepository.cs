using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Core.RepositoryCore.Concrete;
using Translator.Dal.Repositories.Abstract;
using Translator.Entity;

namespace Translator.Dal.Repositories.Concrete
{
    public class TranslationLogRepository : BaseRepository<TranslationLog>,ITranslationLogRepository
    {
        public TranslationLogRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
