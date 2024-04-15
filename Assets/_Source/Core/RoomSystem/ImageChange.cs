using System;
using System.Collections;
using System.Collections.Generic;
using Core.RoomSystem;
using UnityEngine;

public class ImageChange : MonoBehaviour
{
    [SerializeField] private Sprite newSprite;
    [SerializeField] private Services service;
    private Sprite _defaultSprite;
    private void OnEnable()
    {
        _defaultSprite = transform.GetComponent<SpriteRenderer>().sprite;
        RoomController.ChangeSprite += ChangeSprite;
    }

    private void OnDisable()
    {
        transform.GetComponent<SpriteRenderer>().sprite = _defaultSprite;
        RoomController.ChangeSprite -= ChangeSprite;
    }

    private void ChangeSprite(Services service1)
    {
        if (service1 == service)
        {
            Debug.Log("Change ");
            transform.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }


}
