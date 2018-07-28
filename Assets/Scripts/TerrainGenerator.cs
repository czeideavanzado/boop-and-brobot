using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

	public GameObject terrain;
	public Transform generationPoint;
	public float distance;

	public float distanceMin;
	public float distanceMax;

	private float terrainWidth;

	// public GameObject[] terrainArray;
	private int terrainSelector;
	private float[] terrainWidths;

	public ObjectPooler[] objectPools;

	// Use this for initialization
	void Start () {
		// terrainWidth = terrain.GetComponent<BoxCollider2D>().size.x;
		terrainWidths = new float[objectPools.Length];

		for(int i = 0; i < objectPools.Length; i++) {
			terrainWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x) {
			distance = Random.Range (distanceMin, distanceMax);
			
			terrainSelector = Random.Range(0, objectPools.Length);
			
			transform.position = new Vector3(transform.position.x + (terrainWidths[terrainSelector] / 2) + distance, transform.position.y, transform.position.z);

			// Instantiate (terrainArray[terrainSelector], transform.position, transform.rotation);
			GameObject newTerrain = objectPools[terrainSelector].GetPooledObject();

			newTerrain.transform.position = transform.position;
			newTerrain.transform.rotation = transform.rotation;
			newTerrain.SetActive(true);

			transform.position = new Vector3(transform.position.x + (terrainWidths[terrainSelector] / 2), transform.position.y, transform.position.z);
		}
	}
}
