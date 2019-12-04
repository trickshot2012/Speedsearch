using System;
using System.Collections.Generic;
using System.IO;

namespace Speedsearch
{
    public class FileSearch
    {
        public string ErrorMessage;
        public bool checkCountOnly;
        public DateTime Startzeit;
        public TimeSpan Zeitdauer;
        public int AnzahlDateien;
        public string Suchbegriff;
        public int AnzahlOrdner;
        private int ii;
        public List<string> lb = new List<string>();

        public void sucheordner(string xordner)
        {
            try
            {
                ii = 0;
                AnzahlDateien = 0;
                AnzahlOrdner = 0;
                lb.Clear();
                Startzeit = DateTime.Now;
                DirectoryInfo di = new DirectoryInfo(xordner);
                CheckDirectory(di);
                Zeitdauer = DateTime.Now - Startzeit;
            }

            catch (Exception eex)
            {
                ErrorMessage = "error " + eex.Message;
                Zeitdauer = DateTime.Now - Startzeit;
            }

        }

        public void CheckDirectory(DirectoryInfo Directory)
        {
            CheckFiles(Directory);
            ii++;
            DirectoryInfo di = Directory;
            DirectoryInfo[] fi = di.GetDirectories();
            foreach (DirectoryInfo diTemp in fi)
            {
                AnzahlOrdner++;
                CheckDirectory(diTemp);
                ii--;
            }

        }

        public void CheckFiles(DirectoryInfo Directory)
        {
            DirectoryInfo di = Directory;
            FileInfo[] fi = di.GetFiles();
            foreach (FileInfo fiTemp in fi)
            {
                if (!checkCountOnly)
                    if (fiTemp.Name.IndexOf(Suchbegriff, 0) >= 0) lb.Add(fiTemp.Name);
                AnzahlDateien++;
            }
        }
    }

}