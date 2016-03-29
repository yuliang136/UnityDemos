using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TalkingData : MonoBehaviour {

    private string AppID = "0B06F18B58EF167F567B7B3568887946";

    private string ChannelId = "Naocy";

    private string _strUserName = "TestTalkingData";

    // 第一次进应用时, 会触发Recover
    // 记录第一次Recover.
    private bool _bFirstRecover = true;

    private TDGAAccount _tdaaAccount;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
	void Start () 
    {
        Debug.Log("TalkingData Start");
        TalkingDataGA.OnStart(AppID, ChannelId);
        _tdaaAccount = TDGAAccount.SetAccount(TalkingDataGA.GetDeviceId());
        _tdaaAccount.SetAccountType(AccountType.ANONYMOUS);
        _tdaaAccount.SetAccountName(_strUserName);

        //Dictionary<string, object> dic = new Dictionary<string, object>();
        //dic.Add("step","1");

        //TalkingDataGA.OnEvent("GameTime", dic);
        
	}

    void OnApplicationPause(bool pauseState)
    {
        if (pauseState)
        {
            // 进入暂停状态
            Debug.Log("TalkingData Pause");
            TalkingDataGA.OnEnd();
            StartCoroutine(waitZ());
            Debug.Log("TalkingData Pause2");
            TalkingDataGA.OnStart(AppID, ChannelId);
        }
        else
        {
            if (_bFirstRecover)
            {
                // 第一次进入Recover 不做统计.
                _bFirstRecover = false;
            }
            else
            {
                // 第二次进入时才处理.
                // 从暂停状态恢复.
                Debug.Log("TalkingData Recover");
                TalkingDataGA.OnStart(AppID, ChannelId);
                TDGAAccount.SetAccount(TalkingDataGA.GetDeviceId());
                _tdaaAccount.SetAccountType(AccountType.ANONYMOUS);
                _tdaaAccount.SetAccountName(_strUserName);

                
        }
            }
    }

    IEnumerator waitZ()
    {
        yield return new WaitForSeconds(40f);
    }

    void OnDestroy()
    {
        //Debug.Log("TalkingData OnDestroy");

        //TalkingDataGA.OnEnd();
    }

    void OnApplicationQuit()
    {
        //Debug.Log("OnApplicationQuit ");
        //TalkingDataGA.OnStart(AppID, ChannelId);
    }

    
}
