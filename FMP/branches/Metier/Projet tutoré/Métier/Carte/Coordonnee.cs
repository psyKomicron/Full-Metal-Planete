using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Carte
{
    
    public class Coordonnee
    {
        
        private int x;
       
        private int y;

        public int X
        {
            get => x;
        }

        public int Y
        {
            get => y;
        }

        public Coordonnee(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        /*
         * Renvoie une carte voisin en fontion de la direction
         * Elle change si X est pair ou non
         */
        public Coordonnee Voisin(TypeDirection mouvement)
        {
            Coordonnee coo;
            if (this.x % 2 == 0)
            {
                switch (mouvement)
                {

                    case TypeDirection.Bas:
                        coo = new Coordonnee(this.x + 2 , this.y);
                        break;
                    case TypeDirection.BasDroite:
                        coo = new Coordonnee(this.x+1, this.y);
                        break;
                    case TypeDirection.BasGauche:
                        coo = new Coordonnee(this.x+1, this.y-1);
                        break;
                    case TypeDirection.Haut:
                        coo = new Coordonnee(this.x -2 , this.y);
                        break;
                    case TypeDirection.HautDroite:
                        coo = new Coordonnee(this.x -1, this.y);
                        break;
                    case TypeDirection.HautGauche:
                        coo = new Coordonnee(this.x-1, this.y-1);
                        break;
                    default:
                        throw new Exception("Le type de mouvement est inconu");

                }
            }
            else
            {
                switch (mouvement)
                {

                    case TypeDirection.Bas:
                        coo = new Coordonnee(this.x + 2, this.y);
                        break;
                    case TypeDirection.BasDroite:
                        coo = new Coordonnee(this.x + 1, this.y+1);
                        break;
                    case TypeDirection.BasGauche:
                        coo = new Coordonnee(this.x + 1, this.y);
                        break;
                    case TypeDirection.Haut:
                        coo = new Coordonnee(this.x - 2, this.y);
                        break;
                    case TypeDirection.HautDroite:
                        coo = new Coordonnee(this.x - 1, this.y+1);
                        break;
                    case TypeDirection.HautGauche:
                        coo = new Coordonnee(this.x -1, this.y);
                        break;
                    default:
                        throw new Exception("Le type de mouvement est inconu");


                }
            }
            return coo;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordonnee coordonnee &&
                   x == coordonnee.x &&
                   y == coordonnee.y &&
                   X == coordonnee.X &&
                   Y == coordonnee.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = -624234986;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
