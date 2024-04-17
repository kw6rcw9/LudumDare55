using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalOutro : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private Image panel;
    [SerializeField] private Image img;
    [SerializeField] private TMP_Text text;
    private void Awake()
    {
        text.text = PlayerPrefs.GetString("UserName");
        source.Play();
        img.transform.DOScale(new Vector3(1.15f, 1.15f, 1.15f), 20);
        Invoke("Fade", 13);
        
    }

    void Fade()
    {
        panel.DOFade(1, 8).OnComplete(Return);
       
    }

    void Return()
    {
        PlayerPrefs.DeleteKey("Days");
        PlayerPrefs.DeleteKey("DayCounter");
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
