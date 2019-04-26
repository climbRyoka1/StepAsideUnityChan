using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
	
	public GameObject carPrefab;
	public GameObject coinPrefab;
	public GameObject conePrefab;

	private GameObject unityChan;

	private float posRange = 3.4f;
	private float run;
	private float elapsedTime;


	// Use this for initialization
	void Start () {
		this.unityChan = GameObject.Find ("unitychan");
	}

	void Update () {
		this.run = this.unityChan.transform.position.z;
		if (-210.0f < run && run < 70.0f) {
			this.elapsedTime += Time.deltaTime;
			if (elapsedTime > 1.0f) {
				elapsedTime = 0;
				appear ();
			}
		}
	}

	void appear(){
			int num = Random.Range (1, 11);
			if (num <= 2) {
				for (float j = -1; j <= 1; j += 0.4f) {
				GameObject cone = Instantiate (conePrefab) as GameObject;
				cone.transform.position = new Vector3 (4 * j, cone.transform.position.y,run + 50 );
				}
			} else {
				for (int j = -1; j <= 1; j++) { 
					int item = Random.Range (1, 11);
					int offsetZ = Random.Range (-5, 6);
				    if (1 <= item && item <= 6){
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, run + 50 + offsetZ);
					} else if (7 <= item && item <= 9) {
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, run + 50 + offsetZ);
					}
				}
			}
		}
	}	
