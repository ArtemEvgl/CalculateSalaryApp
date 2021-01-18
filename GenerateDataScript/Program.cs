using System.IO;


namespace GenerateDataScript
{
    class Program
    {
        static void Main(string[] args)
        {

            string contents = "Иван;70000;Руководитель;30000\nПетр;50000;Штатный сотрудник;\nГлеб;1000;Фрилансер;\n";
            File.AppendAllText("..\\..\\..\\DataCSV\\employees.csv", contents);
        }
    }
}
