using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTApplication
{
    class AreaDataCollection : System.Collections.ObjectModel.Collection<AreaData>
    {
        public AreaDataCollection()
        {
            Add(new AreaData { Date = new DateTime(2008, 8, 4) });
            Add(new AreaData { Date = new DateTime(2008, 8, 5) });
            Add(new AreaData { Date = new DateTime(2008, 8, 6) });
            Add(new AreaData { Date = new DateTime(2008, 8, 7) });
            Add(new AreaData { Date = new DateTime(2008, 8, 8) });
        }
    }
}
