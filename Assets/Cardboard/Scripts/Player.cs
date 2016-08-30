using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private CardboardHead head;
    public Text gazeText;
    private Rigidbody rb;

    public float jumpSpeed;
    public float jumpAngleInDegrees;

    //prevents flying effect
    private bool onGround;

	// Use this for initialization
	void Start () {
        
        //add handler for trigger events
        Cardboard.SDK.OnTrigger += PullTrigger;

        head = FindObjectOfType<CardboardHead>();
        rb = GetComponent<Rigidbody>();
	}

    void OnCollisionEnter(Collision collision )
    {
        onGround = true;
    }

    void OnCollisionExit(Collision collision )
    {
        onGround = false;
    }

    private void PullTrigger ()
    {
        //Allows character to jump with each trigger pull
        //Add natural jumping

        if (onGround)
        {
            float jumpAngleInRadians = jumpAngleInDegrees * Mathf.Deg2Rad;
            Vector3 projectedVector = Vector3.ProjectOnPlane(head.Gaze.direction, Vector3.up);
            Vector3 jumpVector = Vector3.RotateTowards(projectedVector, Vector3.up, jumpAngleInRadians, 0);
            rb.velocity = jumpVector * jumpSpeed;
        }
            }

    // Update is called once per frame
    void Update () {

        gazeText.text = head.Gaze.ToString();
	}
}
