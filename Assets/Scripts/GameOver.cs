using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    private Player player;
    public float UIDistance=5f;
    public float UIHeight = 2f;

	// Use this for initialization
	void Start () {

        player = GameObject.FindObjectOfType<Player>();
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.rotation = Quaternion.LookRotation(player.lookDirection());
        transform.position = player.transform.position;
        transform.position += player.lookDirection() *UIDistance;
        transform.position += Vector3.up * UIHeight;
	}
}
