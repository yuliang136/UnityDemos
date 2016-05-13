using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestImageGray : MonoBehaviour
{
    public Image _changeImage;

	// Use this for initialization
	void Start () 
    {
        MgrCommon.SetImageGray(_changeImage,true);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
