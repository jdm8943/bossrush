using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject prefab;

    [SerializeField]
    GameObject player;

    public int poolSize = 10;

    [SerializeField]
    float bulletSpeed = 10;

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

    public void ShootBullet()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.z));
        Vector2 direction = (worldPos - transform.position).normalized * bulletSpeed;

        GameObject bullet = GetObject();
        bullet.transform.position = player.transform.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction, ForceMode2D.Impulse);
    }
}
