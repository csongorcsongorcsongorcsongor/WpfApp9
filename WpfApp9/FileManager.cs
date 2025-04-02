using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace WpfApp9
{
    public class FileManager
    {
        private string filename;
        List<Cars> asd = new List<Cars>();

        public FileManager(string filename)
        {
            this.filename = filename;
        }

        public List<Cars> ReadFile()
        {
            List<Cars> all = new List<Cars>();

            try
            {
                foreach (string line in File.ReadAllLines(filename, Encoding.UTF8).Skip(1))
                {
                    all.Add(new Cars(line));
                    asd.Add(new Cars(line));
                }
                File.ReadAllLines(filename, Encoding.UTF8).ToList().ForEach(line=> all.Add(new Cars(line)));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return all;
        }
        public void WriteOneLine(Cars onecar)
        {
            using(StreamWriter write = new StreamWriter(filename, true, Encoding.UTF8))
            {
                write.Write($"\n{onecar.Manufacturer};{onecar.Model};{onecar.Power};{onecar.Weight}");
            }
        }
        public void eol(int d, Cars oc) 
        {
            foreach (Cars i in asd)
            {
                if(asd.IndexOf(i)== d)
                {
                    i.Manufacturer = oc.Manufacturer;
                    i.Model = oc.Model;
                    i.Power = oc.Power;
                    i.Weight = oc.Weight;

                    using(StreamWriter w = new StreamWriter( filename, false, Encoding.UTF8))
                    {
                        w.Write("Elso sor");
                        foreach (Cars ii in asd)
                        {
                            
                            w.Write($"\n{ii.Manufacturer};{ii.Model};{ii.Power};{ii.Weight}");
                        }
                    }
                }
            }

            
        }
        public void we(List<Cars> all)
        {
            using (StreamWriter w = new StreamWriter(filename, false, Encoding.UTF8))
            {
                w.WriteLine("Random első sor");
                for (int i = 0; i < all.Count-1; i++)
                {
                    w.WriteLine($"{all[i].Manufacturer};{all[i].Model};{all[i].Power};{all[i].Weight}");
                }
                w.WriteLine($"{all.Last().Manufacturer};{all.Last().Model};{all.Last().Power};{all.Last().Weight}");
            }
        }
    }
}
