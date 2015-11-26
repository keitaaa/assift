using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Shiftwork.Payload
{
    public static class ConvertPrivate
    {
        public static string[,] ConvertP(string[,] jobs, string[] name)
        {
            string[,] pris = new string[name.Length, jobs.GetLength(1)-1];
            Hashtable ht = new Hashtable();
            for(int i=0; i < name.Length; i++)
            {
                ht.Add(name[i], i.ToString());
            }
            for(int i=1; i<jobs.GetLength(1); i++)
            {
                for(int j=0; j<jobs.GetLength(0); j++)
                {
                    if (jobs[j, i] == null || jobs[j, i] == "") continue;
                    int k = int.Parse((string)ht[jobs[j, i]]);
                    pris[k, i-1] = jobs[j, 0];
                }
            }
            return pris;

        }
    }
}
