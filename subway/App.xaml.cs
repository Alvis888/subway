using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace subway
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private static Dictionary<string, object> _values =
               new Dictionary<string, object>();

        public static void SetValue(string key, object value)
        {
            _values.Add(key, value);
        }

        public static T GetValue<T>(string key)
        {
            return (T)_values[key];
        }
    }

   
}
