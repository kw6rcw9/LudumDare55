using System;
using UnityEngine;

namespace Core.RoomSystem
{
    public class TaskScore
    {
        public int NeededAmountOfTasks { get; set; }
        public static Action<int> ApdateScore;

        public void AddCompletedTask()
        {
            NeededAmountOfTasks++;
            ApdateScore?.Invoke(NeededAmountOfTasks);
        }
    }
}