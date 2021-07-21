using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScoreText : MonoBehaviour
{
    public Text hightScore;
    // Start is called before the first frame update
    void Start()
    {
        hightScore = GetComponent<Text>();
        hightScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        Debug.Log(PlayerPrefs.GetInt("HighScore").ToString());
    }
}
