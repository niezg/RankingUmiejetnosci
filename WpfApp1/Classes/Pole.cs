using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
     class Pole : IComparable<Pole>
    {
        public string Name { get; set; }
        public int Punkty { get; set; }
        public int ID { get; set; }
        public int[] Compare = new int[10];

        public Pole()
        {
            Punkty = 0;
            
        }

        public void AddPunkt() => ++Punkty;

        public int CompareTo(Pole other)
        {

            
            if (Punkty > other.Punkty)
            {
                return 1;
            }
            else if(Punkty < other.Punkty)
            {
                return -1;
            }
            else
            {
               if ( Compare[other.ID] == 1)
                 return 1;
                else return -1;

            }
            
        }
    }
    
}
