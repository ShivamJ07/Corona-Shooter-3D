using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour {

	public GameObject floorPrefab;

	public GameObject floorParent;

	public GameObject wallPrefab;

	public GameObject wallsParent;

	public GameObject rocksPrefab;

	public GameObject rocksPrefab2;

	public GameObject treesPrefab;

	public GameObject terrainParent;

	public GameObject characterController;

	public GameObject pickup;

	public int treeObjects;

	public int rockObjects;

	private int treeObjectCounter = 0;

	private int rockObjectCounter = 0;

	private bool rockPlaced = false;

	// Use this for initialization
	void Start () {
		for (int z = 0; z < 75; z++) {
			for (int x = 0; x < 75; x++) {
				CreateChildPrefab(floorPrefab, floorParent, x, 0, z);
				if (z == 0 || z == 74){
					for (int x1 = 0; x1 < 75; x1++) {
						for (int y = 0; y < 5; y++){
						CreateChildPrefab(wallPrefab, wallsParent, x1, y, z);
						}
					}
			 	} else if (x == 0 || x == 74) {
						for (int z1 = 0; z1 < 75; z1++) {
							for (int y = 0; y < 5; y++){
							CreateChildPrefab(wallPrefab, wallsParent, x, y, z1);
							}
						}
					} else {
							if (rockObjectCounter < rockObjects && z > 2 && x > 2){
								if (Random.Range(1, 500) == 1){
									rockPlaced = !rockPlaced;
										if (Random.value < 0.4){
											CreateChildPrefab(rocksPrefab, terrainParent, x, 1, z);
										}
										else{
											CreateChildPrefab(rocksPrefab2, terrainParent, x, 1,z);
										}
										rockObjectCounter = rockObjectCounter + 1;
								}
							}
							if (treeObjectCounter < treeObjects && rockPlaced == false && z > 2 && x > 2) {
									if (Random.Range(1, 100) == 1){
										CreateChildPrefab(treesPrefab, terrainParent, x, 1, z);
										treeObjectCounter = treeObjectCounter + 1;
									}
							}
						}
			}
		}
		characterController.transform.SetPositionAndRotation(
			new Vector3(Random.Range(2, 73), 1, 3), Quaternion.identity
		);
		var rotationVector = transform.rotation.eulerAngles;
   	rotationVector.x = -90;
		var myPickup = Instantiate(pickup, new Vector3(Random.Range(2, 73), 4, 70), Quaternion.Euler(rotationVector));
  } 
		

	// Update is called once per frame
	void Update () {
		
	}

	void CreateChildPrefab(GameObject prefab, GameObject parent, int x, int y, int z) {
		var myPrefab = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
		myPrefab.transform.parent = parent.transform;
	}
}


