using System;
using System.Collections;
using System.Collections.Generic;
using Core.RoomSystem;
using DG.Tweening;
using UnityEngine;

public class HandAnim : MonoBehaviour
{
    
    [SerializeField] private float speedOfRotate;
    [SerializeField] private Vector3 radius;

    private void OnEnable()
    {
        GeneratorController.EnterRoom += Anim;
    }

    private void OnDisable()
    {
        GeneratorController.EnterRoom -= Anim;
    }

    public void Anim()
    {
        if (transform.parent.parent.gameObject.activeSelf)
        {
            Debug.Log("Animate");
            transform.DORotate(radius, speedOfRotate);
        }
    }
    
    
}
