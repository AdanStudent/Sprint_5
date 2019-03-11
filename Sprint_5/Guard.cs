using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_5
{
    public class Guard
    {
        public float Hours { get; set; }

        public string Name { get; set; }

        private bool IsWorking;

        private int MaxHours;

        public Guard(float h, string n)
        {
            Hours = h;
            Name = n;
            MaxHours = 40;
            this.IsWorking = false;
        }

        public void ClockIn()
        {
            if (!IsWorking && Hours <= MaxHours)
            {
                this.IsWorking = true;
            }
        }

        public void ClockOut()
        {
            if (IsWorking || Hours <= MaxHours)
            {
                this.IsWorking = false;
            }
        }

        public string LogHours()
        {
            return $"{this.Name} has worked {this.Hours} this week.";
        }

    }
}
