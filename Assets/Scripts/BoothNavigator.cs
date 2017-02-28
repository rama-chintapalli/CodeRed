using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothNavigator : MonoBehaviour {
	public GameObject navigator;

	public GameObject mainInformationBooth;
	public GameObject informationBooth1;
	public GameObject informationBooth2;
	public GameObject informationBooth3;
	public GameObject informationBooth4;
	public GameObject informationBooth5;



	private GameObject currentInformationBooth;
	int i =0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(){
		switch (i) {
		case 0:
			iTween.MoveTo (navigator, 
				iTween.Hash (
					"position", informationBooth1.transform.position, 
					"time", 4, 
					"easetype", "linear",
					"oncomplete", "finishingFlourish", 
					"oncompletetarget", this.gameObject
				)
			);
			i++;
			mainInformationBooth.GetComponent<GvrAudioSource> ().Stop ();
			informationBooth1.GetComponent<GvrAudioSource> ().Play();
			break;
		case 1:
			iTween.MoveTo (navigator, 
				iTween.Hash (
					"position", informationBooth2.transform.position, 
					"time", 4, 
					"easetype", "linear",
					"oncomplete", "finishingFlourish", 
					"oncompletetarget", this.gameObject
				)
			);
			i++;
			informationBooth1.GetComponent<GvrAudioSource> ().Stop ();
			informationBooth2.GetComponent<GvrAudioSource> ().Play();
			break;
		case 2:
			iTween.MoveTo (navigator, 
				iTween.Hash (
					"position", informationBooth3.transform.position, 
					"time", 4, 
					"easetype", "linear",
					"oncomplete", "finishingFlourish", 
					"oncompletetarget", this.gameObject
				)
			);
			i++;
			informationBooth2.GetComponent<GvrAudioSource> ().Stop ();
			informationBooth3.GetComponent<GvrAudioSource> ().Play();
			break;
		case 3:
			iTween.MoveTo (navigator, 
				iTween.Hash (
					"position", informationBooth4.transform.position, 
					"time", 4, 
					"easetype", "linear",
					"oncomplete", "finishingFlourish", 
					"oncompletetarget", this.gameObject
				)
			);
			i++;
			informationBooth3.GetComponent<GvrAudioSource> ().Stop ();
			informationBooth4.GetComponent<GvrAudioSource> ().Play();
			break;
		case 4:
			iTween.MoveTo (navigator, 
				iTween.Hash (
					"position", informationBooth5.transform.position, 
					"time", 4, 
					"easetype", "linear",
					"oncomplete", "finishingFlourish", 
					"oncompletetarget", this.gameObject
				)
			);
			i++;
			informationBooth4.GetComponent<GvrAudioSource> ().Stop ();
			informationBooth5.GetComponent<GvrAudioSource> ().Play();
			break;
		default:
			iTween.MoveTo (navigator, 
				iTween.Hash (
					"position", mainInformationBooth.transform.position, 
					"time", 6, 
					"easetype", "easeOutSine",
					"oncomplete", "finishingFlourish", 
					"oncompletetarget", this.gameObject
				)
			);
			i = 0;
			informationBooth5.GetComponent<GvrAudioSource> ().Stop ();
			mainInformationBooth.GetComponent<GvrAudioSource> ().Play();
			break;
		};


	}
}
