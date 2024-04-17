using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Core.RoomSystem;
using UISystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Random = System.Random;

public class HallInputListener : MonoBehaviour
{
   private PlayerInput _inputSystem;
   private Menu _menu;
   private GeneratorController _generatorController;
   [SerializeField] private AudioSource knock;
   [SerializeField] private AudioSource open;
   [SerializeField] private AudioSource open2;
   [SerializeField] private AudioSource open3;
   private bool isInRoom;
   
   
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
      isInRoom = false;
      
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
        if (isInRoom) {
            return;
        }
        isInRoom = true;
        knock.Play();
        Debug.Log("Pressed E");
        Invoke("Do", 1.5f);
    }

   private void Do()
   {
      gameObject.SetActive(false);
      _generatorController.GetRoom();
      Random rnd = new Random();
      int a = rnd.Next(0, 3);
      switch (a)
      {
         case 0:
            open.Play();
            break;
         case 1:
            open2.Play();
            break;
         case 2:
            open3.Play();
            break;
      }
     
   }

   private void ReadEscape(InputAction.CallbackContext obj)
   {
      _menu.ToggleSettings();
   }
}
