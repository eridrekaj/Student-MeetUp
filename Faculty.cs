using System;
using System.Collections.Generic;
using System.Text;

namespace Student_MeetUp
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Emri { get; set; }

        // Kjo sherben qe select-i te shfaqe Emrin e jo "DatingApp.Universiteti"
        public override string ToString() => Emri;
    
    }

}