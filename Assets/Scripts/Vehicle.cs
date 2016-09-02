using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

    private float speed;
    private float length;

	// Use this for initialization
	void Start () {
        float lifeTime = length / speed;
        Invoke("remove", lifeTime);
	}

    void remove ()
    {
        Destroy(gameObject);
    }

    public void setPath(float speed,float length)
    {
        this.speed = speed;
        this.length=length; 
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.right * speed * Time.deltaTime;
	}
}
