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

        private string AppID = "TestCode";

        private string Channelld = "VRHorrorHouse";

        #endregion


        #region Awake,Start,Update,OnEnable

        void Awake()
        {
            // 场景切换时 不销毁对象.
            DontDestroyOnLoad(this.gameObject);
        }

        void Start()
        {
            TalkingDataGA.OnStart(AppID, Channelld);
            TDGAAccount account = TDGAAccount.SetAccount(TalkingDataGA.GetDeviceId());

            account.SetAccountType(AccountType.ANONYMOUS);
        }

        public void OnApplicationPause(bool pauseState)
        {
            if (pauseState)
            {
                TalkingDataGA.OnEnd();
            }
            else
            {
                TalkingDataGA.OnStart(AppID, Channelld);
                TDGAAccount account = TDGAAccount.SetAccount(TalkingDataGA.GetDeviceId());
            }
        }

        public void OnDestroy()
        {
            TalkingDataGA.OnEnd();
        }
        
        #endregion
    }
}