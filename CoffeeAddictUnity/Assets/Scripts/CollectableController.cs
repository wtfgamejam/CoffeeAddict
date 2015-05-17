using UnityEngine;
using System.Collections;

public class CollectableController : MonoBehaviour {

	public ParticleSystem particle;

	private SpriteRenderer rend;
	private AudioSource audio;

	void Awake()
	{
		this.rend = this.GetComponent<SpriteRenderer>();
		this.audio = this.GetComponent<AudioSource>();
	}

	void Update()
	{
		transform.Rotate(0f, 0f, 6f * 10f * Time.deltaTime);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			PlatformerCharacter2D player = other.gameObject.GetComponent<PlatformerCharacter2D>();
			if(player != null)
			{
				this.audio.Play();

				this.rend.color = new Color(0f,0f,0f,0f);
				
				if(particle != null)
				{
					particle.Play();
				}

				player.ScoreCollectable();
			}
		}
	}

}
