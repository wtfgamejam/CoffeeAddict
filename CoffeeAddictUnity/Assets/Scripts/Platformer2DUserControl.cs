﻿using UnityEngine;

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
		if(Input.GetButtonDown("Jump"))
		{
			Debug.Log("Jump");
		}

        if(!jump)
		{
            // Read the jump input in Update so button presses aren't missed.
			jump = Input.GetButtonDown("Jump");
		}
    }

    private void FixedUpdate()
    {
        // Read the inputs.
        //bool crouch = Input.GetKey(KeyCode.LeftControl);
		//float h = Input.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        character.Move(1, false, jump);
        jump = false;
    }
}