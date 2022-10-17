using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIF35
{
    public class Photographer
    {
        public String Name = "";
        public String Title = "";
        public String Copyright = "";
        public String Address = "";
        public String City = "";
        public String State = "";
        public String PostalCode ="";
        public String Country = "";
        public String Phone = "";
        public String Email = "";
        public String WWW = "";

        public Photographer()
        {

        }
        public Photographer(String N, String T, String CR, String A, String Ci, String St, String PC, String Co, String P, String E, String W)
        {
            this.Name = N;
            this.Title = T;
            this.Copyright = CR;
            this.Address = A;
            this.City = Ci;
            this.State = St;
            this.PostalCode = PC;
            this.Country = Co;
            this.Phone = P;
            this.Email = E;
            this.WWW = W;
        }
    }
}
