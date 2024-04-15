using UnityEngine;

namespace Core.RoomSystem
{
    public class TaskScore
    {
        public int NeededAmountOfTasks { get; set; }

        public void AddCompletedTask()
        {
            NeededAmountOfTasks++;
        }
    }
}