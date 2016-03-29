using UnityEngine;
using System.Collections;

public class LoadAndroidFunction : MonoBehaviour {

    private AndroidJavaClass _androidjc;
    private AndroidJavaObject _androidjo;
    private AndroidJavaObject _javaObj;

    private int _nVolume = 0;   // 音量数值设置.

    public void Awake()
    {
        Debug.Log("Awake");

        Object.DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () 
    {
        Debug.Log("Start");

        #if UNITY_ANDROID

        try 
        {          
            Debug.Log("Enter ANDROID_DEVICE");

            // 加载Context
            _androidjc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _androidjo = _androidjc.GetStatic<AndroidJavaObject>("currentActivity");

            Debug.Log("Want to load ncy.lib.headphonelib");

            // 加载类. 包名+类名
            _javaObj = new AndroidJavaObject("ncy.lib.headphonelib.Headphone");

            // 读取Static静态函数. 
            _javaObj.CallStatic("adjustVolumn", _androidjo, _nVolume);
            //Debug.Log("adjustVolume to 10");


        }
        catch (System.Exception ex)
        {
            Debug.Log("Enter Exception.");
            Debug.Log(ex.Message);
            //throw ex;
        }

        #endif
    }

    public void AmplifySound()
    {
        #if UNITY_ANDROID

        _nVolume++;
        if (_nVolume > 10)
        {
            _nVolume = 10;
        }

        SetSound();

        #endif
    }

    public void DecreasSound()
    {
        #if UNITY_ANDROID

        _nVolume--;
        if (_nVolume < 0)
        {
            _nVolume = 0;
        }

        SetSound();

        #endif
    }

    private void SetSound()
    {
        _javaObj.CallStatic("adjustVolumn", _androidjo, _nVolume);
    }
}
