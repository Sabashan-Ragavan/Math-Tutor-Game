using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTutorProgram
{
    class PasswordVerifier
    {
        private string password;

        public PasswordVerifier(string password)
        {
            this.password = password;
        }

        public bool IsCharacterLengthCorrect()
        {
            if (this.password.Length >= 6)
                return true;
            return false;
        }

        public bool IsUpperLowerCharacterCaseAmountCorrect()
        {
            bool upperCaseLetter = false;
            bool lowerCaseLetter = false;
            foreach (char c in this.password)
            {
                if (char.IsUpper(c))
                    upperCaseLetter = true;
                if (char.IsLower(c))
                    lowerCaseLetter = true;
            }

            if (upperCaseLetter && lowerCaseLetter)
                return true;
            return false;
        }

        public bool IsDigitAmountCorrect()
        {

            foreach (char c in this.password)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }
    }
}
