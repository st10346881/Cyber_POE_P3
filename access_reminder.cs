using System.Text.RegularExpressions;

namespace sihlali_poe_part_3
{
   public class access_reminder
    {
        //global arrays or generics
        private List<string> descriptions = new List<string>();
        private List<string> dates = new List<string>();

        //validate the user input
        public string validate_input(string user_input)
        {
            //check if empty or not
            if (user_input != "")
            {
                //return found
                return "found";

            }
            else
            {
                //then return error message
                return "Please add a task";
            }


        }//end of validate_input method

        //method to get number
        public string get_days(string day)
        {
            //get the number from the users input
            string get_day_in = Regex.Replace(day, @"[^\d]", "");

            //check if day is 0
            if (get_day_in != "0")
            {
                return get_day_in;

            }
            else
            {
                return "today";
            }

        }//end of get_days method

        //method to store today's date
        public string today_date(string description, string date)
        {
            //validate
            if (date == "today")
            {
                //get the date 
                DateTime today_date = DateTime.Now.Date;
                string format_date = today_date.ToString("yyyy-MM-dd");

                //add all
                descriptions.Add(description);
                dates.Add(format_date);

                return "Nice, will remind you " + date;
            }
            else
            {
                return "error";
            }


        }//end of today_date method

        //get the reminder date correct
        public string get_remindDate(string description, string date)
        {
            //get the current date
            DateTime currentDate = DateTime.Now.Date;

            //then format date
            string format_date = currentDate.ToString("yyyy-MM-dd");

            //get the day in the format
            string find_day = format_date.Substring(8, 2);

            //get date from 2 to 8
            string final_date = format_date.Substring(0, 8);

            int total_days = int.Parse(find_day) + int.Parse(date);
            string store_date = final_date + total_days;

            descriptions.Add(description);
            dates.Add(store_date);

            return "done";

        }//end of remind date

        //method to check reminder
        public string get_remind()
        {
            //then search for today
            DateTime today = DateTime.Now.Date;
            string now_date = today.ToString("yyyy-MM-dd");

            string found_remind = "";

            for (int count = 0; count < dates.Count; count++)
            {
                //check for the date 
                if (dates[count] == now_date)
                {
                    //then append message
                    found_remind += "\nDue Today: " + descriptions[count] + "\n" + dates[count];

                }//end of if
                else
                {
                    found_remind += "\n" + descriptions[count] + "\n" + dates[count];

                }

            }
            return found_remind;
        }
    }
}