using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.Helper
{
    public class ConvertNumbersToArabicAlphabet
    {

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " مليون ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " الف ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " مائه ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "و";

                //var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                //var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                var unitsMap = new[] { "صفر", "واحد", "اتنان", "ثلاثه", "أربعه", "خمسه", "سته", "سبعه", "ثمانيه", "تسعه", "عشرة", "احد عشر", "أثنا عشر", "ثلاثه عشر", "أربعه عشر", "خمسه عشر", "سته عشر", "سبعه عشر", "ثمانيه عشر", "تسعه عشر" };
                var tensMap = new[] { "صفر", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "نسعون" };
                //var hunderMap = new[] { "صفر", " مائه", "مئتان", "ثلاثه مائه", "أربعمائه", "خمسمائة", " ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };
                //var thousandMap = new[] { "صفر", " الف", "الفان", "ثلاثه الف", "أربعه الف", "   خمسه الف ", " سته الف", "سبعه الف", "ثمانيه الف ", "تسعة الف" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words = unitsMap[number % 10] + " و  " + words;
                }
                //if (number < 100 && number > 20)
                //{
                //    words += tensMap[number / 10];
                //    if ((number % 10) > 0)
                //        words = unitsMap[number % 10] + " و  " + words;
                //}
                //if (number >= 100 && number < 1000)
                //{
                //    var test = number % 100;
                //    words += hunderMap[number / 100];
                //    int number1, number2 = 0;
                //    number1 = test;
                //    number2 = number1 % 10;
                //    if ((number % 100) > 0)
                //        words = words + " و  " + unitsMap[number2] + " و  " + tensMap[number1 / 10];
                //}
                //if (number >= 1000 && number < 100000)
                //{
                //    var test = number % 100;
                //    words += thousandMap[number / 1000];
                //    int number1, number2 = 0;
                //    number1 = test;
                //    number2 = number1 % 100;
                //    if ((number % 1000) > 0)
                //        words = words + " و  " + unitsMap[number2] + " و  " + tensMap[number1 / 10] + " و  " + hunderMap[number1 / 100];
                //}

            }

            return words;
        }

    }
}
