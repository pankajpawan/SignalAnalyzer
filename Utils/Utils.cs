using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utils
{
    public class Utils
    {
        public static byte[] getByteArray(double[] data)
        {
            object blob = data;
            if (blob == null) return null;
            byte[] arData = (byte[])blob;
            return arData;
        }

        public static void readCsvFile(string fileName, ref List<double> time, ref List<double> signal)
        {
            var reader = new StreamReader(File.OpenRead(fileName));
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                try
                {
                    double x = Convert.ToDouble(values[0]);
                    double y = Convert.ToDouble(values[1]);
                    time.Add(x);
                    signal.Add(y);
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
    }
}
