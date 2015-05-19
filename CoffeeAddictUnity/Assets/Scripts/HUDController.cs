using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUDController : MonoBehaviour {

	public static int MAX_METER = 100;
	public static int METER_FILL = 10;
	public static int METER_DECREMENT = 1;
	public static float METER_SPEED = 0.1f;

	public Text ScoreField;
	public Text MeterField;
	public EndGameDialog EndGame;
	public MeterController MeterBar;

	public int ScoreIncrement = 1;
	public int Score = 0;
	public int Meter = 0;

	public bool Dead = false;
	
	// Use this for initialization
	void Start () {
		Score = 0;
		UpdateScore();

		Meter = MAX_METER;
		UpdateMeter();

		EndGame.gameObject.SetActive(false);

		StartCoroutine(ScoreTick());
		StartCoroutine(MeterTick());
	}

	private void UpdateScore()
	{
		ScoreField.text = Score.ToString();
	}

	private void UpdateMeter()
	{
		//MeterField.text = Meter.ToString();
		MeterBar.MoveMeter(Meter);
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

	private IEnumerator MeterTick () 
	{
		if(!Dead && Meter > 0)
		{
			Meter -= METER_DECREMENT;
			
			yield return new WaitForSeconds(METER_SPEED);
			
			this.UpdateMeter();
			
			StartCoroutine(MeterTick());
		}
	}

	public void AddScore(int value)
	{
		Debug.Log("Score! "+value);
		Score += value;
		Meter += METER_FILL;
		if(Meter > MAX_METER) Meter = MAX_METER;
		this.UpdateMeter();
		this.UpdateScore();
	}


	public void OnDeath()
	{
		Dead = true;
		//ScoreField.enabled = false;
		//MeterField.enabled = false;
		MeterBar.gameObject.SetActive(false);

		List<string> highscores = DataUtils.AddScoreToPlayerStats(Score);

		EndGame.AddScores(highscores, Score.ToString());
		EndGame.gameObject.SetActive(true);
	}

	public void OnPlayAgain()
	{
		Application.LoadLevel(0);
	}
}
