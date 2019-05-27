using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBTest
{
    public static class Validation
    {
        //חייבת להכיל לפחות 8 תווים, לא יותר יותר מ15 תווים, לפחות אות קטנה אחת, לפחות ספרה אחת, לפחות גדולה אחת
        public static bool IsPasswordValid(string password)
        {
            string passwordStr = new System.Net.NetworkCredential(string.Empty, password).Password;
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(passwordStr);
        }


    }
}
