using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.CurrentUsename + ";"
                + LoginValidation.CurrentUserRole + ";"
                + activity
                + Environment.NewLine;

            currentSessionActivities.Add(activityLine);

            if (File.Exists("log.txt"))
            {
                File.AppendAllText("log.txt", activityLine);
            }
        }

        public static IEnumerable<string> GetCurrentLogs()
        {
            StreamReader stream = new StreamReader("log.txt");
            string line;
            List<string> lines = new List<string>();

            while ((line = stream.ReadLine()) != null)
            {
                lines.Add(line);
            }
            stream.Close();

            return lines;
        }

        static public IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            return filteredActivities;
        }
 
    }
}
