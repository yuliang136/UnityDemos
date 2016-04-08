using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

public class KOFReceiveAndroidEvent : MonoBehaviour
{
    private static AndroidJavaObject mActivity;                //UnityActivity实例;
    private static AndroidJavaObject mHeadPhonePlugin;        //耳机插件;
    private static AndroidJavaObject mjavaHeadphoneObj;       // 加载ncy.lib.headphonelib.Headphone

    //public Action<string> _actEarphoneClick;       // 耳机点击事件.

    #region Invoke事件触发

    ///// <summary>
    ///// 耳机点击触发.
    ///// </summary>
    //public void InvokeEarphoneClick(string strInfo)
    //{
    //    if (_actEarphoneClick != null)
    //    {
    //        _actEarphoneClick(strInfo);
    //    }
    //}

    #endregion


    public void Awake()
    {
        Object.DontDestroyOnLoad(this);
    }

    public void OnEnable()
    {
        AudioDataSingleton.Instance._actChangeVolume += HandleChangeVolume;
    }

    public void OnDisable()
    {
        AudioDataSingleton.Instance._actChangeVolume -= HandleChangeVolume;
    }

    // Use this for initialization
    void Start()
    {

        AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        mActivity = javaClass.GetStatic<AndroidJavaObject>("currentActivity");

        mjavaHeadphoneObj = new AndroidJavaObject("ncy.lib.headphonelib.Headphone");

        AndroidJavaObject app = mActivity.Call<AndroidJavaObject>("getApplicationContext");
        mHeadPhonePlugin = new AndroidJavaObject("com.Dong3d.Shoot.InputPlugin");
        mActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            if (mHeadPhonePlugin != null)
            {
                mHeadPhonePlugin.Call("Init", mActivity);
            }
        }));

        // 根据系统当前音量进行设置
        SetInitAudioVolume();

        // 向Android发送事件控制音量改变.
        HandleChangeVolume(AudioDataSingleton.Instance._nVolume);     
    }

    /// <summary>
    /// 获得当前耳机音量.
    /// </summary>
    private void SetInitAudioVolume()
    {
        int nCurVolume = mjavaHeadphoneObj.CallStatic<int>("getCurrentVolumn", mActivity);
        AudioDataSingleton.Instance._nVolume = nCurVolume;

        string strShow = string.Format("Get Current Audio Volume {0}",
                                        AudioDataSingleton.Instance._nVolume);

        Debug.Log(strShow);

    }

    #region Android调用Unity接口;

    /// <summary>
    /// Android检测音量上的按下事件时 发送事件到Unity.
    /// </summary>
    public void OnSingleClick(String strTest)
    {
        // Debug.Log(strTest);

        // 抛出消息.
        NotificationCenter.Instance.NotifyEvent(EventEnums.OnSingleClick, null);  
    }

    #endregion




    /// <summary>
    /// 改变音量.
    /// </summary>
    /// <param name="nVolume"></param>
    private void HandleChangeVolume(int nVolume)
    {

        Debug.Log("HandleChangeVolume");

        mjavaHeadphoneObj.CallStatic("adjustVolumn", mActivity, nVolume);
    }
}
