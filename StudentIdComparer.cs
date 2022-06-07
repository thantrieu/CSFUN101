using System.Collections.Generic;

namespace L101Exercises1
{
    internal class StudentIdComparer : IComparer<Register>
    {
        public int Compare(Register r1, Register r2)
        {
            if (r1 == null && r2 == null)
            {
                return 0;
            }
            else if (r1 == null && r2 != null)
            {
                return 1;
            }
            else if (r1 != null && r2 == null)
            {
                return -1;
            }
            else
            {
                return r1.Student.StudentId.CompareTo(r2.Student.StudentId);
            }           
        }
    }
}
