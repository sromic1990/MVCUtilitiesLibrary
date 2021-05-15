using UtilitiesLibrary.Debug;

namespace UtilitiesLibrary.DateTimeUtils
{
    public static class PrettyPrintFromSeconds
    {
        private const int SECONDS_IN_MINUTES = 60;
        private const int SECONDS_IN_HOURS = 3600;
        private const int SECONDS_IN_A_DAY = 86400;
        private const int SECONDS_IN_A_MONTH = 2592000;
        private const int SECONDS_IN_A_YEAR = 31104000;

        private const int HOURS_THRESHOLD = 12;
        private const int MINS_THRESHOLD = 15;
        private const int DAYS_THRESHOLD = 2;
        private const int MONTHS_THRESHOLD = 1;

        public static string GetPrettyString(int seconds, TypeOfPrint type)
        {
            string print = "";

            switch (type)
            {
                case TypeOfPrint.LongHand:
                    print = GetLongHandString(seconds);
                    break;
                
                case TypeOfPrint.ShortHand:
                    print = GetShortHandPrint(seconds);
                    break;
            }
            
            return print;
        }

        private static string GetLongHandString(int totalSeconds)
        {
            string longHand = "";

            int years = totalSeconds / SECONDS_IN_A_YEAR;
            int rem = totalSeconds % SECONDS_IN_A_YEAR;
            int months = rem / SECONDS_IN_A_MONTH;
            rem = rem % SECONDS_IN_A_MONTH;
            int days = rem / SECONDS_IN_A_DAY;
            rem = rem % SECONDS_IN_A_DAY;
            int hours = rem / SECONDS_IN_HOURS;
            rem = rem % SECONDS_IN_HOURS;
            int minutes = rem / SECONDS_IN_MINUTES;
            int seconds = rem % SECONDS_IN_MINUTES;

            longHand = "";
            if (years > 0)
            {
                longHand += years;
                if (years > 1)
                {
                    longHand += " yrs ";
                }
                else
                {
                    longHand += " yr ";
                }

                if (months > MONTHS_THRESHOLD)
                {
                    if (months > 0)
                    {
                        longHand += months;
                        if (months > 1)
                        {
                            longHand += " months ";
                        }
                        else
                        {
                            longHand += " month ";
                        }
                    }
                }
            }
            else
            {
                if (months > 0)
                {
                    longHand += months;
                    if (months > 1)
                    {
                        longHand += " months ";
                    }
                    else
                    {
                        longHand += " month ";
                    }

                    if (days > DAYS_THRESHOLD)
                    {
                        if (days > 0)
                        {
                            longHand += days;
                            if (days > 1)
                            {
                                longHand += " days ";
                            }
                            else
                            {
                                longHand += " day ";
                            }
                        }
                    }
                }
                else
                {
                    if (days > 0)
                    {
                        longHand += days;
                        if (days > 1)
                        {
                            longHand += " days ";
                        }
                        else
                        {
                            longHand += " day ";
                        }
                        
                        if (hours > HOURS_THRESHOLD)
                        {
                            longHand += hours;
                            if (hours > 1)
                            {
                                longHand += " hrs ";
                            }
                            else
                            {
                                longHand += " hr ";
                            }
                        }
                    }
                    else
                    {
                        if (hours > 0)
                        {
                            longHand += hours;
                            if (hours > 1)
                            {
                                longHand += " hrs ";
                            }
                            else
                            {
                                longHand += " hr ";
                            }
                            
                            if (minutes > MINS_THRESHOLD)
                            {
                                longHand += minutes + " min ";
                            }
                        }
                        else
                        {
                            if (minutes > 0)
                            {
                                longHand += minutes + " min ";
                            }
                            else
                            {
                                longHand += seconds + " sec. ";
                            }
                        }
                    }
                }
            }
            
            // D.Log($"longHand = {longHand}");
            return longHand;
        }
        
        private static string GetShortHandPrint(int secondsTotal)
        {
            string shortHand = "";

            int hours = secondsTotal / SECONDS_IN_HOURS;
            int rem = secondsTotal % SECONDS_IN_HOURS;
            int mins = rem / SECONDS_IN_MINUTES;
            rem = rem % SECONDS_IN_MINUTES;
            int seconds = rem;

            if (hours < 10)
            {
                shortHand += "0" + hours + ":";
            }
            else
            {
                shortHand += hours + ":";
            }

            if (mins < 10)
            {
                shortHand += "0" + mins + ":";
            }
            else
            {
                shortHand += mins + ":";
            }

            if (seconds < 10)
            {
                shortHand += "0" + seconds;
            }
            else
            {
                shortHand += seconds;
            }
            
            // shortHand = hours + ":" + mins + ":" + rem;
            D.Log($"shortHand = {shortHand}");
            return shortHand;
        }
    }

    public enum TypeOfPrint
    {
        ShortHand,
        LongHand,
    }
}
