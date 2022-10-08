using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDowm : MonoBehaviour
{
    public double interval = 25;
    public static float fallGravity = 0.15f;
    public float damageValue;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.hitPoint.value += damageValue;
        }
        if (!collision.gameObject.CompareTag("enemy"))
        {
            gameObject.SetActive(false);
        }
    }
    void FixedUpdate()
    {
        if (Time.timeAsDouble > interval)
        {
            int n = (int)(Time.timeAsDouble / interval);
            gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0f, -n*fallGravity);
            print(gameObject.GetComponent<Rigidbody2D>().velocity);
        }
    }
}
