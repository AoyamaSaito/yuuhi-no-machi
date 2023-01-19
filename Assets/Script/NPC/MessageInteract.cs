using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ToDo UniTaskを使ったバージョンに作り直す！

public class MessageInteract : MonoBehaviour, IInteracted
{
    [SerializeField]
    private MessageData _messageData;
    [SerializeField]
    private MessageUI _messageUI;

    private bool _isFirst = true;
    private int _textIndex = 0;
    private Message _currentMessage;

    public void Interact()
    {
        if (_messageUI == null) return;

        if(_isFirst == true)
        {
            _messageUI.PanelOn();
            _isFirst = false;
        }

        if(_textIndex >= _messageData._message.Length)
        {
            Debug.Log("MessageExit");
            Exit();
            return;
        }

        _currentMessage = _messageData._message[_textIndex];
        Debug.Log(_currentMessage.NameStr);
        bool isComplite = _messageUI.MessageTextUpdate(_currentMessage.NameStr, _currentMessage.MessageStr);

        if(isComplite)
        {
            _textIndex++;
        }
    }

    public void Exit()
    {
        if (_messageUI == null) return;

        _isFirst = true;
        _messageUI.PanelOff();
        _textIndex = 0;
    }
}
