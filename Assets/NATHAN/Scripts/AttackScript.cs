using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField]
    public float AttackDamage;
    public Animator PlayerAnimator;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("attack");
        //play anim
        PlayerAnimator.SetTrigger("Attack");
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayer);
        //do damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealthScript>().TakeHit(AttackDamage);
            Debug.Log("Hit" + enemy.name);
            GetComponent<PlayerHealth>().getHealed();
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
