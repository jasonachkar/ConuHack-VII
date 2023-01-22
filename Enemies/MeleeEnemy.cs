using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCoolDown;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    private float coolDownTimer = Mathf.Infinity;


    [Header("Collider Parameters")]
    [SerializeField] private BoxCollider2D boxcollider;
    [SerializeField] private float colliderDistance;


    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private Health playerHealth;
    private Animator anim;
    private EnemyPatrol enemypatrol;


    private void Awake()
    {
        anim=GetComponent<Animator>();
        enemypatrol=GetComponentInParent<EnemyPatrol>();
    }
    private void Update()
    {
        coolDownTimer+= Time.deltaTime;


        //Attack only when player is in sight???
        if (PlayerInSight())
        {
            if (coolDownTimer > attackCoolDown)
            {
                coolDownTimer= 0;
                anim.SetTrigger("MeleeAttack");
            }
        }
        if (enemypatrol != null)
        {
           enemypatrol.enabled=!PlayerInSight();
        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast((boxcollider.bounds.center+transform.right*range*transform.localScale.x*colliderDistance), new Vector3(boxcollider.bounds.size.x*range,boxcollider.bounds.size.y,boxcollider.bounds.size.z), 0, Vector2.left,0,playerLayer) ;
        if (hit.collider != null)
        {
            playerHealth= hit.collider.GetComponent<Health>();
        }
        return hit.collider !=null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxcollider.bounds.center+transform.right*range * transform.localScale.x*colliderDistance, new Vector3(boxcollider.bounds.size.x * range, boxcollider.bounds.size.y, boxcollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        //If Player is still in rage, damage him.
        if(PlayerInSight())
        {
            //Damage PLayer
            playerHealth.takeDamage(damage);
        }
    }
}
