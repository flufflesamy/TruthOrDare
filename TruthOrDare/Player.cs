using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDare
{
    class Player
    {
        public String Name { get; set; }
        public Player PlayerPicked { get; set; }
        public int Roll { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }

        public Player(string name, int roll)
        {
            this.Name = name;
            this.Roll = roll;
        }
    }
}
