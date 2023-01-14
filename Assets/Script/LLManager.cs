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
    //�Œ胉���_������
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

    //�I�[�f�B�I�\�[�X
    public AudioSource sfxSource;

    //�����t�@�C�����X�g
    public List<AudioClip> voiceList_Man = new List<AudioClip>();
    public List<AudioClip> voiceList_Woman = new List<AudioClip>();
    public AudioClip voice_NoLL;

    //TextMeshPro
    public TextMeshProUGUI testTMP;

    //�\������e�L�X�g
    string testString_Man = "�Ƃ���ł�A�Ȃ񂩂���ˁ[���H";
    string testString_Woman = "���΂������̏Ă����N�b�L�[�������悤��";
    string testString_Woman_English = "Your Gramby baked you some cookies. Take one.";
    string testString_NoLL = "�v���v���V��A�ǂ��ɍs�������́H";

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
    /// �����Đ�
    /// </summary>
    public void PlayVoice(List<AudioClip> _clipList, string _string)
    {
        //�N���b�v�̒������擾���邽�߂̃��X�g�𐶐�----------------------------------------------------
        List<float> clipLengthList = new List<float>();

        //�S�ẴN���b�v�̒������擾--------------------------------------------------------------------
        foreach (AudioClip clip in _clipList)
            clipLengthList.Add(clip.length);

        //�����_��Index��ݒ�---------------------------------------------------------------------------
        MyRandom myRandom = new MyRandom((uint)_string.Length);
        int randomIndex = myRandom.Range(0, _clipList.Count);

        //�Đ�------------------------------------------------------------------------------------------
        sfxSource.clip = null;
        sfxSource.clip = _clipList[randomIndex];
        sfxSource.Play();

        //�҂����Ԃ��o�߂����疳�����[�v�Đ��J�n--------------------------------------------------------
        tween_VoiceLoop = DOVirtual.DelayedCall(_clipList[randomIndex].length, () => VoiceLoop(), false);

        //���[�v�Đ�------------------------------------------------------------------------------------
        void VoiceLoop()
        {
            //�O��ƈقȂ郉���_��Index���擾---------------------------------------
            randomIndex = DifferentRandomInt(randomIndex);

            //�Đ����~�߂�----------------------------------------------------------
            sfxSource.Stop();

            //�N���b�v�ݒ�----------------------------------------------------------
            sfxSource.clip = _clipList[randomIndex];

            //�Đ�------------------------------------------------------------------
            sfxSource.Play();

            //�҂����Ԃ��o�߂����疳�����[�v�ĊJ------------------------------------
            tween_VoiceLoop = DOVirtual.DelayedCall(_clipList[randomIndex].length, () => VoiceLoop(), false);
        }

        // �O��ƈقȂ郉���_�����l���擾
        int DifferentRandomInt(int currentInt)
        {
            int i = 0;
            while (true)
            {
                //�N���b�v����1�����Ȃ���΁A0��Ԃ�
                if (_clipList.Count == 1) return 0;

                //�Œ胉���_���������擾
                i = myRandom.Range(0, _clipList.Count);

                //�O��Ɠ������ɂȂ�����A�ēx�擾������
                if (i == currentInt) continue;

                break;
            }

            //���ʂ�Ԃ�
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
    /// �Z���t��\��
    /// </summary>
    void InsertQuote(TextMeshProUGUI _tmp, Character _character, string _string, float _durationBoost = 1)
    {
        //������\������X�s�[�h��ݒ�
        float duration = (_string.Length * 0.05f) / _durationBoost;

        //�L�����N�^�[�ʂ̉������Đ�
        if (_character == Character.Man) PlayVoice(voiceList_Man, _string);
        else if (_character == Character.Woman) PlayVoice(voiceList_Woman, _string);
        else if (_character == Character.NoLL) PlayVoice(voice_NoLL, _string);

        //�e�L�X�g��\��
        _tmp.text = null;
        //tween_Quote = _tmp.DOText(_string, duration)
        //   .SetEase(Ease.Linear)
        //   .OnComplete(() =>
        //   {
        //       tween_VoiceLoop.Kill(); //���Đ����~�߂�
        //   });
    }
}