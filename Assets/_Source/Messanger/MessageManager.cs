using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
public class MessageManager : MonoBehaviour
{
    private UserData userData;
    public List<Message> messages;
    private int message_amount;

    void Awake()
    {
        userData = new UserData();
        // sendMessage("2", "meowwww");
        receiveMessages("2");
        foreach (var message in messages) {
            Debug.Log(message.userName +" "+ message.message +" "+ message.createdAt);
        }
    }

    public void receiveMessages(string roomID) {
        RestClient.Get($"https://firetest-96e6d-default-rtdb.firebaseio.com/messages/{roomID}.json").Then(response =>
        {
            // Debug.Log(response.Text);
            JObject obj = JObject.Parse(response.Text);

            foreach (var property in obj.Properties())
            {
                // Debug.Log(property.Name);
                RestClient.Get("https://firetest-96e6d-default-rtdb.firebaseio.com/users/" + property.Name + ".json").Then(response =>
                {
                    AddMessage(new Message(response.Text, obj[property.Name]["message"].ToString(), Int32.Parse(obj[property.Name]["createdAt"].ToString())));
                });
            }
            message_amount = obj.Count;
        });
        Debug.Log(message_amount);
    }

    private void AddMessage(Message message) {
        messages.Add(message);
        Debug.Log(messages[messages.Count-1].userName +" "+ messages[messages.Count-1].message +" "+ messages[messages.Count-1].createdAt);

    }
    public void sendMessage(string roomID, string messageText)
    {

        RestClient.Put($"https://firetest-96e6d-default-rtdb.firebaseio.com/messages/{roomID}/{userData.userID}.json", "{\"message\": \"" + messageText + "\",\"createdAt\": " + DateTimeOffset.UtcNow.ToUnixTimeSeconds() + "}");

    }
}

public class Message {
    public string userName { get; set; } = null;
    public string message { get; set; } = null;
    public int createdAt { get; set; } = 0;

    public Message(string _userName, string _message, int _createdAt)
    {
        userName = _userName;
        createdAt = _createdAt;
        message = _message;
    }
}