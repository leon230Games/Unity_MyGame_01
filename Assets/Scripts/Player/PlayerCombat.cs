using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CharacterCombat {

    public float attackSpeed = 0.2f;

    public override void Attack(CharacterStats targetStats)
    {
        base.Attack(targetStats);

        if (getCanAttack())
        {
            if (onAttack != null)
            {
                onAttack.Invoke();
            }

            setAttackCooldown(1f / attackSpeed);
        }
    }
}
