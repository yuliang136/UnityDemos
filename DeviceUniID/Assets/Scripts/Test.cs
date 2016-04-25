using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    string strDeviceId = SystemInfo.deviceUniqueIdentifier;

        Debug.Log(strDeviceId);
	}
}
