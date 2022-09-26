using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BeeHive
{
    internal class Queen : Bee, INotifyPropertyChanged
    {
        const float EGGS_PER_SHIFT = 0.45F;
        const float HONEY_PER_UNASSIGNED_WORKER = 0.5F;

        public string StatusReport
        {
            get; private set;
        }

        public override float CostPerShift {
            get
            {
                return 2.15f;
            }
        }

        public float Eggs
        {
            get => eggs;
            set => eggs = value;
        }

        private float eggs;


        private IWorker[] workers;
        private float unassignedWorkers=3;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Queen() : base("Królowa")
        {
            StatusReport = "";
            workers = Array.Empty<IWorker>();
            AssighBee("Opiekunka jaj");
            AssighBee("Zbieraczka nektaru");
            AssighBee("Producentka miodu");

        }

        public void AssighBee(string job)
        {
            switch (job)
            {
                case "Opiekunka jaj":
                    AddWorker(new EggCare(this));
                    break;
                case "Zbieraczka nektaru":
                    AddWorker(new NectarCollector());
                    break;
                case "Producentka miodu":
                    AddWorker(new HoneyManufacturer());
                    break;
            }
            UpdateStatusReport();
        }

        void AddWorker(IWorker worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (Eggs >= eggsToConvert)
            {
                Eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }
        protected override void DoJob()
        {
            Eggs += EGGS_PER_SHIFT;
            foreach (IWorker worker in workers)
            {
                worker.WorkNextShift();
            }
            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();

        }

        private void UpdateStatusReport()
        {
            string report = HoneyVault.StatusReport;

            report += $"\n\nLiczba jaj: {Eggs:0.00}\nNieprzydzielone robotnice: {unassignedWorkers:0.00}";
            report += WorkerStatus("Opiekunka jaj");
            report += WorkerStatus("Zbieraczka nektaru");
            report += WorkerStatus("Producentka miodu");
            report += $"\nROBOTNICE W SUMIE: {workers.Length}";
            StatusReport = report;
           // OnPropertyChanged("StatusReport");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatusReport)));
        }

        private string WorkerStatus(string job)
        {
            int numberOfWorkers = 0;
            foreach (IWorker worker in workers)
            {
                if (worker.Job == job)
                {
                    numberOfWorkers++;
                }
            }


            return $"\n{job}: {numberOfWorkers}";
        }

        protected void OnPropertyChanged(string name)
        {
       // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
       
    }
}
