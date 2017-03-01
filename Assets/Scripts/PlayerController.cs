using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public GameObject player;
	public GameObject mainCamera;

	public GameObject firstWayPoint;
	public GameObject secondWayPoint;
	public GameObject thirdWayPoint;
	public GameObject fourthWayPoint;
	public GameObject originWayPoint;
	public Canvas healthCanvas;
	public Canvas extinguisherSelectionCanvas;
	public Canvas instructionsCanvas;

	public Slider healthBarSlider; 
	private bool isGameOver = false;
	public Text gameOverText;

	// Use this for initialization
	void Start () {
		gameOverText.enabled = false;
		healthCanvas.enabled = false;
		extinguisherSelectionCanvas.enabled = false;
		instructionsCanvas.enabled = false;
		healthBarSlider.value = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		// Example: get controller's current orientation:
		Quaternion ori = GvrController.Orientation;


		// If you want a vector that points in the direction of the controller
		// you can just multiply this quat by Vector3.forward:
		Vector3 vector = ori * Vector3.forward;

		Quaternion cameraOrientation =mainCamera.transform.rotation;
		Vector3 cameraOrientationVector = cameraOrientation * Vector3.forward;
		cameraOrientationVector.Normalize ();

		if (healthBarSlider.value > 0) {
			if (GvrController.ClickButtonDown) {
				Rigidbody rigidBodyPlayer = player.GetComponent<Rigidbody> ();
				Vector2 touchPos = GvrController.TouchPos;
				string clickPosition = checkTouchPadClickPosition (touchPos);
				switch (clickPosition) {
				case "TOP":
					//Vector3 moveForward = new Vector3 (0, 0, 1);
					//player.transform.position += moveForward; 
					//rigidBodyPlayer.velocity = moveForward;
					//rigidBodyPlayer.MovePosition(player.transform.position += moveForward);
					//iTween.MoveTo (player, player.transform.position + moveForward, 2f);
					//iTween.MoveTo (player, cameraOrientationVector, 2f);
					//this.transform.Translate(mainCamera.transform.forward, Space.World);
					Vector3 moveForward = mainCamera.transform.forward;
					moveForward.y = 0;

					iTween.MoveTo (player, player.transform.position + moveForward, 2f);
					//iTween.MoveTo (player, vector, 2f);

					//healthBarSlider.value -= .02f;
					break;
				case "RIGHT":
					Vector3 moveRight = mainCamera.transform.right;
					moveRight.y = 0;
					//player.transform.position += moveRight;  
					//rigidBodyPlayer.velocity = moveRight;

					//rigidBodyPlayer.MovePosition(player.transform.position += moveRight);

					iTween.MoveTo (player, player.transform.position + moveRight, 2f);
					//healthBarSlider.value -= .1f;
					break;
				case "BOTTOM":
					Vector3 moveBack = -mainCamera.transform.forward;
					moveBack.y = 0;
					//rigidBodyPlayer.velocity = moveBack;

					//player.transform.position += moveBack;  
					//rigidBodyPlayer.MovePosition(player.transform.position += moveBack);

					iTween.MoveTo (player, player.transform.position + moveBack, 2f);
					//healthBarSlider.value -= .05f;
					break;
				case "LEFT":
					Vector3 moveLeft = -mainCamera.transform.right;
					moveLeft.y = 0;
					//player.transform.position += moveLeft;
					//rigidBodyPlayer.velocity = moveLeft;

					//rigidBodyPlayer.MovePosition(player.transform.position += moveLeft);

					iTween.MoveTo (player, player.transform.position + moveLeft, 2f);
					//healthBarSlider.value -= .08f;
					break;
				default:
					break;
				}
				/*switch (i) {
				case 0:
					iTween.MoveTo (player, firstWayPoint.transform.position, 5f);
					i++;
					healthBarSlider.value -= .02f;
					break;
				case 1:
					iTween.MoveTo (player, secondWayPoint.transform.position, 5f);
					i++;
					healthBarSlider.value -= .1f;
					break;
				case 2:
					iTween.MoveTo (player, thirdWayPoint.transform.position, 5f);
					i++;
					healthBarSlider.value -= .5f;
					break;
				case 3:
					iTween.MoveTo (player, fourthWayPoint.transform.position, 5f);
					i++;
					healthBarSlider.value -= .2f;
					break;
				case 4:
					iTween.MoveTo (player, originWayPoint.transform.position, 5f);
					i = 0;
					break;
				default:
					break;
				}*/

			}
		} else {
			isGameOver = true; 
			gameOverText.enabled = true;
			gameOverText.text = "Got Burned! Try Again. Press AppButton";

		}
		bool isFireActiveNow = isFireActive ();

		if (GvrController.AppButtonDown) {
			if (isGameOver || !isFireActiveNow) {
				ResetScene ();
			} else {
				//rigidBodyPlayer.velocity = Vector3.zero;
			}
		}

		if (!isFireActiveNow && !isGameOver) {
			gameOverText.enabled = true;
			gameOverText.text = "Congratulations! Succesfully Extinguished All Fire. Press AppButton";
			gameOverText.color = Color.green;
		}

	}
	public void ResetScene() 
	{
		// Reset the scene when the user clicks the sign post
		SceneManager.LoadScene("CodeRedMain");
	}

	public void moveToOriginWayPoint() 
	{
		iTween.MoveTo (player, originWayPoint.transform.position, 3f);
		healthCanvas.enabled = true;
		extinguisherSelectionCanvas.enabled = true;
		instructionsCanvas.enabled = true;
		originWayPoint.GetComponent<GvrAudioSource> ().Play ();
	}

	public string checkTouchPadClickPosition(Vector2 touchPos){
		if ((touchPos.x > 0.25 && touchPos.x < 0.75) && (touchPos.y < 0.25)) {
			return "TOP";
		} else if ((touchPos.x > 0.75) && (touchPos.y > 0.25 && touchPos.y < 0.75)) {
			return "RIGHT";
		} else if ((touchPos.x > 0.25 && touchPos.x < 0.75) && (touchPos.y > 0.75)) {
			return "BOTTOM";
		} else if ((touchPos.x < 0.25) && (touchPos.y > 0.25 && touchPos.y < 0.75)) {
			return "LEFT";
		}else if((touchPos.x > 0.25 && touchPos.x < 0.75) &&(touchPos.y > 0.25 && touchPos.y < 0.75)){
			return "CENTER";
		}
		return "";
	}

	void OnCollisionEnter(Collision collision) {
		iTween.Stop ();
		if (collision.collider.tag == "Wall") {
			Rigidbody rigidBodyPlayer = player.GetComponent<Rigidbody> ();
			rigidBodyPlayer.isKinematic = true;
		}
	}
	void OnCollisionExit(Collision collision) {
		if (collision.collider.tag == "Wall") {
			Rigidbody rigidBodyPlayer = player.GetComponent<Rigidbody> ();
			rigidBodyPlayer.isKinematic = false;
		}
	}

	public bool isFireActive(){
		var particleSystems = GameObject.FindGameObjectsWithTag ("Fire");
		foreach (var particleSystem in particleSystems) {
			if (particleSystem.GetComponent<ParticleSystem>().emission.enabled) {
				return true;
			}
		}
		return false;
	}
}
