using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Microservice
{
    public struct Produkt
    {
        public int ID;
        public string Name;
        public string Beschreibung;
        
        public static bool operator ==(Produkt prod1, Produkt prod2)
        {
            return prod1.ID == prod2.ID;
        }

        public static bool operator !=(Produkt prod1, Produkt prod2)
        {
            return !(prod1 == prod2);
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Produkt p = (Produkt)obj;
                return (ID == p.ID);
            }
        }

        public override int GetHashCode()
        {
            return (ID << 2);
        }
    }
}
