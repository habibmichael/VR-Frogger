using UnityEngine;
using System.Collections;

public class FireWall : MonoBehaviour {

    public float creepSpeed = 0.01f;
    private Player player;
    private LevelState state;


	// Use this for initialization
	void Start () {

        player = GameObject.FindObjectOfType<Player>();
        state = GameObject.FindObjectOfType<LevelState>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!state.isGameOver)
        {
            followPlayer();
            creepForward();
            checkFrogBurnt();
        }
	
	}

    void followPlayer ()
    {
        Vector3 delta = player.transform.position - transform.position;
        Vector3 projectedDelta = Vector3.Project(delta, Vector3.left);
        transform.position += projectedDelta;
    }

    void creepForward ()
    {
        transform.position += Vector3.forward * creepSpeed * Time.deltaTime;
    }

    void checkFrogBurnt ()
    {
        if (player.transform.position.z < transform.position.z)
        {
            state.isGameOver = true;
        }
    }
}
