﻿using Metier.Carte.Cases;
using Metier.Unites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Metier.Carte
{
    
    public class Map : ICarte

    {
        
        private static Dictionary<Coordonnee,Case> cases;
        private static int[] nbTide = new int[3] { 5, 5, 5 };
        private static Maree tide = Maree.MOYENNE;
        private static Maree nextTide;
        
        public Maree NextTide
        {
            get => nextTide;
            set => nextTide = value;
        }

        public Maree Tide
        {
            get => tide;
            set => tide = value;
        }

        public Map()
        {
            cases = new Dictionary<Coordonnee, Case>();
            if (cases.Count==0)
            {
                GenerationCarte();
                GenerationMinerai();
                GenerationVoisins();
            }
        }

        private void GenerationMinerai()
        {
            for (int x = 0; x < 46; x+=3)
                for (int y = 0; y < 19; y+=3)
                {
                    if (y <= 18)
                    {
                        if (y < 18 || x % 2 == 0)
                        {
                            Case c = GetCase(new Coordonnee(x, y));
                            if (c.Type() != TypeCases.MER)
                            {
                                c.Minerai = true;
                            }
                        }
                    }
                }
        }

        /*
         * Cette fonction génère les cases présentes 
         */
        private void GenerationCarte()
        {
            #region Carte
            string str = "PPMPPPPEMEPPPPSPPPPPPPPPSSMMEPPSPPPPPXPPPPPPSSMPPPPSSSPPPPPPPPSSSPSPPPSSPPPXPPPSPPPPSSSPPPSSPPPPPSSPEPPSMPPPSPSPPXPPMMSEEPPMSPSESPEPPPPMMEPPPPMPPEEPPMMXMPMSPEEPPEEEEEPMEMMPMPEEEEPEEEEEEEEMPXPPPEEEEEREEEEEMEEPPPPPEREEPEEEEEEREPPXPPPEEPPRREEEEERESPPPPPERPRREEEEEERMPPXPPPSPRPREEEEEEEMSPPPPPPRPSERRREEEPMPPXPSPSERSMERPREEEPSPPPPPPEPMEPPREEEPPSPXPPPSEESPPPMEEEEPPPPPPPEEESEPMPEREEPSPXPPPEEEPEPPPSPEREPSPPPSEEEEEPMPPEREPPSXSPPPEEPEEPPSPEREPMSSPEEEPEEEMSPMEEPPSXSMEPEEPEEMSSMEEEPSSSMEREEPEEPPSPEEPEPXMSEPRREEEPSPMREPEPPMSPPREEMSPPERPEEPPXMPPPRPEERPSERREPPPPPSPPPMEMSPPESEEEPPXPPPPPEEEREEERMSMPPPPSPEREMEEEEESEREPPXPPEEREMREEEEEEPEPPPPMMEPEPREEEEEEPMPPXPPRMRESEPPEEEEPRMPPPMMEEESEPEEEEEEPMPXPMEERESEPPPPEPEPPMPPMERPSSPPPPEEPSPPPXPMSEPPSSPPPPEPPSPPPPSSPPSSPPPPPSPMPPPXPMSSPPSPPPPPPSMSPPPPSSPPPPPPPPPPSEPPPXPPPPPPSPPMPPPPEPPPPPPPPPSEPMMPPPSPPPPXPPPPPPPEMMPPPSSPPPPPPPPPSPMMMMPSPPPPPX";
            #endregion

            #region creationCases
            for (int i = 0; i < 46; i++)
            {
                for(int j = 0; j < 19; j++)
                {
                    int nb = i * 19 + j;
                    char c = str[nb];
                    switch (c)
                    {
                        case 'P':
                            AjouterCase(FabriqueCases.CreeCase(TypeCases.PLAINE, new Coordonnee(i, j)));
                            break;
                        case 'R':
                            AjouterCase(FabriqueCases.CreeCase(TypeCases.RECIF, new Coordonnee(i, j)));
                            break;
                        case 'M':
                            AjouterCase(FabriqueCases.CreeCase(TypeCases.MONTAGNE, new Coordonnee(i, j)));
                            break;
                        case 'S':
                            AjouterCase(FabriqueCases.CreeCase(TypeCases.MARECAGE, new Coordonnee(i, j)));
                            break;
                        case 'E':
                            AjouterCase(FabriqueCases.CreeCase(TypeCases.MER, new Coordonnee(i, j)));
                            break;
                        case 'X':
                            break;
                        default:
                            throw new Exception("Type de case inconu lors de la génération");
                    }
                }
            }
            #endregion // et des générationd des minerais

        }



        /*
         * Génère les tous les voisins de toutes les cases (comme on les connais déjà toutes)
         */
        private void GenerationVoisins() //a vérifié que les cases au bord n'est pas de voisins "vide"
        {
            foreach (Case c in cases.Values)
            {
                foreach (TypeDirection type in Enum.GetValues(typeof(TypeDirection)))
                {
                    if(cases.TryGetValue(c.Coordonnee.Voisin(type), out Case ca))
                        c.AjouterVoisin(ca,type);
                }
            }
        }

        /*
         * Donne la case de la carte correspondante a la coordonnée donné en paramètre
         */
        public Case GetCase(Coordonnee coordonnee)
        {
            
            Case c = cases[coordonnee];
            return c;
        }

        /*
         * Donne toutes les cases présentes dans la carte
         */
        public ICollection<Case> GetCases()
        {
            return cases.Values;
        }

        /*
         * Ajoute une case a la carte
         */
        public void AjouterCase(Case c)
        {
            cases.Add(c.Coordonnee,c);
        }

        /*
         * Ajoute une unité sur la carte
         */
        public void AjouterUnite(Unite u, Case c)
        {
            this.GetCase(c.Coordonnee).Entity = u;
            
        }

        /*
         * Cette méthode permet de tirer la marée de la future méteo
         * Elle vérifie si il reste des carte de la marée sinon elle se relance pour obtenir une autre marée
         */
        public void KnowTide()
        {
            Random rnd = new Random();
            int ch = rnd.Next(1,4);
            switch (ch)
            {
                case 1:
                    if (nbTide[0] != 0)
                    {
                        NextTide = Maree.BASSE;
                        nbTide[0]--;
                    }
                    else
                    {
                        KnowTide();
                    }
                    break;
                case 2: 
                    if (nbTide[1] != 0)
                    {
                        NextTide = Maree.MOYENNE;
                        nbTide[1]--;
                    }
                    else
                    {
                        KnowTide();
                    }
                    break;
                case 3: 
                    if (nbTide[2] != 0)
                    {
                        NextTide = Maree.HAUTE;
                        nbTide[2]--;
                    }
                    else
                    {
                        KnowTide();
                    }
                    break;
            }
        }

        /*
         * Cette méthode permet de changer la marée actuelle avec celle annoncé 
         * Elle permet ensuite de générer la marée suivante
         */
        public void ChangeTide()
        {
            Tide = NextTide;
            KnowTide();
        }

      

    }
}
