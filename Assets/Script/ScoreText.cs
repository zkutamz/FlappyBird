using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    Text score;
    void Start()
	{
		score = GetComponent<Text>();
		score.text = PlayerPrefs.GetInt("Score").ToString();
	}
	void Update()
	{
		score = GetComponent<Text>();
		score.text = PlayerPrefs.GetInt("Score").ToString();
	}
}
