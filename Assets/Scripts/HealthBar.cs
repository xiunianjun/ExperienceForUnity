using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    float maxHitPoint;
    public HitPoint hitPoint;
    public Player character;
    public Image meterImage;
    public Text hpText;
    void Start()
    {
        maxHitPoint = character.maxHitPoint;
    }
    void Update()
    {
        if (character!=null)
        {
            meterImage.fillAmount = hitPoint.value / maxHitPoint;
            hpText.text = (meterImage.fillAmount * 100).ToString();
        }
    }
}
