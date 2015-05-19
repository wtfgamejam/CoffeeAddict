using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour {

	public void OnPlayClick()
	{
		Application.LoadLevel(1);
	}
}
