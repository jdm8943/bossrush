using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;
    bool isDodging = false;
    float dodgeTimer = 0f;
    Vector2 lastPlayerInput = new Vector2();
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDodging)
        {
            DodgeMovement();
        }
        else
        {
            RegularMovement();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        lastPlayerInput = context.ReadValue<Vector2>();

        if (!isDodging)
        {
            direction = lastPlayerInput;
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        StartDodge();
    }

    void RegularMovement()
    {
        Vector3 vehiclePosition = transform.position;

        // Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position 
        vehiclePosition += velocity;

        // “Draw” this vehicle at that position
        transform.position = vehiclePosition;
    }

    void DodgeMovement()
    {
        Vector3 vehiclePosition = transform.position;

        // Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position 
        vehiclePosition += velocity;

        // “Draw” this vehicle at that position
        transform.position = vehiclePosition;

        if (dodgeTimer <= 1f)
        {
            dodgeTimer += Time.deltaTime;
        }
        else
        {
            isDodging = false;
            GetComponent<SpriteRenderer>().color = Color.white;
            dodgeTimer = 0f;
            direction = lastPlayerInput;
        }
    }

    void StartDodge()
    {
        isDodging = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        direction = lastPlayerInput;
    }
}
