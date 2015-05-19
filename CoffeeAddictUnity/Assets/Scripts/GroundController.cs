using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

	public GameObject Collectable;

	public GameObject CollectableLocation;

	public int CollectableChance = 1;

	public SpriteRenderer rend;

	public Material[] materials;

	public int order = 0;

	// Use this for initialization
	void Awake () {
		int chance = Random.Range(1,CollectableChance+1);
		float collectableOffsetX = Random.Range(-2f,2f);
		if(chance == CollectableChance)
		{
			Vector3 position = CollectableLocation.transform.position;
			position = new Vector3(position.x + collectableOffsetX, position.y, position.z);
			GameObject collect = Instantiate(Collectable, position, Quaternion.identity) as GameObject;
			collect.transform.parent = CollectableLocation.transform;
		}

		int matChance = Random.Range(0, materials.Length);
		rend.material = materials[matChance];
		rend.sortingOrder = order;
	}

}
