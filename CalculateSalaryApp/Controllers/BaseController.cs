using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Controllers
{
    public class BaseController
    {

        

        readonly IDataWorker dataWorker = new JsonDataWorker();
        public void Save<T>(List<T> employees, string fileName) where T : class
        {
            dataWorker.Save<T>(employees ,fileName);
        }

        public List<T> Load<T>(string fileName) where T : class
        {
            return dataWorker.Load<T>(fileName);
        }
    }
}
