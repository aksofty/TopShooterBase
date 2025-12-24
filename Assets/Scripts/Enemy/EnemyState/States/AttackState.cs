using UnityEngine;


public class AttackState : EnemyState, IEnemyState
{
    public AttackState(Enemy enemy) : base(enemy) { }

    public override void Enter()
    {
        Debug.Log("Attack enter");
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
        if (enemy.DistanceToPlayer > GameManager.Instance.enemyAttackDistance)
        {            
            enemy.ChangeState(new ChaseState(enemy));
            return;
        }

         Debug.Log("Attacking");
    }

    public override void Exit()
    {

    }
}