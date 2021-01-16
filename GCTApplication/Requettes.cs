using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GCTApplication
{
    class Requettes
    {
        public static int Authentification(String login, String mdp)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select id from personel where login = '" + login + "' and mdp = '" + mdp + "' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt16(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex.Message, "Erreur");
                return -1;
            }
            return id;
        }
        public static int LoginExiste(String login)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select id from personel where login = '" + login + "' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt16(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur");
                return -1;
            }
            return id;
        }
        public static int SymboleExiste(String symbole)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select symbole from article where symbole = " + symbole + " ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt16(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur");
                return -1;
            }
            return id;
        }
        public static int IdExiste(String idN)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select id from personel where id = " + idN + " ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt16(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur");
                return -1;
            }
            return id;
        }
        public static int IdArticleExiste(String idN)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select symbole from article where symbole = " + idN + " ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt16(0);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex.Message, "Erreur");
                return -1;
            }
            return id;
        }
        public static int nbApparenceJournal(int idd)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "SELECT COUNT(idp) FROM journalp WHERE idp="+idd+";";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt16(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur");
                return -1;
            }
            return id;
        }
        public static String GetNomFromIdAdmin(String idN)
        {
            String id = "";
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select nom from personel where id = '" + idN + "' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur");
                return "-1";
            }
            return id;
        }
        public static String GetRoleFromIdAdmin(String idN)
        {
            String id = "";
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select role from personel where id = '" + idN + "' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur");
                return "-1";
            }
            return id;
        }
        public static String GetLoginFromIdAdmin(String idN)
        {
            String id = "";
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select login from personel where id = '" + idN + "' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur");
                return "-1";
            }
            return id;
        }
        public static String GetMdpFromIdAdmin(String idN)
        {
            String id = "";
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select mdp from personel where id = '" + idN + "' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur");
                return "-1";
            }
            return id;
        }
        public static int AjouterPersonel(String nom, String role, String login, String mdp)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "INSERT INTO personel (nom, role, login, mdp) VALUES ('" + nom + "', '" + role + "', '" + login + "', '" + mdp + "'); ";
                cnx.com.CommandText = requette;
                cnx.com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message + ""+ex.Source, "Erreur");
                return -1;
            }
            return id;
        }
        public static int AjouterJournalArticle(int idAdmin, int symbole, String anne, String moi, String jour, String action, String remarque)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "INSERT INTO journalarticle (idadmin, symbole, anne, moi, jour, action, stock) VALUES (" + idAdmin + ", '" + symbole + "', '" + anne + "', '" + moi + "', '" + jour + "', '" + action + "', '" + remarque + "')";
                cnx.com.CommandText = requette;
                cnx.com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message + "" + ex.Source, "Erreur");
                return -1;
            }
            return id;
        }
        public static int SymboleExisteJournalArticle(String symbole)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "select symbole from journalarticle where symbole = '" + symbole + "' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt16(0);
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("" + ex.Message, "Erreur");
                return -1;
            }
            return id;
        }
        public static int AjouterArticle(int symbole, String description, float besoin, float stock, float ratio, float sa, float smdhila, float sskhira, String designation, String format, String episseur)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "INSERT INTO article (symbole, description, besoin, stock, ratio, sa, smdhilla, sskhira, designation, format, episseur) VALUES (" + symbole + ", '" + description + "', " + besoin + ", " + stock + ", '" + ratio + "', " + sa + ", " + smdhila + ", " + sskhira + ", '" + designation + "', '" + format + "', '" + episseur + "'); ";
                cnx.com.CommandText = requette;
                cnx.com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message + "" + ex.Source, "Erreur");
                return -1;
            }
            return id;
        }
        public static int AjouterJournal(int idp, String tache)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "INSERT INTO journalp (idp, tache) VALUES (" + idp + ", '" + tache + "'); ";
                cnx.com.CommandText = requette;
                cnx.com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("<>" + ex.Message + "" + ex.Source, "Erreur");
                return -1;
            }
            return id;
        }
        public static int ModifierPersonel(String idd, String nom, String role, String login, String mdp)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "UPDATE personel SET nom = '" + nom + "', role = '" + role + "', login = '" + login + "', mdp = '" + mdp + "' WHERE id="+idd+"; ";
                cnx.com.CommandText = requette;
                cnx.com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message + "" + ex.Source, "Erreur");
                return -1;
            }
            return id;
        }
        public static int ModifierArticle(int symbole, String description, float besoin, float stock, float ratio, float sa, float smdhila, float sskhira, String designation, String format, String episseur)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "UPDATE article SET description = '" + description + "', besoin = " + besoin + ", stock=" + stock + ", ratio='" + ratio + "', sa=" + sa + ", smdhilla=" + smdhila + ", sskhira=" + sskhira + ", designation='" + designation + "', format='" + format + "', episseur='" + episseur + "' WHERE symbole=" + symbole + "; ";
                cnx.com.CommandText = requette;
                cnx.com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex.Message + "" + ex.Source, "Erreur");
                return -1;
            }
            return id;
        }
        public static int SupprimerPersonel(int idd)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "DELETE FROM personel WHERE id=" + idd + "; ";
                cnx.com.CommandText = requette;
                cnx.com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message + "" + ex.Source, "Erreur");
                return -1;
            }
            return id;
        }
        public static int SupprimerArticle(int idd)
        {
            int id = 0;
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "DELETE FROM article WHERE symbole=" + idd + "; ";
                cnx.com.CommandText = requette;
                cnx.com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message + "" + ex.Source, "Erreur");
                return -1;
            }
            return id;
        }
        public static List<Personel> getAllPersonels()
        {
            List<Personel> liste = new List<Personel>();
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "SELECT id, nom, role, login, mdp from personel; ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new Personel()
                    {
                        id = reader.GetInt16(0),
                        nom = reader.GetString(1),
                        role = reader.GetString(2),
                        login = reader.GetString(3),
                        pass = reader.GetString(4)
                    });
                }
                return liste;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message + "" + e.Source, "Erreur");
                return null;
            }
        }
        public static List<journalArticle> getAllJournalArticle()
        {
            List<journalArticle> liste = new List<journalArticle>();
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "SELECT id, idadmin, symbole, anne, moi, jour, action, stock from journalarticle";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new journalArticle()
                    {
                        id = reader.GetInt16(0),
                        idAdmin = reader.GetInt16(1),
                        symbole = Int16.Parse(reader.GetString(2)),
                        anne = reader.GetString(3),
                        moi = reader.GetString(4),
                        jour = reader.GetString(5),
                        action = reader.GetString(6),
                        remarque = reader.GetString(7)
                    });
                }
                return liste;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message + "" + e.Source, "Erreur");
                return null;
            }
        }
        public static List<journalArticle> getAllJournalArticle(String champ, String texte)
        {
            List<journalArticle> liste = new List<journalArticle>();
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "SELECT  id, idadmin, symbole, anne, moi, jour, action, stock from journalarticle WHERE " + champ + " like '%" + texte + "%' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new journalArticle()
                    {
                        id = reader.GetInt16(0),
                        idAdmin = reader.GetInt16(1),
                        symbole = Int16.Parse(reader.GetString(2)),
                        anne = reader.GetString(3),
                        moi = reader.GetString(4),
                        jour = reader.GetString(5),
                        action = reader.GetString(6),
                        remarque = reader.GetString(7)
                    });
                }
                return liste;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message + "" + e.Source, "Erreur");
                return null;
            }
        }
        public static List<journalArticle> getAllJournalArticleBySymbole(String texte)
        {
            List<journalArticle> liste = new List<journalArticle>();
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                // journalarticle id ,idadmin,symbole,anne,moi,jour,action,stock
                String requette = "SELECT  id, idadmin, symbole, anne, moi, jour, action, stock from journalarticle WHERE symbole = '" + texte + "' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new journalArticle()
                    {
                        id = reader.GetInt16(0),
                        idAdmin = reader.GetInt16(1),
                        symbole = Int16.Parse(reader.GetString(2)),
                        anne = reader.GetString(3),
                        moi = reader.GetString(4),
                        jour = reader.GetString(5),
                        action = reader.GetString(6),
                        remarque = reader.GetString(7)
                    });
                }
                return liste;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message + "" + e.Source, "Erreur");
                return null;
            }
        }
        public static List<Article> getAllArticle()
        {
            List<Article> liste = new List<Article>();
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "SELECT symbole, description, besoin, stock, ratio, sa, smdhilla, sskhira, designation, format, episseur from article";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new Article()
                    {
                        symbole = reader.GetInt16(0),
                        description = reader.GetString(1),
                        besoin = reader.GetFloat(2),
                        stock = reader.GetFloat(3),
                        ratio = reader.GetString(4),
                        sa = reader.GetFloat(5),
                        smdhilla = reader.GetFloat(6),
                        sskhira = reader.GetFloat(7),
                        designation = reader.GetString(8),
                        format = reader.GetString(9),
                        episseur = reader.GetString(10)
                    });
                }
                return liste;
            }
            catch (Exception e)
            {
               // MessageBox.Show("" + e.Message + "" + e.Source, "Erreur");
                return null;
            }
        }
        public static List<Article> getAllArticle(String champ, String texte)
        {
            List<Article> liste = new List<Article>();
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "SELECT symbole, description, besoin, stock, ratio, sa, smdhilla, sskhira, designation, format, episseur from article  WHERE " + champ + " like '%" + texte + "%' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new Article()
                    {
                        symbole = reader.GetInt16(0),
                        description = reader.GetString(1),
                        besoin = reader.GetFloat(2),
                        stock = reader.GetFloat(3),
                        ratio = reader.GetString(4),
                        sa = reader.GetFloat(5),
                        smdhilla = reader.GetFloat(6),
                        sskhira = reader.GetFloat(7),
                        designation = reader.GetString(8),
                        format = reader.GetString(9),
                        episseur = reader.GetString(10)
                    });
                }
                return liste;
            }
            catch (Exception e)
            {
               //   MessageBox.Show("" + e.Message + "" + e.Source, "Erreur");
                return null;
            }
        }
        public static List<journalP> getAllJournals()
        {
            List<journalP> liste = new List<journalP>();
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "SELECT id, idp, tache from journalp; ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new journalP()
                    {
                        id = reader.GetInt16(0),
                        idP = reader.GetInt16(1),
                        tache = reader.GetString(2)
                    });
                }
                return liste;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message + "" + e.Source, "Erreur");
                return null;
            }
        }
        public static List<journalP> getAllJournals(String champ, String texte)
        {
            List<journalP> liste = new List<journalP>();
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "SELECT id, idp, tache from journalp  WHERE " + champ + " like '%" + texte + "%' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new journalP()
                    {
                        id = reader.GetInt16(0),
                        idP = reader.GetInt16(1),
                        tache = reader.GetString(2)
                    });
                }
                return liste;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message + "" + e.Source, "Erreur");
                return null;
            }
        }
        public static List<Personel> getAllPersonels(String champ, String texte)
        {
            List<Personel> liste = new List<Personel>();
            try
            {
                SQLConnexion cnx = new SQLConnexion();
                //cnx.OpenConnection();
                String requette = "SELECT id, nom, role, login, mdp from personel WHERE "+champ+" like '%"+texte+"%' ";
                cnx.com.CommandText = requette;
                SQLiteDataReader reader = cnx.com.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new Personel()
                    {
                        id = reader.GetInt16(0),
                        nom = reader.GetString(1),
                        role = reader.GetString(2),
                        login = reader.GetString(3),
                        pass = reader.GetString(4)
                    });
                }
                return liste;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message + "" + e.Source, "Erreur");
                return null;
            }
        }
    }
}
