using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float movementSpeed;
    [SerializeField]private float damage;
    private bool movingleft;
    private float leftedge;
    private float rightedge;
    private void Awake()
    {
        leftedge = transform.position.x - movementDistance;
        rightedge=transform.position.x + movementDistance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().takeDamage(damage);
        }
    }
    private void Update()
    {
        if(movingleft)
        {
            if(transform.position.x>leftedge)
            {
                transform.position=new Vector3(transform.position.x-movementSpeed*Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingleft= false;
            }
        }
        else
        {
            if (transform.position.x < rightedge)
            {
                transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingleft = true;
            }

        }
    }
}
