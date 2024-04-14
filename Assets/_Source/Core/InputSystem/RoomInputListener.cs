using System.Collections;
using System.Collections.Generic;
using Core.RoomSystem;
using UISystem;
using UnityEngine;
using Zenject;

public class RoomInputListener : MonoBehaviour
{
    [SerializeField] private GameObject hall; 
    private PlayerInput _inputSystem;
    private Menu _menu;
    private GeneratorController _generatorController;
   
    [Inject]
    private void Construct(PlayerInput inputSystem, Menu menu, GeneratorController generatorController)
    {
        _inputSystem = inputSystem;
        _menu = menu;
        _generatorController = generatorController;
        _inputSystem.Enable();
        Debug.Log("constructes");
    }
    private void OnEnable()
    {
        
        _inputSystem.GamePlay.Escape.performed += context => ReadEscape();
    }

    public void OnDisable()
    {
        
        _inputSystem.Disable();
    }

    

    private void ReadEscape()
    {
        _menu.ToggleSettings();
    }
}
