using UnityEngine;
using UnityEngine.VR;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class VRHelper : MonoBehaviour
{
	static public bool isVRScene = false;
	static private VRDeviceType _vrDeviceType = VRDeviceType.None;

	// 
	void Start()
	{
		SetVRDeviceType(VRDeviceType.Split);
		isVRScene = true;
	}

	// 
	void OnDisable()
	{
		SetVRDeviceType(VRDeviceType.None);
		isVRScene = false;
	}

	// 
	static public void SetVRDeviceType(VRDeviceType vrDeviceType)
	{
		if (_vrDeviceType == vrDeviceType) { return; }

		_vrDeviceType = vrDeviceType;
		VRSettings.loadedDevice = _vrDeviceType;
		bool vr = (_vrDeviceType != VRDeviceType.None);
		VRSettings.showDeviceView = vr;
		VRSettings.enabled = vr;
	}
}