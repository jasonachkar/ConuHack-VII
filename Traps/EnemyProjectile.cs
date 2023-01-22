using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage //Will damage the player every time they touch
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private bool hit;
    private BoxCollider2D box;
    private void Awake()
    {
        anim= GetComponent<Animator>();
        box= GetComponent<BoxCollider2D>();
    }
    public void ActivateProjectile() {
        lifetime = 0;
        gameObject.SetActive(true);
        hit = false;
        box.enabled = true;

    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed=speed*Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);
        lifetime += Time.deltaTime;
        if(lifetime>resetTime)
        {
            gameObject.SetActive(false);   
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        box.enabled = false;
        base.OnTriggerEnter2D(collision); //Execute logic from parent Script First.
        gameObject.SetActive(false); //Deactivates whenever it hits anything.
        if(anim!=null)
        {
            anim.SetTrigger("explode");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);    
    }
}
