using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantMenu.App.Utilities
{
   public static class PersianToEnglish
    {
        public static string ToEnglishNumber(this string persianStr)
        {
            Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
            {
                ['۰'] = '0',
                ['۱'] = '1',
                ['۲'] = '2',
                ['۳'] = '3',
                ['۴'] = '4',
                ['۵'] = '5',
                ['۶'] = '6',
                ['۷'] = '7',
                ['۸'] = '8',
                ['۹'] = '9'
            };
            foreach (var item in persianStr)
            {
                if (LettersDictionary.ContainsKey(item))
                {
                    persianStr = persianStr.Replace(item, LettersDictionary[item]);

                }
            }
            return persianStr;
        }
    }
}
