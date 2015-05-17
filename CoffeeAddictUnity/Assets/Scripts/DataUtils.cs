using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;


/*
 * { "highscores": {1004,53,10,2} //highscores returns a list of values
 */

public class DataUtils
{

	/// <summary>
	/// Adds the score to players highscores. Up to 10 highscors.
	/// </summary>
	/// <param name="score">Score.</param>
	public static void AddScoreToPlayerStats(int score)
	{
		string data = PlayerPrefs.GetString("highscores");
		List<string> highscores = new List<string>(data.Split(','));
		List<string> newHighscores = new List<string>();

		if(highscores != null)
		{
			//loop through scores and insert at correct place
			foreach(string s in highscores)
			{
				if(newHighscores.Count <= 10)
				{
					if(score > int.Parse(s))
					{
						newHighscores.Add(score.ToString());
						newHighscores.Add(s);
					}
					else
					{
						newHighscores.Add(s);
						newHighscores.Add(score.ToString());
					}
				}
			}

			string newData = newHighscores.ToString();
			PlayerPrefs.SetString("highscores",newData);

		}

	}
}
