using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public PlatformerCharacter2D player;
	
	// Update is called once per frame
	void Update () 
	{
		if(player.Dead)
		{
			this.StopAllSpawners();
		}
	}

	private void StopAllSpawners()
	{
		foreach (Transform child in transform) {
			child.GetComponent<Spawner>().enabled = false;
		}
	}

	private void StartAllSpawners()
	{
		foreach (Transform child in transform) {
			child.GetComponent<Spawner>().enabled = true;
		}
	}
}
