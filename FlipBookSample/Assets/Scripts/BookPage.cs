using UnityEngine;
using System.Collections;

public class BookPage : MonoBehaviour
{
    private Transform _transform;

	// Use this for initialization
	void Start ()
	{
	    _transform = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        _transform.RotateAround(Vector3.zero, Vector3.up, 60 * Time.deltaTime);

	}
}
