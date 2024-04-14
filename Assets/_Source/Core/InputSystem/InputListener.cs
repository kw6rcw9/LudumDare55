using System;
using System.Collections;
using System.Collections.Generic;
using UISystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputListener : MonoBehaviour
{
   private PlayerInput _inputSystem;
   private Menu _menu;
   
   [Inject]
   private void Construct(PlayerInput inputSystem, Menu menu)
   {
      _inputSystem = inputSystem;
      _menu = menu;
     _inputSystem.Enable();
      Debug.Log("constructes");
   }

   private void OnEnable()
   {
      _inputSystem.GamePlay.DoorInteraction.performed += context => ReadDoorInteraction();
      _inputSystem.GamePlay.Escape.performed += context => ReadEscape();
   }

   public void OnDisable()
   {
      _inputSystem.GamePlay.DoorInteraction.performed -= context => ReadDoorInteraction();
   }


   private void ReadDoorInteraction()
   {
      Debug.Log("Pressed E");
   }

   private void ReadEscape()
   {
      _menu.ToggleSettings();
   }
}
