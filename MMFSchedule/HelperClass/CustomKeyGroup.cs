using MMFSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFSchedule.HelperClass
{
    class CustomKeyGroup<T> : List<T>
    {
        public static List<Group<Lesson>> GetLessonsGroups(List<Lesson> lessonsList)
        {
            IEnumerable<Lesson> lessons = lessonsList;
            return GetItemGroups(lessons, l => l.DayId);
        }

        private static List<Group<T>> GetItemGroups<T>(IEnumerable<T> itemList, Func<T, int> getKeyFunc)
        {
            IEnumerable<Group<T>> groupList = from item in itemList
                                              group item by getKeyFunc(item) into g
                                              orderby g.Key
                                              select new Group<T>(g.Key, g);
            return groupList.ToList();
        }
    }

    public class Group<T> : List<T>
    {
        static string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        public Group(int dayId, IEnumerable<T> items)
            : base(items)
        {
            this.Day = days[dayId];
            this.DayId = dayId;
        }

        public string Day
        {
            get;
            set;
        }
        public int DayId
        {
            get;
            set;
        }
    }
}
