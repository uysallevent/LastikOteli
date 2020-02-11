using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Helper
{
    public static class StringFormatControl
    {
        public static bool IsAllCharNumeric(string text)
        {
            bool sonuc = true;
            if (!string.IsNullOrEmpty(text))
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (!char.IsNumber(text[i]))
                    {
                        sonuc = false;
                        break;
                    }
                }
            }

            return sonuc;
        }

        public static bool IsAllCharLetterOrNumeric(string text)
        {
            bool sonuc = true;
            if (!string.IsNullOrEmpty(text))
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (!char.IsNumber(text[i]) && !char.IsLetter(text[i]))
                    {
                        sonuc = false;
                        break;
                    }
                }
            }

            return sonuc;
        }


    }
}
