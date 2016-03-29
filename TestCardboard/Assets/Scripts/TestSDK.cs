//=========================================================================
// File: TestSDK.cs
//
// Summary:测试CardBoardSDK
//
// Author: YuLiang
// 
// Created Date:   2016-03-12
//
//=========================================================================
// This file is part of TestCardboard
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
    public class TestSDK : MonoBehaviour
    {

        #region Date Variables

        #endregion

        #region Ui Variables

        public float fSetValue;

        #endregion

        #region Awake,Start,Update,OnEnable

        void Awake()
        {
            
        }

        void Start()
        {
            string strShowCardboard = Cardboard.CARDBOARD_SDK_VERSION;

            //string strShow = Cardboard.SDK.name;
            //string strShow = Cardboard.SDK.ToString();
            Debug.Log(strShowCardboard);
        }

        void OnEnable()
        {

        }

        void OnDisable()
        {

        }

        void Update()
        {

        }

        #endregion

        #region Other Functions.

        #endregion

    }
}