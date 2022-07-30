using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator.Core.RepositoryCore.Abstract
{
    public interface IBaseRepository<T> where T : EntityCore
    {
        void Insert(T entity);
        void Update(T entity);
        T GetByExpression(Func<T, bool> Expression);

        List<T> GetAll();
    }
    
}
