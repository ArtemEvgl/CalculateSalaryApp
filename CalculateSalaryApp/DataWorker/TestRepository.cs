using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.DataWorker
{
    /// <summary>
    /// Репозиторий для тестов, можно создать коллекция побыстрому
    /// </summary>
    public class TestRepository : IRepository
    {
        public List<T> Load<T>(string fileName) where T : class
        {
            throw new NotImplementedException();
        }

        public void Save<T>(List<T> employees, string fileName) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
