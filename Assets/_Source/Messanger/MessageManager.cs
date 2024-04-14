using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;
using SimpleJSON;
using TMPro;

public class MessageManager : MonoBehaviour
{
    [SerializeField] private TMP_Text content;
    private UserData userData;

    void Awake()
    {
        userData = new UserData();
        sendMessage("3", "meowwww");
        // receiveMessages("3");
    }

    public void sendMessage(string roomID, string messageText)
    {

        RestClient.Put($"https://firetest-96e6d-default-rtdb.firebaseio.com/messages/{roomID}/{userData.userID}.json", "{\"message\": \"" + messageText + "\",\"createdAt\": " + DateTimeOffset.UtcNow.ToUnixTimeSeconds() + "}");

    }

    public void receiveMessages(string roomID)
    {
        RestClient.Get($"https://firetest-96e6d-default-rtdb.firebaseio.com/messages/{roomID}.json").Then(response =>
        {
            Debug.Log(response.Text);
            content.text = response.Text;
        });
    }
}
