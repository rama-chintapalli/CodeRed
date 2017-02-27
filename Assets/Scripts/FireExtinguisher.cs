using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour {
	//private ParticleSystem[] m_Systems;
	public float FireHealth = 500;
	public float MaxFireHealth = 500;
	private float fireDegenerate = 0.1f;

	public float HealthRegen = 5;
	public bool IsOnFire = true;
	// Use this for initialization
	void Start () {
		//m_Systems = GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsOnFire) {
			FireHealth += Time.deltaTime * HealthRegen;    
			if (FireHealth > MaxFireHealth) {
				FireHealth = MaxFireHealth;
			}
		}
	}

	void OnParticleCollision(GameObject other) {   
		Debug.Log ("Inside Fire Collision:");
		ParticleSystem[] m_Systems = other.GetComponentsInChildren<ParticleSystem>();

		foreach (var system in m_Systems)
		{
			var mainModule = system.main;
			if(mainModule.startColor.color == Color.white){
				fireDegenerate = 0.1f;
			}else if(mainModule.startColor.color == Color.red){
				fireDegenerate = 0.5f;
			}else if(mainModule.startColor.color == Color.cyan){
				fireDegenerate = 0.7f;
			}else if(mainModule.startColor.color == Color.yellow){
				fireDegenerate = 0.9f;
			}else if(mainModule.startColor.color == Color.blue){
				fireDegenerate = 1.0f;
			}else if(mainModule.startColor.color == Color.gray){
				fireDegenerate = 10.0f;
			}
		}
		if(IsOnFire) {
			FireHealth -= fireDegenerate;
			Debug.Log ("FireHealth:" + FireHealth);
			if (FireHealth <= 0) {
				IsOnFire = false;
				var emission = transform.GetComponent<ParticleSystem>().emission;
				emission.enabled = false;
				this.GetComponent<GvrAudioSource> ().Stop ();
				// other things to do when fire goes out
			}
		}
	}


	/*public void Extinguish()
	{
		foreach (var system in m_Systems)
		{
			var emission = system.emission;
			emission.enabled = false;
		}
	}*/
}
