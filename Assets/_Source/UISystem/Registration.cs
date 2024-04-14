
using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_Text inputContent;
    [SerializeField] private TMP_Text errorContent;


    public void Register() {
        var userName = inputContent.text;
        if (UserData.ValidateName(userName)) {
            PlayerPrefs.SetString("UserName", userName);

            string userID = Guid.NewGuid().ToString();
            PlayerPrefs.SetString("UserID", userID);
            RestClient.Put($"https://firetest-96e6d-default-rtdb.firebaseio.com/users/{userID}.json", $"\"{userName}\"");

            SceneManager.LoadScene("MainMenu");
        } else {
            errorContent.text = "It is forbiden to use the symbol \" in the name";
        }
    }
}
