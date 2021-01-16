using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTApplication
{
    class journalP
    {
        public int id { get; set; }
        public int idP { get; set; }
        public String tache { get; set; }
        public journalP()
        {
            this.id = 0;
            this.idP = 0;
            this.tache = "";
        }
        public journalP(int id)
        {
            this.id = id;
            this.idP = 0;
            this.tache = "";
        }
        public journalP(int id, int idp)
        {
            this.id = id;
            this.idP = idp;
            this.tache = "";
        }
        public journalP(int id, int idp, String tache)
        {
            this.id = id;
            this.idP = idp;
            this.tache = tache;
        }
    }
}
