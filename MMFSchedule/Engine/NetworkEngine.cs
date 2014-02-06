using MMFSchedule.HelperClass;
using MMFSchedule.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MMFSchedule.Engine
{
    public class NetworkEngine
    {
        const string serviceUri = "http://schedule.connect.by";
        public delegate void CallbackEventHandler(List<Group<Lesson>> grLessons);
        public event CallbackEventHandler Callback;

        public void GetSchedule()
        {
            RestClient client = new RestClient(serviceUri);

            RestRequest request = new RestRequest("/universities/1/faculties/1/groups/1/timetable.json", Method.GET);
            request.RequestFormat = DataFormat.Json;
            client.ExecuteAsync(request, (response) =>
            {
                try
                {
                    if (response.ResponseStatus == ResponseStatus.Completed)
                    {
                        string responseContent = response.Content;
                        List<LessonJson> lessonsJson = JsonConvert.DeserializeObject<List<LessonJson>>(responseContent);
                        List<Lesson> lessons = new List<Lesson>();
                        foreach (LessonJson lsj in lessonsJson)
                        {
                            Lesson ls = new Lesson(lsj);
                            lessons.Add(ls);
                        }
                        List<Group<Lesson>> grLessons = CustomKeyGroup<Lesson>.GetLessonsGroups(lessons);
                        if (Callback != null)
                        {
                            Callback(grLessons);
                        }
                        
                    }
                }
                catch (Exception exc)
                {
                    //MessageBox.Show(exc.Message);
                }
            });
        }
    }
}
