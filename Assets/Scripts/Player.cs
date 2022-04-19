using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }


    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        //Swap sprite direction, wether you're going to right or left
        if (moveDelta.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //move y
        //Make sure we can move in this direction, by casting a box there first, if the box null, we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            //Move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        //move x
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            //Move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }



    }
}
