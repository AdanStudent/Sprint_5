using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_5
{
    public class ViewModelGuard
    {
        private static ObservableCollection<WPF_Guard> guards;

        public ObservableCollection<WPF_Guard> Guards
        {
            get { return guards; }
            set { guards = value; }
        }

        public void LoadGuards()
        {
            if (guards == null)
            {
                guards = new ObservableCollection<WPF_Guard>()
                {
                    new WPF_Guard (new Guard(10, "Jeff")),
                    new WPF_Guard (new Guard(3, "Adrian"))
                };
            }

            Guards = guards;
        }

    }
}
