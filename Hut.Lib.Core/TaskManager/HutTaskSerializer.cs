using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hut
{
    public class HutTaskSerializer : IDisposable
    {
        private List<IHutTask> tasks;
        private List<IHutTaskAction> actions;

        public HutTaskSerializer()
        {
            tasks = new List<IHutTask>();
            actions = new List<IHutTaskAction>();
        }

        public List<IHutTask> read(string filename)
        {
            if (File.Exists(filename))
            {
                List<IHutTask> schedule = HutJsonFile<List<IHutTask>>.Read(filename, true);

                if (schedule != null)
                    tasks.AddRange(schedule);
            }
            return tasks;
        }

        public void write(string filename, List<IHutTask> tasks)
        {
            List<IHutTask> schedule = tasks.OrderBy(o => o.TaskType).ToList();
            HutJsonFile<List<IHutTask>>.Write(filename, schedule, true);
        }

        public List<IHutTaskAction> readActions(string filename)
        {
            if (File.Exists(filename))
            {
                List<IHutTaskAction> servers = HutJsonFile<List<IHutTaskAction>>.Read(filename, true);

                if (servers != null)
                    actions.AddRange(servers);
            }
            return actions;
        }

        public void writeActions(string filename, List<IHutTaskAction> actions)
        {
            HutJsonFile<List<IHutTaskAction>>.Write(filename, actions, true);
        }

        public void Dispose()
        {
            tasks.Clear();
        }

        public List<IHutTask> Tasks { get { return tasks; } set { tasks = value; } }

        public List<HutFileTask> FileTasks { get { return tasks.Where(w => w.TaskType == HutTaskType.File).OfType<HutFileTask>().ToList(); } }
        public List<HutTimeTask> TimeTasks { get { return tasks.Where(w => w.TaskType == HutTaskType.Time).OfType<HutTimeTask>().ToList(); } }
    }
}