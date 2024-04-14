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
            SceneManager.LoadScene("MainMenu");
        } else {
            errorContent.text = "It is forbiden to use the symbol \" in the name";
        }
    }
}
