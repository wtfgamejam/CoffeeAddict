using UnityEngine;
using System.Collections;

public class CameraRunnerController : MonoBehaviour {

	public Transform player;
	
	// Update is called once per frame
	void Update () {
	
		this.transform.position = new Vector3(player.position.x + 6, 0, -10f);
	}
}
