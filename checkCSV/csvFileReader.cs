﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;

namespace checkCSV
{
    class csvFileReader
    {
        private string _csvPath;
        private string _incastClass;

        public csvFileReader(string csvPath, string incastClass)
        {
            _csvPath = csvPath;

            if (String.IsNullOrEmpty(incastClass))
            {
                _incastClass = "_NONE_";
            }
            else
            {
                _incastClass = incastClass;
            }
        }

        public List<ArrayList> importCSV()
        {
            List<ArrayList> data = new List<ArrayList>();
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(File.OpenRead(_csvPath));
                data = readCSV(reader);
            }
            catch (IOException)
            {
                MessageBox.Show("Viga - 4\n" + "csv peab olema kinni.");
                
            }
            catch
            {
                MessageBox.Show("Viga - 4\n" + "viga csv lugemisel");
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return data;
        }

        private List<ArrayList> readCSV(StreamReader reader)
        {
            List<ArrayList> data = new List<ArrayList>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                ArrayList lineData = getDataFromLine(line);
                if (lineData.Count > 0)
                {
                    data.Add(lineData);
                }
            }

            reader.Close();
            return data;
        }

        private ArrayList getDataFromLine(string line)
        {
            ArrayList lineData = new ArrayList();

            line = line.Replace(" ", "");
            string[] fields = line.Split(';');

           // MessageBox.Show(fields.Count().ToString() + " - " + fields[6] + " - " + fields[66]);

            if (line != String.Empty && fields.Count() >= 21)
            {
                int dummy;

                if (int.TryParse(fields[32], out dummy))
                {
                    lineData.Add(true); //is mainPart
                    lineData.Add(fields[3]); //is name
                    lineData.Add(fields[4]); //is revision
                    lineData.Add(fields[66]); //is hasDrawing
                }
                else if (fields[33] == _incastClass)
                {
                    lineData.Add(false); //is mainPart
                    lineData.Add(fields[34]); //is name
                    lineData.Add(""); //is revision
                    lineData.Add(""); //is hasDrawing
                }


            }

            return lineData;
        }

    }
}
