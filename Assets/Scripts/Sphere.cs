﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {
	public GameObject currentInformationBooth;
	public GameObject nextInformationBooth;
	float rotationsPerMinute = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,6.0f*rotationsPerMinute*Time.deltaTime,0);

	}

}
