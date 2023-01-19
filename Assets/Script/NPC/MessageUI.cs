using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ToDo UniTaskを使ったバージョンに作り直す！

public class MessageUI : MonoBehaviour
{
    [Header("Message")]
    [SerializeField]
    private GameObject _messagePanel;
    [SerializeField]
    private Text _nameText;
    [SerializeField]
    private Text _messageText;
    [SerializeField]
    private float _waitTime = 0.05f;

    private Coroutine _currentCor;
    private string _init = "";

    public void PanelOn()
    {
        gameObject.SetActive(true);
        _messageText.text = _init;
        _nameText.text = _init;
    }

    public void PanelOff()
    {
        gameObject.SetActive(false);
        _messageText.text = _init;
        _nameText.text = _init;
    }

    /// <summary>
    /// テキストを更新する
    /// </summary>
    /// <param name="index"></param>
    public bool MessageTextUpdate(string name, string message)
    {
        if (_messageText == null) return false;

        if(_isFinish == false)
        {
            _isFinish = true;
            StopCoroutine(_currentCor);
            return false;
        }

        if(_nameText != null) _nameText.text = name;
        _messageText.text = _init;

        if (_currentCor != null)
        {
            StopCoroutine(_currentCor);
        }

        _currentCor = StartCoroutine(TextCor(message, _waitTime));
        return true;
    }

    private bool _isFinish = true;
    /// <summary>
    /// 引数の文字列を_waitTimeずつ表示する
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    IEnumerator TextCor(string text, float waitTime)
    {
        _isFinish = false;
        int index = 0;
        _messageText.text += text[index];

        while (_isFinish == false)
        {
            yield return new WaitForSeconds(waitTime);
            index++;
            if (index >= text.Length)
            {
                _isFinish = true;
                yield break;
            }
            _messageText.text += text[index];
        }

        _messageText.text = text;
    }
}
