﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace checkCSV
{
    static class directoryImport
    {
        public static List<string> importCSVdir(string csvPath)
        {
            List<string> files = new List<string>();
            try
            {
                files = importer(csvPath, "*.csv");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("CSV Directory Not Found");
            }
            catch
            {
                MessageBox.Show("Viga - 1");
            }

            return files;
        }

        public static List<string> importPDFdir(string path)
        {
            List<string> files = new List<string>();
            try
            {
                files = importerer(path);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("PDF Directory Not Found");
            }
            catch
            {
                MessageBox.Show("Viga - 2");
            }

            return files;
        }

        private static List<string> importerer(string path)
        {
            List<string> files = new List<string>();

            if (System.IO.Directory.GetDirectories(path).Length > 0)
            {
                string[] subDir = Directory.GetDirectories(path);
                foreach (string newPath in subDir)
                {
                    files.AddRange(directoryImport.importerer(newPath));
                }
            }

            files.AddRange(importer(path, "*.pdf"));

            return files;
        }

        private static List<string> importer(string path, string extention)
        {
            List<string> files = new List<string>();

            string[] importFiles = Directory.GetFiles(path, extention);

            foreach (string file in importFiles)
            {
                string name = Path.GetFileNameWithoutExtension(file);
                files.Add(name);
            }

            return files;
        }
    }
}