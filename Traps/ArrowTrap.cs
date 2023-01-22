using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] Arrows;
    private float coolDownTimer;
    private void Attack()
    {
        coolDownTimer = 0;
        Arrows[FindArrow()].transform.position = firepoint.position;
        Arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();

    }

    private int FindArrow()
    {
        for (int i = 0; i < Arrows.Length; i++)
        {
            if (!Arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    {
        coolDownTimer+= Time.deltaTime;
        if(coolDownTimer>attackCoolDown)
        {
            Attack();
        }
    }
}
