using UnityEngine;
using System.Collections;

public class HighlighterSpectrum : HighlighterInteractive
{
	public bool random = true;
	public float velocity = 0.13f;

	private float t;

	#region MonoBehaviour
	// 
	protected override void Awake()
	{
		base.Awake();

        //t = random ? Random.value : 0f;

        //Debug.Log(t);
	}

	// 
	protected override void Update()
	{	
        base.Update();

	    Color cSetColor = Color.green;

        h.ConstantOnImmediate(cSetColor);

	    //h.ConstantOnImmediate(ColorTool.GetColor(t));
	    //t += Time.deltaTime * velocity;
	    //t %= 1f;
	}
	#endregion
}
