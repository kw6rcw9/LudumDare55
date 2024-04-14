using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputListener : MonoBehaviour
{
   private PlayerInput _inputSystem;
   
   [Inject]
   private void Construct(PlayerInput inputSystem)
   {
      _inputSystem = inputSystem;
     _inputSystem.Enable();
      Debug.Log("constructes");
   }

   private void OnEnable()
   {
      _inputSystem.GamePlay.DoorInteraction.performed += context => ReadDoorInteraction();
   }

   public void OnDisable()
   {
      _inputSystem.GamePlay.DoorInteraction.performed -= context => ReadDoorInteraction();
   }


   private void ReadDoorInteraction()
   {
      Debug.Log("Pressed E");
   }
}
