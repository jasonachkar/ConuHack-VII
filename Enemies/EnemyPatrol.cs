using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingleft;
    private Animator anim;
    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    
    private float idleTimer;
    private void Awake()
    {
        initScale = enemy.localScale;
        anim= enemy.GetComponent<Animator>();
       
    }
    private void OnDisable()
    {
        anim.SetBool("Moving", false);
    }
   
    private void Update()
    {
        if (movingleft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if(enemy.position.x<=rightEdge.position.x) {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }

    }
    private void DirectionChange()
    {
        anim.SetBool("Moving", false);
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            movingleft = !movingleft;
        }
    }
    private void MoveInDirection(int _direction)
    {
        anim.SetBool("Moving", true);
        //Make enemy face right Direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
