using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 startPosition;
    public int startingScore = 0;
    public Score score;
    public float maxHitPoint = 10;
    public float startinghitPoint;
    public HitPoint hitPoint;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        score.value = startingScore;
        hitPoint.value = startinghitPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoint.value <= float.Epsilon)
        {
            hitPoint.value = maxHitPoint;
            gameObject.transform.position = startPosition;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            gameObject.transform.position = startPosition;
        }
        else if (collision.gameObject.CompareTag("star"))
        {
            score.value += 10;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            score.value -= 3;
        }
    }
}
