using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;
    bool isDodging = false;
    bool dodgeFinished = false;
    float dodgeTimer = 0f;
    float lastSecond = 0f;
    Vector2 lastPlayerInput = new Vector2();

    Vector3 vehiclePosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vehiclePosition = transform.position;

        // Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position 
        vehiclePosition += velocity;

        // “Draw” this vehicle at that position
        transform.position = vehiclePosition;


        // TODO: FIX DODGE SO YOU STOP AT THE END
        //  POSSIBLE FIX: MOVING IT TO SEPERATE FUNCTION WITH SEPERATE MOVEMENT CALCULATIONS

        // Dodge timer
        if (dodgeTimer <= 1f)
        {
            dodgeTimer += Time.deltaTime;
            lastSecond = dodgeTimer;
        }
        else
        {
            isDodging = false;
            GetComponent<SpriteRenderer>().color = Color.white;
            dodgeTimer = 0f;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (isDodging)
        {
            return;
        }
        lastPlayerInput = context.ReadValue<Vector2>();
        direction = lastPlayerInput;

        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        isDodging = true;
        GetComponent<SpriteRenderer>().color = Color.red;

    }

    public void EndDodge()
    {
        if (dodgeFinished)
        {

        }
    }
}
