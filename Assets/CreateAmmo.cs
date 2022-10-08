using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAmmo : MonoBehaviour
{
    public bool isEnemy;
    public GameObject ammoPrefab;
    static List<GameObject> ammoPool;
    public int poolSize;
    public Player player;
    public float interval = 1.7f;
    GameObject cier;
    void Awake()
    {
        if (ammoPool==null)
        {
            ammoPool = new List<GameObject>();
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ammoObject = Instantiate(ammoPrefab);
            ammoObject.SetActive(false);
            ammoPool.Add(ammoObject);
        }
    }
    GameObject SpawnAmmo(Vector2 position)
    {
        foreach (var ammo in ammoPool)
        {
            if (ammo.activeSelf == false)
            {
                ammo.transform.position = position;
                ammo.SetActive(true);
                return ammo;
            }
        }
        return null;
    }
    public IEnumerator CreateAmmos()
    {
        while (true)
       {
            Vector2 position;
            if (player==null||!isEnemy)
            {
                float x = Random.Range(-8, 7.4f);
                position = new Vector2(x, 3.7f);
            }
            else
            {
                position = new Vector2(player.transform.position.x, 3.7f);
            }
            cier = SpawnAmmo(position);
            yield return new WaitForSeconds(interval);
        }
    }
    public IEnumerator AddSpeed()
    {
        yield return new WaitForSeconds(5);
        if (cier!=null)
        {
            Rigidbody2D rb2d = cier.GetComponent<Rigidbody2D>();
            rb2d.velocity += new Vector2(0f, -1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateAmmos());
    }

    // Update is called once per frame
    void Update()
    {
        ////float x = Random.Range(-8, 7.4f);
        //Vector2 position = new Vector2(player.transform.position.x, 2f);
        //SpawnAmmo(position);
    }
}
