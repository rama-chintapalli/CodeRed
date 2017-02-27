using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanelController : MonoBehaviour {
	public GameObject menuPanel;

	public GameObject player;

	// Use this for initialization
	void Start () {
		menuPanel.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GvrController.AppButtonDown) {
			// Do something.
			// TouchDown is true for 1 frame after touchpad is touched.
			Debug.Log("MenuPanelController : App Button Down" +menuPanel.activeSelf );
			/*menuPanel.transform.position = player.transform.position; 
			menuPanel.transform.rotation = player.transform.rotation; 
			menuPanel.transform.Translate(0.0f, 0.0f, 0.6f); // move away from the camera 
			menuPanel.transform.LookAt(player.transform.position);*/
		

			//menuPanel.SetActive (!menuPanel.activeSelf);

		}
	}
}
