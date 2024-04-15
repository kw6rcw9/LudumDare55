using Core.RoomSystem;
using UISystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.InputSystem
{
    public class IntroSceneListener : MonoBehaviour
    {
        
        [SerializeField] private IntroScene introScene; 
        private PlayerInput _inputSystem;

        private void Awake() {
            _inputSystem = new PlayerInput();
        }
        
        private void OnEnable()
        {
            
            _inputSystem.Enable();
            _inputSystem.GamePlay.Enter.performed +=  ReadEnter;
           
        }

        public void OnDisable()
        {
            _inputSystem.GamePlay.Enter.performed -=  ReadEnter;
           
            _inputSystem.Disable();
        }


        private void ReadEnter(InputAction.CallbackContext obj)
        {
            introScene.ToLevelSelection();
        }
    }
}
