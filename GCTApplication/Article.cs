
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTApplication
{
    class Article
    {
        public int symbole { get; set; }
        public String description { get; set; }
        public float besoin { get; set; }
        public float stock { get; set; }
        public String ratio { get; set; }
        public float sa { get; set; }
        public float smdhilla { get; set; }
        public float sskhira { get; set; }
        public String designation { get; set; }
        public String format { get; set; }
        public String episseur { get; set; }

        public Article()
        {
            this.symbole = 0;
            this.description = String.Empty;
            this.besoin = 0;
            this.stock = 0;
            this.ratio = "";
            this.sa = 0;
            this.smdhilla = 0;
            this.sskhira = 0;
            this.designation = String.Empty;
            this.format = String.Empty;
            this.episseur = String.Empty;
        }
        public Article(int symbole, String description, float besoin, float stock, String ratio, float sa, float smdhila, float sskhira, String designation, String format, String episseur)
        {
            this.symbole = symbole;
            this.description = description;
            this.besoin = besoin;
            this.stock = stock;
            this.ratio = ratio;
            this.sa = sa;
            this.smdhilla = smdhila;
            this.sskhira = sskhira;
            this.designation = designation;
            this.format = format;
            this.episseur = episseur;
        }
    }
}
