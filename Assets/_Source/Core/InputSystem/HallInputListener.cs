using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Core.RoomSystem;
using UISystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class HallInputListener : MonoBehaviour
{
   private PlayerInput _inputSystem;
   private Menu _menu;
   private GeneratorController _generatorController;
   
   [Inject]
   private void Construct(PlayerInput inputSystem, Menu menu, GeneratorController generatorController)
   {
      _inputSystem = inputSystem;
      _menu = menu;
      _generatorController = generatorController;
      Debug.Log("constructes");
   }

   private void OnEnable()
   {
      
      _inputSystem.Enable();
      Debug.Log("Enabled");
      _inputSystem.GamePlay.DoorInteraction.performed +=  ReadDoorInteraction;
      _inputSystem.GamePlay.Escape.performed +=  ReadEscape;
   }

   public void OnDisable()
   {
      _inputSystem.GamePlay.DoorInteraction.performed -=  ReadDoorInteraction;
      _inputSystem.GamePlay.Escape.performed -= ReadEscape;
      _inputSystem.Disable();
   }


   private void ReadDoorInteraction(InputAction.CallbackContext obj)
   {
      Debug.Log("Pressed E");
      gameObject.SetActive(false);
      _generatorController.GetRoom();
      
   }

   private void ReadEscape(InputAction.CallbackContext obj)
   {
      _menu.ToggleSettings();
   }
}
