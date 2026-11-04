using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU26_Counter.Models
{
    class AllCounters
    {
        public ObservableCollection<Counter> Counters { get; set; } = [];

        public AllCounters() =>
            LoadCounters();

        public void LoadCounters()
        {
            Counters.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Counter> counters = Directory
                .EnumerateFiles(appDataPath, "*.counters.txt")
                .Select(filename => new Counter()
                {
                    Filename = filename,
                    CountValue = int.Parse(File.ReadAllLines(filename)[0]),
                    Text = File.ReadAllLines(filename)[1]
                });
            foreach (Counter counter in counters)
            {
                Counters.Add(counter);
            }
        }
    }
}
