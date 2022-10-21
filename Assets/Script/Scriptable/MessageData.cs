using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateMessageAsset")]
public class MessageData : ScriptableObject
{
    [SerializeField]
    public Message[] _message;
}

[Serializable]
public class Message
{
    [SerializeField]
    private string _nameStr = "–¼‘O";
    [SerializeField]
    private string _messageStr = "aaaaaaa";

    public string NameStr => _nameStr;
    public string MessageStr => _messageStr;
}

