//=========================================================================
// File: TalkingData.cs
//
// Summary:TalkingData 统计功能.
//
// Author: Administrator
// 
// Created Date:   2016-03-14
//
//=========================================================================
// This file is part of VRHorrorHouse
//
//
// CopyRight (c)
// 
//
//
//=========================================================================



using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TalkingData : MonoBehaviour
    {

        #region Date Variables

        private string AppID = "A8DDCA092253E2BF24795D89A491943D";

        private string Channelld = "TestTDKillProgress";

        #endregion


        #region Awake,Start,Update,OnEnable

        void Awake()
        {
            // 场景切换时 不销毁对象.
            DontDestroyOnLoad(this.gameObject);
        }

        void Start()
        {
            Debug.Log("Start");

            TalkingDataGA.OnStart(AppID, Channelld);
            TDGAAccount account = TDGAAccount.SetAccount(TalkingDataGA.GetDeviceId());

            account.SetAccountType(AccountType.ANONYMOUS);

            Debug.Log("Start End");
        }

        public void OnApplicationPause(bool pauseState)
        {
            if (pauseState)
            {
                Debug.Log("pauseState");

                TalkingDataGA.OnEnd();
            }
            else
            {
                Debug.Log("Recover");

                TalkingDataGA.OnStart(AppID, Channelld);
                TDGAAccount account = TDGAAccount.SetAccount(TalkingDataGA.GetDeviceId());
            }
        }

        public void OnDestroy()
        {
            Debug.Log("OnDestroy");

            TalkingDataGA.OnEnd();
        }
        
        #endregion
    }
}