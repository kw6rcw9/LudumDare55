using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserData
{
    public string userName { get; set; } = null;

    public string userID { get; set; } = null;

    public UserData()
    {
        if (PlayerPrefs.HasKey("UserName") && PlayerPrefs.HasKey("UserID"))
        {
            userName = PlayerPrefs.GetString("UserName");
            userID = PlayerPrefs.GetString("UserID");
            Debug.Log(userName + "   " + userID);

        }
        else
        {
            SceneManager.LoadScene("Registration");
        }
    }

    public static bool ValidateName(string name)
    {
        if (name.Length > 10 || name.Contains('"')) {
            return false;
        }
        return true;
    }
}
