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
	public static List<string> AddScoreToPlayerStats(int score)
	{
		List<string> newHighscores = new List<string>();

		//PlayerPrefs.SetString("highscores","");

		string data = PlayerPrefs.GetString("highscores");

		if(data == null || data == "")
		{
			newHighscores.Add(score.ToString());
		}
		else
		{
			List<string> highscores = new List<string>(data.Split(','));

			if(highscores != null)
			{
				int index = 0;
				int pos = 0;
				bool scoreAdded = false;
				//loop through scores and insert at correct place
				//for(int i = 0; i < hs.Length; i++)
				foreach(string s in highscores)
				{

					if(score < int.Parse(s))
					{
						pos = index + 1;
					}

					if(newHighscores.Count < 10)
					{
						newHighscores.Add(s);
					}

					index++;

				}

				if(pos < 10)
				{
					newHighscores.Insert(pos, score.ToString());
				}
	
			}
		}

		string newData = string.Join(",", newHighscores.ToArray());
		Debug.Log(newData);
		PlayerPrefs.SetString("highscores",newData);

		return newHighscores;
	}
}
