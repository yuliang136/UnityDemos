using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	
	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetButtonDown("Fire1"))
	    {
	        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	        RaycastHit[] hits;
            hits = Physics.RaycastAll(ray,1000f);

            for (int i = 0; i < hits.Length; i++)
	        {
                RaycastHit hit = hits[i];
                Debug.Log(hit.collider.gameObject.name);
	        }
	    }
    }
}
