using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public Text ScoreField;

	public int ScoreIncrement = 1;
	public int Score = 0;

	public bool Dead = false;
	
	// Use this for initialization
	void Start () {
		Score = 0;

		StartCoroutine(ScoreTick());
	}

	private void UpdateScore()
	{
		ScoreField.text = Score.ToString();
	}

	private IEnumerator ScoreTick () 
	{
		if(!Dead)
		{
			Score += ScoreIncrement;

			yield return new WaitForSeconds(1f);

			this.UpdateScore();

			StartCoroutine(ScoreTick());
		}
	}

	public void AddScore(int value)
	{
		Debug.Log("Score! "+value);
		Score += value;
		this.UpdateScore();
	}
}
