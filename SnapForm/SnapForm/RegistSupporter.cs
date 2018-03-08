using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapForm
{
    class RegistSupporter
    {
        public List<string> RecommendedPrograms(string ext)
        {

            List<string> progs = new List<string>();

            string baseKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\." + ext;

            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(baseKey + @"\OpenWithList"))
            {
                if (rk != null)
                {
                    string mruList = (string)rk.GetValue("MRUList");
                    if (mruList != null)
                    {
                        foreach (char c in mruList.ToString())
                        {
                            string str = rk.GetValue(c.ToString()).ToString();
                            if (!progs.Contains(str))
                            {
                                progs.Add(str);
                            }
                        }
                    }
                }
            }

            //using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(baseKey + @"\OpenWithProgids"))
            //{
            //    if (rk != null)
            //    {
            //        foreach (string item in rk.GetValueNames())
            //            progs.Add(item);
            //    }
            //}

            //using (RegistryKey rk = Registry.ClassesRoot.OpenSubKey("." + ext + @"\OpenWithList"))
            //{
            //    if (rk != null)
            //    {
            //        foreach (var item in rk.GetSubKeyNames())
            //        {
            //            if (!progs.Contains(item))
            //            {
            //                progs.Add(item.ToString());
            //            }
            //        }
            //    }
            //}

            //using (RegistryKey rk = Registry.ClassesRoot.OpenSubKey("." + ext + @"\OpenWithProgids"))
            //{
            //    if (rk != null)
            //    {
            //        foreach (string item in rk.GetValueNames())
            //        {
            //            if (!progs.Contains(item))
            //            {
            //                progs.Add(item);
            //            }
            //        }
            //    }
            //}

            return progs;
        }
    }
}
