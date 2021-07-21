using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class New : MonoBehaviour
{
	void Start()
	{
		int score = PlayerPrefs.GetInt("Score");
		int best = PlayerPrefs.GetInt("HighScore");
		Image newImage = GetComponent<Image>();
		if (score < best)
			newImage.enabled = false;
		else
			newImage.enabled = true;
	}
	void Update()
	{
		int score = PlayerPrefs.GetInt("Score");
		int best = PlayerPrefs.GetInt("HighScore");
		Image newImage = GetComponent<Image>();
		if (score < best)
			newImage.enabled = false;
		else
			newImage.enabled = true;
	}
}