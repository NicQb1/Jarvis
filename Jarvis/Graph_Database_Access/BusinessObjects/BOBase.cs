using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.BusinessObjects
{
    public abstract class BOBase
    {
        public int currentExitation;
        public int firePoint;
        public DateTime? lastFired;
        public int Id;
        public string propertyValue;
    }
}
