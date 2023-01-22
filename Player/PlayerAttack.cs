using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float coolDownTimer=Mathf.Infinity;
    private void Awake()
    {
        anim=GetComponent<Animator>();
        playerMovement=GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        bool boolean =Input.GetKey(KeyCode.Space) && (coolDownTimer > attackCooldown)&&playerMovement.canAttack();
        if(firePoint.transform.position.x>-31.83&&firePoint.transform.position.x<-28.24&&boolean){
            SceneManager.LoadScene("Level2");
         
        }else if(firePoint.transform.position.x>-28.23&&firePoint.transform.position.x<-25.9&&boolean){
            SceneManager.LoadScene("Level3");
         
        }else if(firePoint.transform.position.x>-24.24&&firePoint.transform.position.x<-22.10&&boolean){
            SceneManager.LoadScene("Level4");
         
        }else if(firePoint.transform.position.x>-21.5&&firePoint.transform.position.x<-18.2&&boolean){
            SceneManager.LoadScene("Level5");
         
        }else if(firePoint.transform.position.x>-17.19&&firePoint.transform.position.x<-14.87&&boolean){
            SceneManager.LoadScene("Level6");
         
        }else if(firePoint.transform.position.x>6.91&&firePoint.transform.position.x<9.35&&boolean){
            SceneManager.LoadScene("Level7");
         
        }else if(firePoint.transform.position.x>10.4&&firePoint.transform.position.x<13.5&&boolean){
            SceneManager.LoadScene("Level8");
         
        }else if(firePoint.transform.position.x>14.21&&firePoint.transform.position.x<16.32&&boolean){
            SceneManager.LoadScene("Level9");
         
        }else if(firePoint.transform.position.x>18.14&&firePoint.transform.position.x<20.43&&boolean){
            SceneManager.LoadScene("Level10");
         
        }else if(firePoint.transform.position.x>20.7&&firePoint.transform.position.x<23.92&&boolean){
            SceneManager.LoadScene("Level11");
         
        }else if(firePoint.transform.position.x>24.68&&firePoint.transform.position.x<28.62&&boolean){
            SceneManager.LoadScene("Level12");
         
        }else if(firePoint.transform.position.x>28.99&&firePoint.transform.position.x<32&&boolean){
            SceneManager.LoadScene("Level13");
         
        }else if(firePoint.transform.position.x>4.2&&firePoint.transform.position.x<6.2&&boolean){
            SceneManager.LoadScene("Info_2");
         
        }else if(firePoint.transform.position.x>-14.1&&firePoint.transform.position.x<-11.6&&boolean){
            SceneManager.LoadScene("Info_1");
         
        }
        
        coolDownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        coolDownTimer = 0;
        //pool fireballs
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
