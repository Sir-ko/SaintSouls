using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEvent : MonoBehaviour
{
    public EnemyAI EnemyAI;

    private void Start()
    {
        EnemyAI = FindObjectOfType<EnemyAI>();
    }
    public void MobAttack()
    {
        EnemyAI.PlaySoundOfAttack();
    }
}
