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
        [SerializeField] private AudioSource source;
        private PlayerInput _inputSystem;
        private Menu _menu;
        private GeneratorController _generatorController;
        private RoomController _roomController;
        private TaskScore _score;
        private AgressBar _bar;
   
        [Inject]
        private void Construct(PlayerInput inputSystem, 
            Menu menu, 
            GeneratorController generatorController,
            TaskScore score,
            AgressBar bar)
        {
            _bar = bar;
            _score = score;
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
                    _roomController.Construct(_score, _bar);
                    Debug.Log(_roomController.SettingsHandler.Services);
                    if (_roomController.SettingsHandler.Services == Services.CorrectCitizens
                        || _roomController.SettingsHandler.Services == Services.Thieves )
                    {
                        _inputSystem.Enable();
                        _inputSystem.GamePlay.Correct.performed +=  CorrectCitizens;
                    }
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
            _inputSystem.GamePlay.Correct.performed -=  CorrectCitizens;
            _inputSystem.Disable();
        }

        private void CallPolice(InputAction.CallbackContext obj)
        {
            source.Play();
            _roomController.CheckOnCorrectService(Services.Police);
            _inputSystem.Disable();
        }
        private void CallMedical(InputAction.CallbackContext obj)
        {
            source.Play();
            _roomController.CheckOnCorrectService(Services.Medical);
            _inputSystem.Disable();
        }
        private void CallFireDepartment(InputAction.CallbackContext obj)
        {
            source.Play();
            _roomController.CheckOnCorrectService(Services.FireDepartment);
            _inputSystem.Disable();
        }
        private void CallGasService(InputAction.CallbackContext obj)
        {
            source.Play();
            _roomController.CheckOnCorrectService(Services.GasService);
            _inputSystem.Disable();
        }
        private void CallMortuary(InputAction.CallbackContext obj)
        {
            source.Play();
            _roomController.CheckOnCorrectService(Services.Mortuary);
            _inputSystem.Disable();
        }
        private void CallSanitary(InputAction.CallbackContext obj)
        {
            source.Play();
            _roomController.CheckOnCorrectService(Services.Sanitary);
            _inputSystem.Disable();
        }
        private void CallRoskomdanzor(InputAction.CallbackContext obj)
        {
            source.Play();
            _roomController.CheckOnCorrectService(Services.Roskomdanzor);
            _inputSystem.Disable();
        }
        private void CallThieves(InputAction.CallbackContext obj)
        {
            source.Play();
            _roomController.CheckOnCorrectService(Services.Thieves);
            _inputSystem.Disable();
        }
        private void CorrectCitizens(InputAction.CallbackContext obj)
        {
            source.Play();
            _roomController.CheckOnCorrectService(Services.CorrectCitizens);
            _inputSystem.Disable();
        }

    

        private void ReadEscape(InputAction.CallbackContext obj)
        {
            Debug.Log("escape");
            _menu.ToggleSettings();
        }
    }
}
