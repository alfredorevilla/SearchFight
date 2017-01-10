using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Data
{
    public static class Extensions
    {
        public static object[] GetHorizontalHeaders(this object[,] matrix)
        {
            var l = matrix.GetUpperBound(1);
            var headers = new object[l];
            for (int i = 0; i < l;)
            {
                headers[i] = matrix[0, i++];
            }
            return headers;
        }

        public static object[] GetVerticalHeaders(this object[,] matrix)
        {
            var l = matrix.GetUpperBound(1);
            var headers = new object[l];
            for (int i = 1; i < l;)
            {
                headers[i] = matrix[0, i++];
            }
            return headers;
        }

        public static object[] GetDataRow(this object[,] matrix, int index)
        {
            throw new NotImplementedException();
        }

        public static object GetDataCell(this object[,] matrix, int index)
        {
            throw new NotImplementedException();
        }
    }
}
