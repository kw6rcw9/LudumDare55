using Core.RoomSystem;
using UISystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.InputSystem
{
    public class RoomInputListener : MonoBehaviour
    {
        [SerializeField] private GameObject hall; 
        private PlayerInput _inputSystem;
        private Menu _menu;
        private GeneratorController _generatorController;
        private RoomController _roomController;
   
        [Inject]
        private void Construct(PlayerInput inputSystem, Menu menu, GeneratorController generatorController)
        {
            _inputSystem = inputSystem;
            _menu = menu;
            _generatorController = generatorController;
        
            //Debug.Log("constructes");
        }
        private void OnEnable()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeSelf)
                {
                    _roomController = transform.GetChild(i).GetComponent<RoomController>();
                    Debug.Log(_roomController);
                }
            }
            _inputSystem.Enable();
            _inputSystem.GamePlay.Escape.performed +=  ReadEscape;
            _inputSystem.GamePlay.Police.performed += CallPolice;
            _inputSystem.GamePlay.Medical.performed +=  CallMedical;
            _inputSystem.GamePlay.FireDeparment.performed += CallFireDepartment;
            _inputSystem.GamePlay.GasService.performed +=  CallGasService;
            _inputSystem.GamePlay.Mortuary.performed += CallMortuary;
            _inputSystem.GamePlay.SanitaryInspection.performed +=  CallSanitary;
            _inputSystem.GamePlay.Roscomnadzor.performed +=  CallRoskomdanzor;
            _inputSystem.GamePlay.Thieves.performed +=  CallThieves;
        }

        public void OnDisable()
        {
            _inputSystem.GamePlay.Escape.performed -=  ReadEscape;
            _inputSystem.GamePlay.Police.performed -=  CallPolice;
            _inputSystem.GamePlay.Medical.performed -= CallMedical;
            _inputSystem.GamePlay.FireDeparment.performed -=  CallFireDepartment;
            _inputSystem.GamePlay.GasService.performed -=  CallGasService;
            _inputSystem.GamePlay.Mortuary.performed -=  CallMortuary;
            _inputSystem.GamePlay.SanitaryInspection.performed -= CallSanitary;
            _inputSystem.GamePlay.Roscomnadzor.performed -= CallRoskomdanzor;
            _inputSystem.GamePlay.Thieves.performed -=  CallThieves;
            _inputSystem.Disable();
        }

        private void CallPolice(InputAction.CallbackContext obj)
        {
            _roomController.CheckOnCorrectService(Services.Police);
        }
        private void CallMedical(InputAction.CallbackContext obj)
        {
            _roomController.CheckOnCorrectService(Services.Medical);
        }
        private void CallFireDepartment(InputAction.CallbackContext obj)
        {
        
        }
        private void CallGasService(InputAction.CallbackContext obj)
        {
        
        }
        private void CallMortuary(InputAction.CallbackContext obj)
        {
        
        }
        private void CallSanitary(InputAction.CallbackContext obj)
        {
        
        }
        private void CallRoskomdanzor(InputAction.CallbackContext obj)
        {
        
        }
        private void CallThieves(InputAction.CallbackContext obj)
        {
        
        }

    

        private void ReadEscape(InputAction.CallbackContext obj)
        {
            Debug.Log("escape");
            _menu.ToggleSettings();
        }
    }
}
