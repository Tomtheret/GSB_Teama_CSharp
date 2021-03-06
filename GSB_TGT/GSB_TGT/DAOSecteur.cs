﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GSB_TGT
{
    class DAOSecteur
    {
        public static List<Secteur> Secteurs()
        {
            List<Secteur> Localisation = new List<Secteur>();
            try
            {
                String req = "Select * from secteur";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    Localisation.Add(new Secteur(Convert.ToInt32(dr[0].ToString()), dr[1].ToString()));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR : " + e);
            }
            return Localisation;
        }

        public static int getNomSecteurFromIdSecteur(int idSecteur)
        {
            int res = 0;
            try
            {

                String req = "select nomSecteur from secteur where idSecteur =" + idSecteur + ";";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    res = dr.GetInt32(0);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public static int getIdSecteurFromNomSecteur(String nomSecteur)
        {
            int res = 0;
            try
            {

                String req = "select idSecteur from secteur where nomSecteur ='" + nomSecteur + "'";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    res = dr.GetInt32(0);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return res;
        }
    }
}
