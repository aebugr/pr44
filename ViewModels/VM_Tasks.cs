﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaskManagerBugrina.Classes;
using TaskManagerBugrina.Context;
using TaskManagerBugrina.Models;

namespace TaskManagerBugrina.ViewModels
{
    public class VM_Tasks : Notification
    {
        public TasksContext tasksContext = new TasksContext();
        public ObservableCollection<Tasks> Tasks { get; set; }
        public VM_Tasks() => Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));
        public RealyCommand OnAddTask
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Tasks NewTask = new Tasks()
                    {
                        DateExecute = DateTime.Now
                    };
                    Tasks.Add(NewTask);
                    tasksContext.Tasks.Add(NewTask);
                    tasksContext.SaveChanges();
                });

            }
        }
    }
}
