using UnityEngine;
using System.Collections;

public class LethalCollider : MonoBehaviour {

	void OnCollisionEnter(Collision collision )
    {
        LevelState state = FindObjectOfType<LevelState>();
        Player player = FindObjectOfType<Player>();
        if (collision.collider == player.GetComponent<CapsuleCollider>())
        {
            state.isGameOver = true;
        }

        
    }
}
