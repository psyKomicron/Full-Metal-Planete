﻿using Metier.Carte;
using Metier.Carte.Cases;
using System.Collections.Generic;

namespace Metier.Unites
{
    public class Astronef : Unite
    {
        private List<Tourelle> tour;
        private ReserveAstronef depart = new ReserveAstronef();

        public Astronef(Case position, Joueur joueur) : base(position, joueur)
        {
            tour = new List<Tourelle>();
        }

        public ReserveAstronef Reserve => depart;

        /// <summary>
        /// Permet de sortir l'unité de l'astronef
        /// </summary>
        /// <param name="c">Unité sur la quelle se trouvera l'unité</param>
        /// <param name="t">Type de l'unité a sortir</param>
        public void SortirUnité(Case c,TypeEntite t)
        {
            if (PeutSortir(c,t))
            {
                Unite u = FabriqueUnite.CreeUnite(t,c, this.Joueur) as Unite;
                this.Joueur.Carte.AjouterUnite(u,c);
            }
        }

        /// <summary>
        /// Permet de vérifier si l'unité est encore disponible
        /// Permet de vérifier si l'unité est sortable de l'astronef (si elle est déplacable sur la case)
        /// </summary>
        /// <param name="c">Case sur laquelle le joueur essaye de sortir l'unité</param>
        /// <param name="t">Type de l'unité</param>
        /// <returns>True si l'unité est sortable faux sinon</returns>
        public bool PeutSortir(Case c, TypeEntite t)
        {
            bool res = false;
            if (depart.EstCreable(t))
            {
               Unite e = FabriqueUnite.CreeUnite(t, this.Position, this.Joueur) as Unite;
                if (e.SeDeplacer(c,this.Position))
                {
                    res = true;
                }
            }
            return res;
        }
        public override TypeEntite Type
        {
            get => TypeEntite.ASTRONEF;
        }

        /*
         * Cette fonction met dans la case en haut, bas gauche, et bas droite de l'astronef ses tourelles
         */
        public void Tourelle()
        {
            Tourelle t1 = new Tourelle(Position.Voisin(TypeDirection.Haut), Joueur);
            Tourelle t2 = new Tourelle(Position.Voisin(TypeDirection.BasDroite), Joueur);
            Tourelle t3 = new Tourelle(Position.Voisin(TypeDirection.BasGauche), Joueur);

            tour.Add(t1);
            tour.Add(t2);
            tour.Add(t3);

            Joueur.Carte.AjouterUnite(t1, Position.Voisin(TypeDirection.Haut));
            Joueur.Carte.AjouterUnite(t2, Position.Voisin(TypeDirection.BasDroite));
            Joueur.Carte.AjouterUnite(t3, Position.Voisin(TypeDirection.BasGauche));
        }

        /*
         * Retourne si l'astronef est posable sur la case demander ou non
         */
        public static bool EstPosable(Case Posi)
        {
            Case caseClique = Posi;

            bool res = false;
            if (!caseClique.EstBord())
            {
                Case haut = Posi.Voisin(TypeDirection.Haut);
                Case basGauche = Posi.Voisin(TypeDirection.BasGauche);
                Case basDroite = Posi.Voisin(TypeDirection.BasDroite);
                if (!haut.EstBord() && !basGauche.EstBord() && !basDroite.EstBord())
                {
                    if (caseClique.Type() ==TypeCases.MONTAGNE || caseClique.Type() == TypeCases.PLAINE)
                    {
                        
                        if ((haut.Type() == TypeCases.MONTAGNE || haut.Type() == TypeCases.PLAINE) && (basGauche.Type().Equals(TypeCases.MONTAGNE) || basGauche.Type().Equals(TypeCases.PLAINE)) && (basDroite.Type().Equals(TypeCases.MONTAGNE) || basDroite.Type().Equals(TypeCases.PLAINE)))
                        {
                            if (haut.Entity != null && basGauche.Entity != null && basDroite.Entity != null && caseClique != null)
                            {
                                res = false;
                            }
                            else
                            {
                                if(haut.Minerai == false && basDroite.Minerai == false && caseClique.Minerai == false & basGauche.Minerai == false)
                                    res = true;
                            }

                        }
                    }
                }
            }
            return res;
        }

        public void SupprMinerai()
        {
            Case haut = Position.Voisin(TypeDirection.Haut);
            Case basGauche = Position.Voisin(TypeDirection.BasGauche);
            Case basDroite = Position.Voisin(TypeDirection.BasDroite);

            foreach(Case c in haut.Voisins)
            {
                c.Minerai = false;
            }
            foreach (Case c in basDroite.Voisins)
            {
                c.Minerai = false;
            }
            foreach (Case c in basGauche.Voisins)
            {
                c.Minerai = false;
            }
        }

        public override bool SeDeplacer(Case arrivee, Case Depart)
        {
            return false;
        }
    }
}
