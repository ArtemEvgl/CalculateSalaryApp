using CalculateSalaryApp.Domain;
using CalculateSalaryApp.Domain.Models;
using System.IO;

namespace DataAccess
{
    class TimesheetRepository : ITimesheetRepository
    {
        private readonly char _delimeter;
        private readonly string _path;

        public TimesheetRepository(char delimiter, string path)
        {
            _delimeter = delimiter;
            _path = path;
        }
        
        public void Add(TimeLog timeLog)
        {
            string dataRow = $"{timeLog.Date}{_delimeter}{timeLog.LastName}{_delimeter}" +
                                $"{timeLog.WrokingHours}{_delimeter}{timeLog.Comment}\n";
            File.AppendAllText(_path, dataRow);
        }

        public TimeLog[] GetTimeLogs(string lastName)
        {
            throw new System.NotImplementedException();
        }
    }
}
