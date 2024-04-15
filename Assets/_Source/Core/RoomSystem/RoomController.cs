using System;
using UnityEngine;
using Zenject;

namespace Core.RoomSystem
{
    public class RoomController : MonoBehaviour
    {
        [SerializeField] private RoomSettingsHandler roomSettingsHandler;
        private GeneratorController _controller;
        private TaskScore _score; 
        public void Construct(TaskScore score)
        {
            _score = score;
        }
        private void OnEnable()
        {
            _controller = transform.parent.GetComponent<GeneratorController>();
        }

        public void CheckOnCorrectService(Services service)
        {
            if (service != roomSettingsHandler.Services)
                Debug.Log("loh");
            else
            {
                
                _score.AddCompletedTask();
                if(_score.NeededAmountOfTasks == _controller.NeededCorrectTasksNum)
                    NextLevel();
                
            }
            CloseRoom();
        
        


        }

        private void CloseRoom()
        {
            if (RoomsPool.Rooms.Count == 0)
            {
                Game.Lose();
            }
            
            transform.parent.gameObject.SetActive(false);
            _controller.Hall.SetActive(true);
            gameObject.SetActive(false);
        }

        private void NextLevel()
        {
            Debug.Log("Next level");
            Game.NextLevel();
        }
    }
}
