using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private CardboardHead head;
    private Rigidbody rb;

    public float jumpSpeed;
    public float jumpAngleInDegrees;

    //prevents flying effect
    private bool onGround;

    //fixes collision jump bug
    private float lastJumpRequestTime;

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
        requestJump();

    }

    private void Jump ()
    {
       
            float jumpAngleInRadians = jumpAngleInDegrees * Mathf.Deg2Rad;
            Vector3 projectedVector = Vector3.ProjectOnPlane(head.Gaze.direction, Vector3.up);
            Vector3 jumpVector = Vector3.RotateTowards(projectedVector, Vector3.up, jumpAngleInRadians, 0);
            rb.velocity = jumpVector * jumpSpeed;
        
    }

    private void requestJump ()
    {
        lastJumpRequestTime = Time.time;
        rb.WakeUp();
    }

    void OnCollisionStay(Collision Collision )
    {
        float delta = Time.time - lastJumpRequestTime;
        if (delta < 0.1)
        {
            Jump();
            lastJumpRequestTime = 0.0f;
        }
    }
}
