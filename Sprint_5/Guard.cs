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

        public Guard(float hours, string name)
        {
            Hours = hours;
            Name = name;
            MaxHours = 40;
            this.IsWorking = false;
        }

        public void ClockIn()
        {
            if (!IsWorking && Hours <= MaxHours)
            {
                this.IsWorking = true;
                this.Hours += 8;
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
