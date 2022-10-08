using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Score score;
    public Text hpText;
    void Update()
    {
        hpText.text = score.value.ToString();
    }
}
