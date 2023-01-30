using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;

    private List<GameObject> bullets;

    void Start()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in bullets)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        bullets.Add(newObj);
        return newObj;
    }
}
