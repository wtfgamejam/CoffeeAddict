using UnityEngine;
using System.Collections;

[System.Serializable]
public class Platforms
{
	public PlatformType type;
	public Platform platform;
}

public class PlatformGenerator : MonoBehaviour {

	public GameObject SpawnMarker;
	public GameObject DestroyMarker;
	public Platforms[] Platforms;

	public Platform currentPlatform;

	// Use this for initialization
	void Start () {
		CreatePlatformPiece(PlatformType.PLATFORM_1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CreatePlatformPiece(PlatformType type)
	{
		//Instantiate(this.GetPlatform(PlatformType.PLATFORM_1),SpawnMarker.transform, Quaternion.identity);
	}

	private Platform GetPlatform(PlatformType type)
	{
		return this.Platforms[(int)type].platform;
	}
}
