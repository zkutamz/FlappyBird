using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Medal : MonoBehaviour
{
    public Sprite bronze;
    public Sprite sliver;
    public Sprite gold;
    public Sprite plastic;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        int best = PlayerPrefs.GetInt("HighScore");
        Image medal = GetComponent<Image>();
        if (score > best + best * 0.2)
            medal.sprite = plastic;
        else if (score >= best)
            medal.sprite = gold;
        else if (score >= best * 0.5)
            medal.sprite = sliver;
        else if (score >= best * 0.2)
            medal.sprite = bronze;
        else
            medal.sprite = null;
    }
}
