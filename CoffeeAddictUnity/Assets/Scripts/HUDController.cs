using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public Text ScoreField;
	public EndGameDialog EndGame;

	public int ScoreIncrement = 1;
	public int Score = 0;

	public bool Dead = false;
	
	// Use this for initialization
	void Start () {
		Score = 0;
		EndGame.gameObject.SetActive(false);
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


	public void OnDeath()
	{
		Dead = true;
		ScoreField.enabled = false;

		EndGame.gameObject.SetActive(true);

	}

	public void OnPlayAgain()
	{
		Application.LoadLevel(0);
	}
}
