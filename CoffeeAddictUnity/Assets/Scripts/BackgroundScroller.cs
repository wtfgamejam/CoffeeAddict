using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {
	
	public Renderer rend;

	private float pos = 0;

	public void UpdateBackground(float speed)
	{
		this.pos += speed;

		if(this.pos > 1.0f)
		{
			this.pos -= 1.0f; 
		}

		if(rend != null)
		{
			rend.material.mainTextureOffset = new Vector2 (this.pos, 0);
		}
	}
}
