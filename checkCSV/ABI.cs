﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace checkCSV
{
    static class ABI
    {
        public static string hasDashAtEnd(string path)
        {
            if (path.EndsWith(@"\"))
            {
                path = path.Remove(path.Length - 1);
            }
            return path;
        }

        public static Color colorOfField(ElementData part)
        {
            if (part.status == 1)
            {
                return Color.LimeGreen;
            }
            else if (part.status == 2)
            {
                return Color.Red;
            }
            else if (part.status == 3)
            {
                return Color.Yellow;
            }
            else
            {
                return Color.Cyan;
            }
        }
    }
}
