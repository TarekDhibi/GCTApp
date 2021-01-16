using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTApplication
{
    class journalArticle
    {
        //"symbole"  "anne" "moi" "jour" "action" "remarque"
        public int id { get; set; }
        public int idAdmin { get; set; }
        public int symbole { get; set; }
        public String anne{ get; set; }
        public String moi { get; set; }
        public String jour { get; set; }
        public String action { get; set; }
        public String remarque { get; set; }
        
        public journalArticle()
        {
            this.id=0;
            this.idAdmin=0;
            this.symbole=0;
            this.anne="";
            this.moi="";
            this.jour="";
            this.action="";
            this.remarque="";
        }
        public journalArticle(int id, int idAdmin, int symbole, String anne, String moi, String jour, String action, String remarque)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            if(symbole==null)
            {
                this.symbole = 0;
            }
            else
            {
                this.symbole = symbole;
            }
            
            this.anne = anne;
            this.moi = moi;
            this.jour = jour;
            this.action = action;
            this.remarque = remarque;
        }
    }
}
