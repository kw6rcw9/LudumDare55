using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Core.RoomSystem
{
    public class RoomController : MonoBehaviour
    {
        [field: SerializeField] public RoomSettingsHandler SettingsHandler { get; private set; }
        private GeneratorController _controller;
        private TaskScore _score;
        private AgressBar _bar;
        public static Action<Services> ChangeSprite;
        public static Action LoseAction;
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
            if(service != Services.CorrectCitizens)
                ChangeSprite?.Invoke(service);
            if (service != SettingsHandler.Services)
            {
                Debug.Log("loh");
                _bar.TakeDamage();
            }
            else
            {
                
                if(SettingsHandler.IsNeeded)
                    _score.AddCompletedTask();
                _bar.Heal();
                if(_score.NeededAmountOfTasks == _controller.NeededCorrectTasksNum) {
                    
                    StartCoroutine(NextLevel());
                    return;
                }
                
            }
            StartCoroutine(CloseRoom());



        }

        private IEnumerator CloseRoom()
        {
            yield return new WaitForSeconds(2f);
            if (RoomsPool.Rooms.Count == 0)
            {
                Game.Lose();
            }
            
            transform.parent.gameObject.SetActive(false);
            _controller.Hall.SetActive(true);
            gameObject.SetActive(false);
        }

        private IEnumerator NextLevel()
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("Next level");
            Game.NextLevel();
        }
    }
}
