using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HoseController : MonoBehaviour {
	private ParticleSystem[] m_Systems;
	public Text currentExtinguisher;
	// Use this for initialization
	void Start () {
		m_Systems = GetComponentsInChildren<ParticleSystem>();
		StopHoseMaterial ();
	}
	
	// Update is called once per frame
	void Update () {
		// Example: get controller's current orientation:
		Quaternion ori = GvrController.Orientation;

		// If you want a vector that points in the direction of the controller
		// you can just multiply this quat by Vector3.forward:
		Vector3 vector = ori * Vector3.forward;

		// ...or you can just change the rotation of some entity on your scene
		// (e.g. the player's arm) to match the controller's orientation
		this.transform.rotation = ori;

		// Example: check if touchpad was just touched
		if (GvrController.ClickButtonDown) {
			// Do something.
			// TouchDown is true for 1 frame after touchpad is touched.
			Vector2 touchPos = GvrController.TouchPos;
			string clickPosition = checkTouchPadClickPosition (touchPos);
			if (clickPosition.Equals ("CENTER")) {
				StartHoseMaterial ();
				this.GetComponent<GvrAudioSource> ().Play ();
			}
			Debug.Log("Click Button Down");

		}
		if (GvrController.ClickButtonUp) {
			// Do something.
			// TouchDown is true for 1 frame after touchpad is touched.
			Debug.Log("Click Button Down");
			StopHoseMaterial ();
			this.GetComponent<GvrAudioSource> ().Stop ();
		}

		// Example: check if app button was just released.
		if (GvrController.AppButtonDown) {
			// Do something.
			// AppButtonUp is true for 1 frame after touchpad is touched.
		}

		// Example: check the position of the user's finger on the touchpad
		if (GvrController.IsTouching) {
			Vector2 touchPos = GvrController.TouchPos;
			// Do something.
		}
	}

	public void StartHoseMaterial()
	{
		foreach (var system in m_Systems)
		{
			var emission = system.emission;
			emission.enabled = true;
		}
	}
	public void StopHoseMaterial()
	{
		foreach (var system in m_Systems)
		{
			var emission = system.emission;
			emission.enabled = false;
		}
	}

	public void SelectHoseMaterial(string materialName)
	{
		foreach (var system in m_Systems)
		{
			var mainModule = system.main;
			if(materialName.Equals("waterfoam")){
				mainModule.startColor = Color.white;
				currentExtinguisher.text = "Water Foam";
			}else if(materialName.Equals("carbondioxide")){
				mainModule.startColor = Color.red;
				currentExtinguisher.text = "Carbon Dioxide";
			}else if(materialName.Equals("drychemical")){
				mainModule.startColor = Color.cyan;
				currentExtinguisher.text = "Dry Chemical";
			}else if(materialName.Equals("drypowder")){
				mainModule.startColor = Color.yellow;
				currentExtinguisher.text = "Dry Powder";
			}else if(materialName.Equals("wetchemical")){
				mainModule.startColor = Color.blue;
				currentExtinguisher.text = "Wet Chemical";
			}else if(materialName.Equals("watermist")){
				mainModule.startColor = Color.gray;
				currentExtinguisher.text = "Water Mist";
			}

		}
	}

	private void resetScene(){
		SceneManager.LoadScene ("CodeRedMain");
	}
	public string checkTouchPadClickPosition(Vector2 touchPos){
		if ((touchPos.x > 0.4 && touchPos.x < 0.6) && (touchPos.y < 0.1)) {
			return "TOP";
		} else if ((touchPos.x > 0.9) && (touchPos.y > 0.4 && touchPos.y < 0.6)) {
			return "RIGHT";
		} else if ((touchPos.x > 0.4 && touchPos.x < 0.6) && (touchPos.y > 0.9)) {
			return "BOTTOM";
		} else if ((touchPos.x < 0.1) && (touchPos.y > 0.4 && touchPos.y < 0.6)) {
			return "LEFT";
		}else if((touchPos.x > 0.4 && touchPos.x < 0.6) &&(touchPos.y > 0.4 && touchPos.y < 0.6)){
			return "CENTER";
		}
		return "TOP";
	}
}
