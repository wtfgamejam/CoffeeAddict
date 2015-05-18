using UnityEngine;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
    private PlatformerCharacter2D character;
    private bool jump;

    private void Awake()
    {
        character = GetComponent<PlatformerCharacter2D>();
    }

    private void Update()
    {
        if(!jump)
		{
            // Read the jump input in Update so button presses aren't missed.
			jump = Input.GetButtonDown("Jump");

			if (Input.GetMouseButtonDown(0))
			{                
				var touchArea= new Rect(Screen.width/2, 0, Screen.width/2, Screen.height);
				if (touchArea.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
				{
					jump = true;
				}
			}
		}
    }

    private void FixedUpdate()
    {
		if(!character.Dead)
		{
	        character.Move(1, false, jump);
	        jump = false;
		}
    }
}