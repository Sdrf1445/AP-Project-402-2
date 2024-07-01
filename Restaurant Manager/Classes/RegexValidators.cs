using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO.Packaging;

namespace Restaurant_Manager.Classes
{
    public static class RegexValidators
    {
        static string EmailRegexPattern = @"^.{3,32}@[A-Za-z]{3,32}\.[A-Za-z]{2,3}$";
        static string NameRegexPattern = @"([A-Za-z]){3,32}";
        static string MobileRegexPattern = @"^09\d{9}$";
        static string PasswordRegexPattern = "^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,32}$";
        static string VerificationCodeRegexPattern = @"^\d{4}$";
        public static bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, EmailRegexPattern,RegexOptions.IgnoreCase);
        }
        public static bool IsNameValid(string name)
        {
            return Regex.IsMatch(name, EmailRegexPattern,RegexOptions.IgnoreCase);
        }
        public static bool IsMobileValid(string mobile)
        {
            return Regex.IsMatch(mobile, MobileRegexPattern);
        }
        public static bool IsPasswordValid(string password)
        {
            return Regex.IsMatch(password, PasswordRegexPattern);
        }
        public static bool IsVerificationCodeValid(string verificationCode)
        {
            return Regex.IsMatch(verificationCode, VerificationCodeRegexPattern);
        }
    }
}
