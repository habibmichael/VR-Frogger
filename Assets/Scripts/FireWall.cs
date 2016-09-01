using UnityEngine;
using System.Collections;

public class FireWall : MonoBehaviour {

    public float creepSpeed = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        followPlayer();
        creepForward();
	
	}

    void followPlayer ()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 delta = player.transform.position - transform.position;
        Vector3 projectedDelta = Vector3.Project(delta, Vector3.left);
        transform.position += projectedDelta;
    }

    void creepForward ()
    {
        transform.position += Vector3.forward * creepSpeed * Time.deltaTime;
    }
}
