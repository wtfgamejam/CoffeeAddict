using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{

			PlatformerCharacter2D player = other.gameObject.GetComponent<PlatformerCharacter2D>();
			if(player != null && !player.Dead)
			{
				player.Death();
			}
			return;
		}
	}
}
