using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private BoxCollider2D boxcollider;
    private Animator anim;
    private float lifetime;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxcollider= GetComponent<BoxCollider2D>();
    }
    private void Update()
    {   
        if (hit)
        {
            return;
        }
        float movementspeed=speed*Time.deltaTime* direction;
        transform.Translate(movementspeed, 0, 0);
        lifetime += Time.deltaTime;
        if (lifetime > 5)
        {
            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxcollider.enabled = false;
        anim.SetTrigger("explode");
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().takeDamage(1);
        }
    }
    public void SetDirection(float _direction)
    {   
        direction= _direction;
        gameObject.SetActive(true);
        hit = false;
        boxcollider.enabled = true;
        float localScaleX=transform.localScale.x;
        if(Mathf.Sign(localScaleX)!=_direction)
        {
            localScaleX = -localScaleX;

        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        lifetime = 0;

    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
