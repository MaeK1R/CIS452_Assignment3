using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Be sure to assign this a value in the designer.
    public Text ScoreText;

    private float timer;
    private int score;

    void Update()
    {

        timer += Time.deltaTime;

        if (timer > 1f)
        {

            score += 1;

            //We only need to update the text if the score changed.
            ScoreText.text = ("Time: " + score.ToString() + "s");

            //Reset the timer to 0.
            timer = 0;
        }
    }
}

