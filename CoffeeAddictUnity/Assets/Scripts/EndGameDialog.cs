using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndGameDialog : MonoBehaviour {

	public GameObject ScoreTextPrefab;
	public Transform HighScoreParent;

	// Use this for initialization
	void Start () {
		ScoreTextPrefab.SetActive(false);
	}
	
	public void AddScores(List<string> highscores, string currentScore)
	{
		Debug.Log(highscores.ToString());

		for(int i = 0; i < highscores.Count; i++)
		{
			GameObject score = Instantiate(ScoreTextPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			Text scoreText = score.GetComponent<Text>();
			scoreText.text = highscores[i];

			if(scoreText.text == currentScore)
			{
				scoreText.fontStyle = FontStyle.Bold;
				scoreText.color = Color.yellow;
			}

			score.transform.SetParent(HighScoreParent);

			score.GetComponent<RectTransform>().localScale = Vector3.one;

		}

	}
}
