using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform generationPoint;
	public float distance;

	public float distanceMin;
	public float distanceMax;

	private float platformWidth;

	// Use this for initialization
	void Start () {
		platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x) {
			distance = Random.Range (distanceMin, distanceMax);
			
			transform.position = new Vector3(transform.position.x + platformWidth + distance, transform.position.y, transform.position.z);
			
			Instantiate (platform, transform.position, transform.rotation);
		}
	}
}
