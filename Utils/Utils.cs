using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class Utils
    {
        public static byte[] getByteArray(Double[] data)
        {
            object blob = data;
            if (blob == null) return null;
            byte[] arData = (byte[])blob;
            return arData;
        }
    }
}
