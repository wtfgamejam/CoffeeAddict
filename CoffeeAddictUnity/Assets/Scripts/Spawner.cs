using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] obj;
	public float SpawnMin = 1f;
	public float SpawnMax = 2f;
	public int order = 0;

	// Use this for initialization
	void Start () {
		this.Spawn();
	}
	
	public void Spawn()
	{
		if(this.enabled)
		{
			GameObject go = obj[Random.Range(0, obj.Length)];
			GroundController ground = go.GetComponent<GroundController>();
			ground.order = order;
			Instantiate(go, transform.position, Quaternion.identity);

			Invoke("Spawn", Random.Range(this.SpawnMin, this.SpawnMax));
		}
	}
}
