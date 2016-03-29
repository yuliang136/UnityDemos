using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

public class KOFReceiveAndroidEvent : MonoBehaviour
{
    private static AndroidJavaObject mActivity;                //UnityActivity实例;
    private static AndroidJavaObject mHeadPhonePlugin;        //耳机插件;

    private static AndroidJavaObject _javaHeadphoneObj;       // 加载ncy.lib.headphonelib.Headphone

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



    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
//#if ANDROID_DEVICE

        try
        {
            AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            mActivity = javaClass.GetStatic<AndroidJavaObject>("currentActivity");

            // 操作包类 ncy.lib.headphonelib.Headphone
            _javaHeadphoneObj = new AndroidJavaObject("ncy.lib.headphonelib.Headphone");

            //AndroidJavaObject app = mActivity.Call<AndroidJavaObject>("getApplicationContext");
            mHeadPhonePlugin = new AndroidJavaObject("com.Dong3d.Shoot.InputPlugin");
            mActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                if (mHeadPhonePlugin != null)
                {
                    mHeadPhonePlugin.Call("Init", mActivity);
                }
            }));   
        }
        catch (Exception ex)
        {
            
            Debug.Log(ex.Message);

            throw ex;
        }


#endif
    }

    #region Android调用Unity接口;

    /// <summary>
    /// Android检测音量上的按下事件时 发送事件到Unity.
    /// </summary>
    public void OnSingleClick(String strTest)
    {
        Debug.Log(strTest);

        // 抛出消息.
        NotificationCenter.Instance.NotifyEvent(EventEnums.OnSingleClick, null);  
    }

    /// <summary>
    /// 插上或者取下耳机时 触发函数.
    /// </summary>
    /// <param name="strInfo"></param>
    public void ChangePhonePlugin(string strInfo)
    {
        if ("false" == strInfo)
        {
            YLManager.Instance._bEarphonePlug = false;
        }
        else if ("true" == strInfo)
        {
            YLManager.Instance._bEarphonePlug = true;
        }

        string strShow = string.Format( 
                                        "KOF receive ChangePhonePlugin : {0}", 
                                        YLManager.Instance._bEarphonePlug);

        Debug.Log(strShow);

        // 发送消息.
        NotificationCenter.Instance.NotifyEvent(EventEnums.OnEarphonePlug, null);
    }

    #endregion

    public void OnEnable()
    {
        NotificationCenter.Instance.AddEventHandler(EventEnums.OnChangeVolume,HandleChangeVolume);

        NotificationCenter.Instance.AddEventHandler(EventEnums.OnEarphonePlay, HandleEarphonePlay);

        NotificationCenter.Instance.AddEventHandler(EventEnums.OnSpeakerPlay, HandleSpeakerPlay);
    }

    public void OnDisable()
    {
        NotificationCenter.Instance.RemoveEventHandler(EventEnums.OnChangeVolume, HandleChangeVolume);

        NotificationCenter.Instance.RemoveEventHandler(EventEnums.OnEarphonePlay, HandleEarphonePlay);

        NotificationCenter.Instance.RemoveEventHandler(EventEnums.OnSpeakerPlay, HandleSpeakerPlay);
    }

    private void HandleSpeakerPlay(object sender, EventArgs e)
    {
        // 打开扬声器 关闭耳机播放.
        _javaHeadphoneObj.CallStatic("openSpeakerphoneOn", mActivity, true);
    }

    private void HandleEarphonePlay(object sender, EventArgs e)
    {
        // 关闭扬声器 打开耳机播放.
        _javaHeadphoneObj.CallStatic("openSpeakerphoneOn", mActivity, false);
    }

    private void HandleChangeVolume(object sender, EventArgs e)
    {
        //string strShow = string.Format("Be about to Invoke Android adjustVolumn {0}", YLManager.Instance._nVolume);
        //Debug.Log(strShow);

        // 调用和Android通信接口.
        _javaHeadphoneObj.CallStatic("adjustVolumn", mActivity, YLManager.Instance._nVolume);

        //strShow = string.Format("After Invoke Android adjustVolumn {0}", YLManager.Instance._nVolume);
        //Debug.Log(strShow);
    }
}
