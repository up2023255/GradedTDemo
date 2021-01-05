using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public float moveHorizontal;
    public float moveVertical;
    public float speed;

    public Rigidbody2D player;
    private Vector2 movement;

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * speed;
        moveVertical = Input.GetAxis("Vertical") * speed;

        movement = new Vector2(moveHorizontal, moveVertical);
        player.velocity = movement * speed;

        if (moveHorizontal > 0 || moveVertical > 0 || moveHorizontal < 0 || moveVertical < 0)
        {
            anim.SetBool("isRunning", true);
        }

        else
        {
            anim.SetBool("isRunning", false);
        }

        if (moveHorizontal < 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (moveHorizontal > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

}
