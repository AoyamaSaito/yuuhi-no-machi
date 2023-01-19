using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro; //TextMeshPro
using DG.Tweening; //DOTween

public class LLManager : MonoBehaviour
{
    //固定ランダム整数
    public class MyRandom
    {
        private uint x, y, z, w;

        public MyRandom() : this((uint)DateTime.Now.Ticks) { }

        public MyRandom(uint seed)
        {
            setSeed(seed);
        }

        public void setSeed(uint seed)
        {
            x = seed; y = x * 3266489917U + 1; z = y * 3266489917U + 1; w = z * 3266489917U + 1;
        }

        public uint getNext()
        {
            uint t = x ^ (x << 11);
            x = y;
            y = z;
            z = w;
            w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));
            return w;
        }

        public int Range(int min, int max)
        {
            return min + Math.Abs((int)getNext()) % (max - 1);
        }
    }

    //オーディオソース
    public AudioSource sfxSource;

    //音声ファイルリスト
    public List<AudioClip> voiceList_Man = new List<AudioClip>();
    public List<AudioClip> voiceList_Woman = new List<AudioClip>();
    public AudioClip voice_NoLL;

    //TextMeshPro
    public TextMeshProUGUI testTMP;

    //表示するテキスト
    string testString_Man = "ところでよ、なんかくんねーか？";
    string testString_Woman = "おばあちゃんの焼いたクッキーをあげようね";
    string testString_Woman_English = "Your Gramby baked you some cookies. Take one.";
    string testString_NoLL = "プンプン坊や、どこに行きたいの？";

    //Tween
    Tween tween_Quote;
    Tween tween_VoiceLoop;

    enum Character
    {
        Man,
        Woman,
        NoLL
    }

    void PlayString_Man()
    {
        InsertQuote(testTMP, Character.Man, testString_Man, 1);
    }

    void PlayString_Woman()
    {
        InsertQuote(testTMP, Character.Woman, testString_Woman, 1);
    }

    void PlayString_Woman_English()
    {
        InsertQuote(testTMP, Character.Woman, testString_Woman_English, 2);
    }

    void PlayString_NoLL()
    {
        InsertQuote(testTMP, Character.NoLL, testString_NoLL);
    }

    /// <summary>
    /// 声を再生
    /// </summary>
    public void PlayVoice(List<AudioClip> _clipList, string _string)
    {
        //クリップの長さを取得するためのリストを生成----------------------------------------------------
        List<float> clipLengthList = new List<float>();

        //全てのクリップの長さを取得--------------------------------------------------------------------
        foreach (AudioClip clip in _clipList)
            clipLengthList.Add(clip.length);

        //ランダムIndexを設定---------------------------------------------------------------------------
        MyRandom myRandom = new MyRandom((uint)_string.Length);
        int randomIndex = myRandom.Range(0, _clipList.Count);

        //再生------------------------------------------------------------------------------------------
        sfxSource.clip = null;
        sfxSource.clip = _clipList[randomIndex];
        sfxSource.Play();

        //待ち時間を経過したら無限ループ再生開始--------------------------------------------------------
        tween_VoiceLoop = DOVirtual.DelayedCall(_clipList[randomIndex].length, () => VoiceLoop(), false);

        //ループ再生------------------------------------------------------------------------------------
        void VoiceLoop()
        {
            //前回と異なるランダムIndexを取得---------------------------------------
            randomIndex = DifferentRandomInt(randomIndex);

            //再生を止める----------------------------------------------------------
            sfxSource.Stop();

            //クリップ設定----------------------------------------------------------
            sfxSource.clip = _clipList[randomIndex];

            //再生------------------------------------------------------------------
            sfxSource.Play();

            //待ち時間を経過したら無限ループ再開------------------------------------
            tween_VoiceLoop = DOVirtual.DelayedCall(_clipList[randomIndex].length, () => VoiceLoop(), false);
        }

        // 前回と異なるランダム数値を取得
        int DifferentRandomInt(int currentInt)
        {
            int i = 0;
            while (true)
            {
                //クリップ数が1個しかなければ、0を返す
                if (_clipList.Count == 1) return 0;

                //固定ランダム整数を取得
                i = myRandom.Range(0, _clipList.Count);

                //前回と同じ数になったら、再度取得し直す
                if (i == currentInt) continue;

                break;
            }

            //結果を返す
            return i;
        }
    }

    public void PlayVoice(AudioClip _clip, string _string)
    {
        sfxSource.clip = null;
        sfxSource.clip = _clip;
        sfxSource.Play();
    }

    /// <summary>
    /// セリフを表示
    /// </summary>
    void InsertQuote(TextMeshProUGUI _tmp, Character _character, string _string, float _durationBoost = 1)
    {
        //文字を表示するスピードを設定
        float duration = (_string.Length * 0.05f) / _durationBoost;

        //キャラクター別の音声を再生
        if (_character == Character.Man) PlayVoice(voiceList_Man, _string);
        else if (_character == Character.Woman) PlayVoice(voiceList_Woman, _string);
        else if (_character == Character.NoLL) PlayVoice(voice_NoLL, _string);

        //テキストを表示
        _tmp.text = null;
        //tween_Quote = _tmp.DOText(_string, duration)
        //   .SetEase(Ease.Linear)
        //   .OnComplete(() =>
        //   {
        //       tween_VoiceLoop.Kill(); //声再生を止める
        //   });
    }
}