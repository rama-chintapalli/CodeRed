using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public GameObject player;

	public GameObject firstWayPoint;
	public GameObject secondWayPoint;
	public GameObject thirdWayPoint;
	public GameObject fourthWayPoint;
	public GameObject originWayPoint;

	int i=0;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		if (GvrController.AppButtonDown) {
			switch (i){
			case 0:
				iTween.MoveTo (player, firstWayPoint.transform.position, 5f);
				i++;
				break;
			case 1:
				iTween.MoveTo(player, secondWayPoint.transform.position, 5f);
				i++;
				break;
			case 2:
				iTween.MoveTo(player, thirdWayPoint.transform.position, 5f);
				i++;
				break;
			case 3:
				iTween.MoveTo (player, fourthWayPoint.transform.position, 5f);
				i++;
				break;
			case 4:
				iTween.MoveTo (player, originWayPoint.transform.position, 5f);
				i = 0;
				break;
			default:
				break;
			}

		}
	}
	public void ResetScene() 
	{
		// Reset the scene when the user clicks the sign post
		SceneManager.LoadScene("CodeRedMain");
	}
}
