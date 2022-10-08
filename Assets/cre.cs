using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cre : MonoBehaviour
{
    public bool isEnemy;
    public GameObject ammoPrefab;
    static List<GameObject> ammoPool;
    public int poolSize;
    public Player player;
    public float interval = 1.7f;
    void Awake()
    {
        if (ammoPool == null)
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
    void SpawnAmmo(Vector2 position)
    {
        foreach (var ammo in ammoPool)
        {
            if (ammo.activeSelf == false)
            {
                ammo.transform.position = position;
                ammo.SetActive(true);
                break;
            }
        }
    }
    public IEnumerator CreateAmmos()
    {
        while (true)
        {
            Vector2 position;
            if (player == null || !isEnemy)
            {
                float x = Random.Range(-8, 7.4f);
                position = new Vector2(x, 3.7f);
            }
            else
            {
                position = new Vector2(player.transform.position.x, 3.7f);
            }
            SpawnAmmo(position);
            yield return new WaitForSeconds(interval);
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
