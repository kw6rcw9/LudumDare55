using System;
using UnityEngine;
using Zenject;

namespace Core.RoomSystem
{
    public class RoomController : MonoBehaviour
    {
        [SerializeField] private RoomSettingsHandler roomSettingsHandler;
        private GeneratorController _controller;

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
                
                
            }
            CloseRoom();
        
        


        }

        private void CloseRoom()
        {
            
            transform.parent.gameObject.SetActive(false);
            _controller.Hall.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
