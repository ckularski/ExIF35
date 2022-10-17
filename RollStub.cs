using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExIF35 
{
    public class RollStub : IComparable<RollStub>, IEquatable<RollStub>
    {
        public String RollNumber;
        public int iRollNumber;
        public String RollID;
        public String Filename;
        public String FilmType;
        public String description; 
        public int count = 0;
        
        public RollStub()
        {

        }
        public RollStub(String RN, String RID, String FN, String FT, int C, String D)
        {
            RollNumber = RN;
            iRollNumber = Convert.ToInt32(GetNumbers(RN));
            RollID = RID;
            Filename = FN;
            FilmType = FT;
            count = C;
            description = D;
        }
        public ListViewItem getListView()
        {
            ListViewItem tmp = new ListViewItem(new String[] { RollNumber, RollID, FilmType, Filename, count.ToString() });
            return tmp;
        }
        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
        #region IComparable<RollStub> Members

        public int CompareTo(RollStub other)
        {
            return other.iRollNumber.CompareTo(this.iRollNumber);
        }

        #endregion

        #region IEquatable<RollStub> Members

        public bool Equals(RollStub other)
        {
            //return other.iRollNumber.Equals(this.iRollNumber);
            return other.RollID.Equals(this.RollID);
        }

        #endregion

    }
}
