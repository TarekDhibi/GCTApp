using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTApplication
{
    class Personel
    {
        /// <summary>
        /// identifiant du personel
        /// </summary>
        public int id {get; set;}
        /// <summary>
        /// nom du personel
        /// </summary>
        public String nom { get; set; }
        /// <summary>
        /// role du personel M directeur ou tech (technecien)
        /// </summary>
        public String role { get; set; }
        /// <summary>
        /// login du personel
        /// </summary>
        public String login { get; set; }
        /// <summary>
        /// mot de passe du personel
        /// </summary>
        public String pass { get; set; }

        /// <summary>
        /// constructeur par defaut.
        /// </summary>

        public Personel()
        {
            this.id = 0;
            this.nom = "";
            this.role = "";
            this.login = "";
            this.pass = "";
        }
        /// <summary>
        /// constructeur avec un seul parametre
        /// </summary>
        /// <param name="id">identifiant de type entier</param>
        public Personel(int id)
        {
            this.id = id;
            this.nom = "";
            this.role = "";
            this.login = "";
            this.pass = "";
        }
        /// <summary>
        /// constructeur avec deux parametres
        /// </summary>
        /// <param name="log">login du personel de type chaine de caractere</param>
        /// <param name="pass">mot de passe de type chaine de caractere</param>
        public Personel(String log, String pass)
        {
            this.id = 0;
            this.nom = "";
            this.role = "";
            this.login = log;
            this.pass = pass;
        }
        /// <summary>
        /// constructeur a trois parametres
        /// </summary>
        /// <param name="id">identifiant de type entier</param>
        /// <param name="log">login de type chaine</param>
        /// <param name="pass">mot de passe de type chaine</param>
        public Personel(int id, String log, String pass)
        {
            this.id = id;
            this.nom = "";
            this.role = "";
            this.login = log;
            this.pass = pass;
        }
        /// <summary>
        /// constructeur avec 4 parametre
        /// </summary>
        /// <param name="id">identifiant de type entier</param>
        /// <param name="nom">nom de type chaine</param>
        /// <param name="log">login de type chaine</param>
        /// <param name="pass">mot de passe de type chaine</param>
        public Personel(int id,String nom, String log, String pass)
        {
            this.id = id;
            this.nom = nom;
            this.role = "";
            this.login = log;
            this.pass = pass;
        }
        /// <summary>
        /// constructeur parametre complet
        /// </summary>
        /// <param name="id">identifiant de type entier</param>
        /// <param name="nom">nom de type chaine</param>
        /// <param name="role">role du personel de type chaine</param>
        /// <param name="log">login de type chain</param>
        /// <param name="pass">mot de passe de type chaine</param>
        public Personel(int id, String nom,String role, String log, String pass)
        {
            this.id = id;
            this.nom = nom;
            this.role = role;
            this.login = log;
            this.pass = pass;
        }
        /// <summary>
        /// retourne l'identifiant
        /// </summary>
        /// <returns>entier</returns>
        public int getId()
        {
            return this.id;
        }
        /// <summary>
        /// retourne le nom
        /// </summary>
        /// <returns>chaine</returns>
        public String getNom()
        {
            return this.nom;
        }
        /// <summary>
        /// retourne le role
        /// </summary>
        /// <returns>chaine</returns>
        public String getRole()
        {
            return this.role;
        }
        /// <summary>
        /// retourne le login
        /// </summary>
        /// <returns>chaine</returns>
        public String getLog()
        {
            return this.login;
        }
        /// <summary>
        /// retourne le mot de passe
        /// </summary>
        /// <returns>chaine</returns>
        public String getPass()
        {
            return this.pass;
        }
        /// <summary>
        /// modifier l'identifiant
        /// </summary>
        /// <param name="id">entier</param>
        public void setId(int id)
        {
            this.id = id;
        }
        /// <summary>
        /// modifier le nom
        /// </summary>
        /// <param name="nom">chaine</param>
        public void setNom(String nom)
        {
            this.nom = nom;
        }
        /// <summary>
        /// modifier le role
        /// </summary>
        /// <param name="role">chaine</param>
        public void setRole(String role)
        {
            this.role = role;
        }
        /// <summary>
        /// modifier le login
        /// </summary>
        /// <param name="log">chaine</param>
        public void setLog (String log)
        {
            this.login = log;
        }
        /// <summary>
        /// modifier le mot de passe
        /// </summary>
        /// <param name="pass">chaine</param>
        public void setPass (String pass)
        {
            this.pass = pass;
        }

    }
}
