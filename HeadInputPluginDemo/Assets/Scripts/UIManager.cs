using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

/// <summary>
/// 处理按钮的Exit和Enter事件 记录选中的GameObject.
/// 监听耳机的Click事件，由当前选中的GameObject来触发Click调用
/// </summary>
public class UIManager : MonoBehaviour
{

    // 设置声音播放的方式.
    //public GameObject _goEarphonePlug;

    public void Awake()
    {
        Object.DontDestroyOnLoad(this);

        // 默认值为3
        //YLManager.Instance._nVolume = 3;
    }



    private GameObject _goSelect;  // 记录选中的GameObject.

    public void OnEnable()
    {
        //// 监听Click事件.
        //KOFReceiveAndroidEvent.
        NotificationCenter.Instance.AddEventHandler(EventEnums.OnSingleClick, HandleEarphoneClick);

        //NotificationCenter.Instance.AddEventHandler(EventEnums.OnEarphonePlug, HandleEarphonePlug);
    }

    public void OnDisable()
    {
        NotificationCenter.Instance.RemoveEventHandler(EventEnums.OnSingleClick, HandleEarphoneClick);

        //NotificationCenter.Instance.RemoveEventHandler(EventEnums.OnEarphonePlug, HandleEarphonePlug);
    }

    public void PointerEnter(GameObject goSel)
    {
        _goSelect = goSel;
    }

    public void PointerExit(GameObject goSel)
    {
        _goSelect = null;
    }

    ///// <summary>
    ///// 处理耳机插拔事件.
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //private void HandleEarphonePlug(object sender, EventArgs e)
    //{
    //    if (YLManager.Instance._bEarphonePlug)
    //    {
    //        // 接上耳机时 显示界面.
    //        Debug.Log("EarphonePlug Open");
    //        _goEarphonePlug.SetActive(true);

    //        // 插上耳机 默认设置为耳机播放.
    //        // 发送事件为耳机播放.
    //        NotificationCenter.Instance.NotifyEvent(EventEnums.OnEarphonePlay, null);
    //    }
    //    else
    //    {
    //        // 去掉耳机时 隐藏界面.
    //        Debug.Log("EarphonePlug Close");
    //        _goEarphonePlug.SetActive(false);

    //        // 拔掉耳机 直接设置为外放.
    //        // 发送事件为外放.
    //        NotificationCenter.Instance.NotifyEvent(EventEnums.OnSpeakerPlay, null);
    //    }
    //}

    /// <summary>
    /// 由耳机交互单例发送过来的事件.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleEarphoneClick(object sender, System.EventArgs e)
    {
        // 判断当前选中的GameObject名字来决定执行什么操作.

        Debug.Log("HandleEarphoneClick");

        if (_goSelect != null)
        {
            // 这里应该发送事件. 由KOFReceiveAndroidEvent处理.
            // 控制耳机调整音量.
            if (_goSelect.name == "AddVolume")
            {   
                //EventArgs ea = new EventArgs();
                
                //Debug.Log("AddVolume");

                // 需要在事件里传递参数.

                AudioDataSingleton.Instance._nVolume++;
                if (AudioDataSingleton.Instance._nVolume > 10)
                {
                    AudioDataSingleton.Instance._nVolume = 10;
                }

                Debug.Log("AddVolume");

                AudioDataSingleton.Instance.InvokeChangeVolume(AudioDataSingleton.Instance._nVolume);

                //NotificationCenter.Instance.NotifyEvent(EventEnums.OnChangeVolume,null);
            }
            else if (_goSelect.name == "ReduceVolume")
            {
                AudioDataSingleton.Instance._nVolume--;
                if (AudioDataSingleton.Instance._nVolume < 0)
                {
                    AudioDataSingleton.Instance._nVolume = 0;
                }

                Debug.Log("ReduceVolume");

                AudioDataSingleton.Instance.InvokeChangeVolume(AudioDataSingleton.Instance._nVolume);
            }
        }
    }

}
