using System;
using System.IO;
using System.Linq;

using TestUppgiftSphinxly.Interfaces;


namespace TestUppgiftSphinxly.Repositories
{
    public class VisitorsRepositoryCSV : IVisitorsRepository
    {
        private readonly string _file;

        public VisitorsRepositoryCSV()
        {
            _file = AppDomain.CurrentDomain.BaseDirectory + "DataStorage/VisitorsFile.CSV";
        }

        public bool CheckIfVisitorIsSaved(string name)
        {
            if (!File.Exists(_file))
            {
                File.WriteAllText(_file, name);
                return false;
            }

            using (var reader = new StreamReader(_file))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if(line == name)
                    {
                        return true;
                    }
                } 
            }
            return false;
        }
          
        public void SaveVisitor(string name)
        {
            using (var stream = File.AppendText(_file))
            {
                stream.WriteLine(name);
            }
        }

        public void DeleteVisitor(string name)
        {          
            var lines = File.ReadAllLines(_file).ToList();
            var i = 0;
            foreach (var line in lines)
            {                
                if(line == name)
                {
                    break;
                }
                i++;
            }
            lines.RemoveAt(i);
            File.WriteAllLines(_file, lines);
        }
    }
}