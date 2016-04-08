//=========================================================================
// File: AudioDataSingleton.cs
//
// Summary:声音数据单例模块.
//
// Author: YuLiang
// 
// Created Date:   2016-03-22
//
//=========================================================================
// This file is part of VRShotGame-csharp
//
//
// CopyRight (c)
// 
//
//
//=========================================================================

using System;
using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// 玩家选择播放模式,EarphonePlay：耳机播放, SpeakerPlay:扬声器播放.
/// </summary>
public enum AudioOutputMode
{
    EarphonePlay = 0,
    SpeakerPlay = 1
}

public class AudioDataSingleton
{

    #region Data Variables

    public int _nVolume;                        // 音量.



    #endregion

    #region 事件变量

    //public Action<bool> _actEarphonePlug;                   // 耳机插拔的事件对象.
    //public Action<AudioOutputMode> _actChangeAudioMode;     // 改变播放模式，由玩家触发.
    public Action<int> _actChangeVolume;                    // 向KOF发送改变音量大小的事件.

    //public Action _actAddVolume;                            // 增加音量.
    //public Action _actReduceVolume;                         // 减少音量.

    #endregion

    #region 事件函数

    ///// <summary>
    ///// 触发增加音量事件.
    ///// </summary>
    //public void InvokeAddVolume()
    //{
    //    if (_actAddVolume != null)
    //    {
    //        _actAddVolume();
    //    }
    //}

    ///// <summary>
    ///// 触发减少音量事件.
    ///// </summary>
    //public void InvokeReduceVolume()
    //{
    //    if (_actReduceVolume != null)
    //    {
    //        _actReduceVolume();
    //    }
    //}

    /// <summary>
    /// 向KOF发送改变音量大小的事件.
    /// </summary>
    /// <param name="nVolume"></param>
    public void InvokeChangeVolume(int nVolume)
    {
        if (_actChangeVolume != null)
        {
            _actChangeVolume(nVolume);
        }
    }

    ///// <summary>
    ///// 触发耳机插拔的事件.
    ///// </summary>
    ///// <param name="bSet"></param>
    //public void InvokeEarphonePlug(bool bSet)
    //{
    //    if (_actEarphonePlug != null)
    //    {
    //        _actEarphonePlug(bSet);
    //    }
    //}

    ///// <summary>
    ///// 触发改变声音播放模式的事件.
    ///// </summary>
    //public void InvokeChangeAudioMode(AudioOutputMode audioOutputMode)
    //{
    //    if (_actChangeAudioMode != null)
    //    {
    //        _actChangeAudioMode(audioOutputMode);
    //    }
    //}

    #endregion

    #region Functions

    #endregion


    #region 单例部分

    public static AudioDataSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AudioDataSingleton();
            }

            return _instance;
        }
    }

    // 构造函数.
    public AudioDataSingleton()
    {

    }

    // 私有变量
    private static AudioDataSingleton _instance;

    #endregion

}
