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
		transform.position = new Vector3(getPlayer().position.x, getPlayer().position.y, getPlayer().position.z + getZOffset());
	}

	public Transform getPlayer()
	{
		return player;
	}

	public float getZOffset()
	{
		return z_offset;
	}
}
