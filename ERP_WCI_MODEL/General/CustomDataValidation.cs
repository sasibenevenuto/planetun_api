using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ERP_WCI_Model.General
{
    public static class CustomDataValidation
    {
        public static string EmailValidate(string email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
            Match match = regex.Match(email);
            if (!match.Success)
                throw new Exception("Email inválido");

            return email;
        }
    }
}
