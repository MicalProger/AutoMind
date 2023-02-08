﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMind
{
    public static class Utils
    {
        public static bool IsNumeric(this string str) =>
            double.TryParse(str, CultureInfo.InvariantCulture, out double v);
        public static (string name, string nick) GetDefinition(string defifition)
        {
            var eq = defifition.Substring(7);
            eq = eq.Substring(0, eq.Length - 1);
            var sp = eq.Split("=");
            return (sp[0], sp[1]);
        }
        public static Dictionary<string, string> GetEquality(string obj)
        {
            var ret = new Dictionary<string, string>();
            foreach (var item in obj.Split(" "))
            {
                var sp = item.Split("=");
                ret.Add(sp[0], sp[1]);
            }
            return ret;
        }
        public static string Clear(string a)
        {
            a = a.Replace("\r\n", "");
            a = a.Replace("\t", "");
            return a;
        }
    }
    public class AdvancedString
    {
        public string data;
        public AdvancedString()
        {
            data = String.Empty;
        }
        public AdvancedString(string data) { this.data = data; }
        public string Take(int len)
        {
            var ret = data.Substring(0, len);
            data = data.Substring(len);
            return ret;
        }
        public static implicit operator AdvancedString(string param)
        {
            return new AdvancedString() { data = param };
        }
        public static explicit operator string(AdvancedString param)
        {
            return param.data;
        }
    }

}
