using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    //public float attackSpeed = 0.2f;
    //public float attackDelay = 0.6f;

    //Delegate of return type void and no args
    //public event System.Action OnAttack;
    public delegate void OnAttack();
    public OnAttack onAttack;

    private float attackCooldown = 2f;

    bool canAttack = false;

    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (attackCooldown <= 0f)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
    }
    public virtual void Attack(CharacterStats targetStats)
    {  
        
    }

    //IEnumerator DoDamage(CharacterStats stats, float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    stats.TakeDamage(myStats.damage.GetValue());
    //}

    public bool getCanAttack()
    {
        return canAttack;
    }

    public void setAttackCooldown(float value)
    {
        attackCooldown = value;
    }

}
