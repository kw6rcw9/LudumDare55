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
        private AgressBar _bar;
        public void Construct(TaskScore score, AgressBar bar)
        {
            _score = score;
            _bar = bar;
        }
        private void OnEnable()
        {
            _controller = transform.parent.GetComponent<GeneratorController>();
        }

        public void CheckOnCorrectService(Services service)
        {
            if (service != roomSettingsHandler.Services)
            {
                Debug.Log("loh");
                _bar.TakeDamage();
            }
            else
            {
                
                _score.AddCompletedTask();
                _bar.Heal();
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
