using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2d;
    private float xMove;
    private float yMove;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void PlayerInput()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            xMove = Input.acceleration.x;
            yMove = Input.acceleration.y;
        }
        // to slow on oblique direction
        if (xMove != 0 && yMove != 0)
        {
            xMove *= 0.6f;
            yMove *= 0.6f;

        }
        movement = new Vector2(xMove, yMove);
    }

    private void Movement()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.deltaTime);

    }
}
