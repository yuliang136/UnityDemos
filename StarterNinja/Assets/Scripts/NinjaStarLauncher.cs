﻿using UnityEngine;
using System.Collections;

public class NinjaStarLauncher : MonoBehaviour {

	public GameObject ninja;
	public NinjaStarController ninjaStar;
	public AudioSource whooshSound;

	private GameController _gameController;
	private Vector3 _shooterOffset;

    private Vector3 _vrShooterOffset;

	void Start () {
		_gameController = this.GetComponent<GameController>();
		_shooterOffset = new Vector3(0.0f, 0.8f, 1.0f);
		
        _vrShooterOffset = new Vector3(0.0f, -0.4f, 1.0f);
	}
	
	void Update () 
    {
        //if (Input.GetButtonDown("Fire1") && !_gameController.isGameOver) {
        //    // First, turn the ninja so he's looking at the player's mouse / finger.
        //    Vector3 mouseLoc = Input.mousePosition;
        //    Vector3 worldMouseLoc = Camera.main.ScreenToWorldPoint(mouseLoc);
        //    worldMouseLoc.y = ninja.transform.position.y;
        //    ninja.transform.LookAt(worldMouseLoc);
        //    LaunchNinjaStarFrom(ninja, _shooterOffset);
        //}	

	    if (Cardboard.SDK.VRModeEnabled && Cardboard.SDK.Triggered && !_gameController.isGameOver)
	    {
	        GameObject goVRLauncher = Cardboard.SDK.GetComponentInChildren<CardboardHead>().gameObject;

            LaunchNinjaStarFrom(goVRLauncher,_vrShooterOffset);
	    }
        else if (!Cardboard.SDK.VRModeEnabled && Input.GetButtonDown("Fire1") && !_gameController.isGameOver)
        {
            Vector3 mouseLoc = Input.mousePosition;
            Vector3 worldMouseLoc = Camera.main.ScreenToWorldPoint(mouseLoc);
            worldMouseLoc.y = ninja.transform.position.y;
            ninja.transform.LookAt(worldMouseLoc);
            LaunchNinjaStarFrom(ninja, _shooterOffset);
        }

    }
	
	void LaunchNinjaStarFrom(GameObject origin, Vector3 shooterOffset) {
		
		// This will a ninja star slightly in front of our origin object.
		// We also have to rotate our model 90 degrees in the x-coordinate.
		Vector3 ninjaStarRotation = origin.transform.rotation.eulerAngles;
		ninjaStarRotation.x = 90.0f;
		Vector3 transformedOffset = origin.transform.rotation * shooterOffset;
		Instantiate(ninjaStar, origin.transform.position + transformedOffset, Quaternion.Euler(ninjaStarRotation));
		
		// Play a sound effect!
		whooshSound.Play();
		
	}
	
}
