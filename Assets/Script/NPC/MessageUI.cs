using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public void MessageTextUpdate(string name, string message)
    {
        if (_messageText == null && _nameText == null) return;

        _nameText.text = name;
        _messageText.text = _init;

        Debug.Log(name);
        Debug.Log(message);

        if (_currentCor != null)
        {
            StopCoroutine(_currentCor);
        }

        _currentCor = StartCoroutine(TextCor(message, _waitTime));
    }

    /// <summary>
    /// 引数の文字列を_waitTimeずつ表示する
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    IEnumerator TextCor(string text, float waitTime)
    {
        bool isFinish = false;
        int index = 0;
        _messageText.text += text[index];

        while (isFinish == false)
        {
            yield return new WaitForSeconds(waitTime);
            index++;
            if (index >= text.Length)
            {
                yield break;
            }
            _messageText.text += text[index];
        }
    }
}
