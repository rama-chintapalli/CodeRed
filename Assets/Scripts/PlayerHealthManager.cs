using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {
	public Slider healthBarSlider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var particleSystems = GameObject.FindGameObjectsWithTag ("Fire");
		foreach (var particleSystem in particleSystems) {
			float distance = Vector3.Distance(this.transform.position,particleSystem.transform.position);
			if (distance < 0.5f) {
				healthBarSlider.value -= 0.003f;
			} else if(distance < 1.0f) {
				healthBarSlider.value -= 0.001f;
			} else if(distance < 1.5f) {
				healthBarSlider.value -= 0.0005f;
			}
		}
	}
}
