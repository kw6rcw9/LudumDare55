using System;
using System.Collections;
using System.Collections.Generic;
using Core.RoomSystem;
using UISystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class HallInputListener : MonoBehaviour
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
      _inputSystem.GamePlay.DoorInteraction.performed += context => ReadDoorInteraction();
      _inputSystem.GamePlay.Escape.performed += context => ReadEscape();
   }

   public void OnDisable()
   {
      _inputSystem.GamePlay.DoorInteraction.performed -= context => ReadDoorInteraction();
      _inputSystem.Disable();
   }


   private void ReadDoorInteraction()
   {
      Debug.Log("Pressed E");
      hall.SetActive(false);
      gameObject.SetActive(false);
      _generatorController.GetRoom();
      
   }

   private void ReadEscape()
   {
      _menu.ToggleSettings();
   }
}
