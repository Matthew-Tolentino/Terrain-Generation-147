using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController player;

    public float speed = 5f;
    public float jumpHeight = 3f;

    [Header("Ground Checks")]
    public float groundDistance = .25f;
    public LayerMask groundMask;

    public float gravity = -9.81f;
    bool isGrounded;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Gravity Handeling
        Vector3 checkPos = new Vector3(transform.position.x, transform.position.y - 1.6f, transform.position.z);
        if (Physics.CheckSphere(checkPos, groundDistance, groundMask))
        {
            isGrounded = true;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity + Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.Move(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.Move(-transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.Move(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.Move(transform.right * speed * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), .25f);
    }
}
