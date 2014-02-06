using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace MMFSchedule.Models
{
    [DataContract]
    public class LessonJson
    {
        [DataMember(Name = "auditory")]
        public string Auditory { get; set; }

        [DataMember(Name = "bell_id")]
        public int BellId { get; set; }

        [DataMember(Name = "date_end")]
        public DateTime DateEnd { get; set; }

        [DataMember(Name = "date_start")]
        public DateTime DateStart { get; set; }

        [DataMember(Name = "day_id")]
        public int DayId { get; set; }

        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "subject_type_id")]
        public int SubjectTypeId { get; set; }

        [DataMember(Name = "teacher")]
        public string Teacher { get; set; }

        [DataMember(Name = "week_id")]
        public int WeekId { get; set; }
    }

    public class Lesson
    {
        private readonly string[] bellRing = { "8:15 - 9:35", "9:45 - 11:05", "11:15 - 12:35", "13:00 - 14:20", "14:30 - 15:50", "16:00 - 17:20", "17:30 - 18:50", "19:00 - 20:20", "20:30 - 21:50" }; 
        public string Auditory { get; set; }
        public string LessonTime { get; set; }
        public int DayId { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public int SubjectTypeId { get; set; }

        public Lesson(LessonJson lessonJson)
        {
            this.Auditory = lessonJson.Auditory;
            this.LessonTime = bellRing[lessonJson.BellId - 1];
            this.DayId = lessonJson.DayId;
            this.Subject = lessonJson.Subject;
            this.Teacher = lessonJson.Teacher;
            this.SubjectTypeId = lessonJson.SubjectTypeId;
        }
    }
}
