using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public Vector2 dic;
    public Rigidbody2D rb;

    public int trigger;
    public Animator animator;
    void Update()
    {
        dic.x = Input.GetAxisRaw("Horizontal");
        dic.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position +dic * speed*Time.fixedDeltaTime);
        animator.SetInteger("trigger",trigger);
        trigger = 2;
    }
}