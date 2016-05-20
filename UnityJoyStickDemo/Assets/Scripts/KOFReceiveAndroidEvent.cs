using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

public class KOFReceiveAndroidEvent : MonoBehaviour
{
    private static AndroidJavaObject mActivity;                 //UnityActivity实例;
    private static AndroidJavaObject mHeadPhonePlugin;          //耳机插件;
    private static AndroidJavaObject mjavaHeadphoneObj;         // 加载ncy.lib.headphonelib.Headphone



    #region Invoke事件触发



    #endregion


    public void Awake()
    {
        Object.DontDestroyOnLoad(this);
    }

    public void OnEnable()
    {

    }

    public void OnDisable()
    {

    }

    // Use this for initialization
    void Start()
    {
        //AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //mActivity = javaClass.GetStatic<AndroidJavaObject>("currentActivity");

        //mjavaHeadphoneObj = new AndroidJavaObject("example.com.gamehandleandroid");

        //AndroidJavaObject app = mActivity.Call<AndroidJavaObject>("getApplicationContext");
        //mHeadPhonePlugin = new AndroidJavaObject("com.Dong3d.Shoot.InputPlugin");
    }


    #region Android调用Unity接口;

    /// <summary>
    /// Android检测音量上的按下事件时 发送事件到Unity.
    /// </summary>
    public void OnSingleClick(String strTest)
    {
        Debug.Log(strTest);

        // 抛出消息.
        
    }

    #endregion
}
