 using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] lanes;
    public float spawnHorizon = 500f;
    public float laneWidth = 2f;
    private float nextLaneOffset = 0f;
    public GameObject player;
    public Transform spawnParent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float fowardPosition = player.transform.position.z;

        while (fowardPosition+spawnHorizon>nextLaneOffset) {
            int randomLaneIndex = Random.Range(0, lanes.Length);
            GameObject lane = lanes[randomLaneIndex];
            Vector3 nextLanePosition = nextLaneOffset * Vector3.forward;
           GameObject newLane=  Instantiate(lane, nextLanePosition, Quaternion.identity) as GameObject;
            newLane.transform.parent = spawnParent;
            nextLaneOffset += laneWidth;
        }

    }

   
}
