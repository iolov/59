using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public Vector2 dic;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private bool trigger;

    void Update()
    {
        dic.x = Input.GetAxisRaw("Horizontal");
        dic.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (dic.x == 1) spriteRenderer.flipX = true; else spriteRenderer.flipX = false;
        if (dic.sqrMagnitude > 0)
        {
            trigger = true;
        }
        else
        {
            trigger = false;
        }
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("punBool");
        }
        rb.MovePosition(rb.position + dic * speed * Time.fixedDeltaTime);
        animator.SetBool("trigBool", trigger);
        
    }
}