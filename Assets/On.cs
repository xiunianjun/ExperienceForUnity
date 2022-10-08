using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On : MonoBehaviour
{
    public float speed = 3;
    Rigidbody2D rb2d;
    Vector2 startingLocation;
    public float damageValue;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startingLocation = gameObject.transform.position;
        StartCoroutine(Come());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Come()
    {
        while (true)
        {
            rb2d.velocity = new Vector2(speed, 0f);
            yield return new WaitForSeconds(10);
            rb2d.velocity = new Vector2(0f, 0f);
            gameObject.transform.position = startingLocation;
        }
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.GetComponent<Player>().hitPoint.value += damageValue;
        }
    }
}
