using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    class epitoanyag
    {
        public  double suly { get; set; }
        public  string nev { get; set; }
        public  int ar { get; set; }
    }
    class tegla : epitoanyag
    {
        public string ttipus { get; set; }
        public string szin { get; set; }
    }
    class fa : epitoanyag
    {
        public string anyag { get; set; }
        public float kemenyseg { get; set; }
    }
    class vas : epitoanyag
    {
        public string vtipus { get; set; }
        public float suruseg { get; set; }
    }
}
