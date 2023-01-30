using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    float speed = 20f;
    int damage = 1;
    
    Vector3 vehiclePosition = Vector3.zero;
    Vector3 velocity = Vector3.right;
    Vector3 direction = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(0, speed * Time.deltaTime));
        vehiclePosition = transform.position;

        velocity = direction * speed * Time.deltaTime;

        vehiclePosition += velocity;

        transform.position = vehiclePosition;
    }
}
