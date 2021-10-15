﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Kanban
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationInDays { get; set; }
        public int PointsRequired { get; set; }
        public int PointsDone { get; set; }
        public ICollection<TaskInKanban> Tasks { get; set; }

        private void GetTotalPointsRequired()
        {
            var result = Tasks.Select(t => t.TaskItem)
                .Sum(t => t.Points);
        }
        private void GetTotalPointsInKanbanByLocation()
        {
            var result = Tasks.GroupBy(g => g.LocationInKanban.Description)
                .ToDictionary(g => g.Key, g => g.Sum(p => p.TaskItem.Points));
        }
    }
}
