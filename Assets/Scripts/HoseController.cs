using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;
using UnityEngine.SceneManagement;

public class HoseController : MonoBehaviour {
	private ParticleSystem[] m_Systems;
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
		this.transform.localRotation = ori;

		// Example: check if touchpad was just touched
		if (GvrController.ClickButtonDown) {
			// Do something.
			// TouchDown is true for 1 frame after touchpad is touched.
			Debug.Log("Click Button Down");
			StartHoseMaterial ();
			this.GetComponent<GvrAudioSource> ().Play ();

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
		//resetScene ();

		foreach (var system in m_Systems)
		{
			var mainModule = system.main;
			if(materialName.Equals("waterfoam")){
				mainModule.startColor = Color.white;
			}else if(materialName.Equals("carbondioxide")){
				mainModule.startColor = Color.red;
			}else if(materialName.Equals("drychemical")){
				mainModule.startColor = Color.cyan;
			}else if(materialName.Equals("drypowder")){
				mainModule.startColor = Color.yellow;
			}else if(materialName.Equals("wetchemical")){
				mainModule.startColor = Color.blue;
			}else if(materialName.Equals("watermist")){
				mainModule.startColor = Color.gray;
			}

		}
	}

	private void resetScene(){
		SceneManager.LoadScene ("CodeRedMain");
	}
}
