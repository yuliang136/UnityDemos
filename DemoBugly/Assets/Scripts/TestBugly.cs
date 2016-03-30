using System;
using UnityEngine;
using System.Collections;

public class TestBugly : MonoBehaviour {

    private const string BuglyAppIDForAndroid = "900023762";

    public void Start()
    {
        BuglyAgent.PrintLog(LogSeverity.LogInfo, "Demo Start()");

        InitBuglySDK();

        // 代码自动抛出一次.
        OutException();
    }

    public void OutException()
    {
        //throwException(new System.Exception("Test Ronyl Exception！！！"));

        FindGameObject();
    }

    private void FindGameObject()
    {
        //System.Console.Write("it will throw NullReferenceException");
        Debug.Log("It will throw NullReferenceException");

        GameObject go = GameObject.Find("test");
        string gName = go.name;

        //System.Console.Write(gName);
        Debug.Log(gName);
    }

    //private void throwException(Exception e)
    //{
    //    if (e == null)
    //        return;

    //    BuglyAgent.PrintLog(LogSeverity.LogWarning, "Throw exception: {0}", e.ToString());

    //    testDeepFrame(e);
    //}

    //private void testDeepFrame(Exception e)
    //{

    //    throw e;
    //}

    void InitBuglySDK()
    {

        // TODO NOT Required. Enable debug log print, please set false for release version
        BuglyAgent.ConfigDebugMode(true);

        // TODO NOT Required. Register log callback with 'BuglyAgent.LogCallbackDelegate' to replace the 'Application.RegisterLogCallback(Application.LogCallback)'
        // BuglyAgent.RegisterLogCallback (CallbackDelegate.Instance.OnApplicationLogCallbackHandler);

        // 如何获得设备唯一Id号.
        // 用设备号代替用户名.
        
        BuglyAgent.ConfigDefault("Bugly", null, "ronylTest", 0);

#if UNITY_IPHONE || UNITY_IOS
		BuglyAgent.InitWithAppId (BuglyAppIDForiOS);
#elif UNITY_ANDROID
        BuglyAgent.InitWithAppId(BuglyAppIDForAndroid);
#endif

        // TODO Required. If you do not need call 'InitWithAppId(string)' to initialize the sdk(may be you has initialized the sdk it associated Android or iOS project),
        // please call this method to enable c# exception handler only.
        BuglyAgent.EnableExceptionHandler();

        // TODO NOT Required. If you need to report extra data with exception, you can set the extra handler
        // BuglyAgent.SetLogCallbackExtrasHandler (MyLogCallbackExtrasHandler);

    }
}
