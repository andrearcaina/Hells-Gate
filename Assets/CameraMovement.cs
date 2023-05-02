using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float z_offset;
	
	// Update is called once per frame
	void Update () {
		// Set camera position to the players position
		transform.position = new Vector3(player.position.x, player.position.y, player.position.z + z_offset);
	}
}
