using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpikeHead : EnemyDamage
{
    private Vector3 destination;
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private bool attacking;
    private float checkTimer; 
    private Vector3[] directions = new Vector3[4];
    private void OnEnable()
    {
        Stop();
    }
    private void Update()
    {   
        //Move spikehead to destination only if attacking.
        if(attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }

    }
    private void CheckForPlayer()
    {
        calculateDirections();
        //Check if spikehead sees player in all 4 directions.
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i],range,playerLayer);

            if(hit.collider!=null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }
    private void calculateDirections()
    {
        directions[0] = transform.right*range; //Right Direction
        directions[1]= -transform.right*range; //Left direction
        directions[2]= transform.up*range; //Up Direction
        directions[3]=-transform.up*range;
    }
    private void Stop()
    {
        destination = transform.position;
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
        //Stop SpikeHead once he hits smthng
        Stop();

    }
}
