using UnityEngine;

public class ChaseState : EnemyState, IEnemyState
{
    public ChaseState(Enemy enemy) : base(enemy) { }

    public override void Enter()
    {
        Debug.Log("Enter Chasing");
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {

        if (enemy.PlayerCatched())
        {
            enemy.ChangeState(new CatchState(enemy));
            return;
        }

        enemy.MoveToPlayer();
    }

    public override void Exit()
    {
    }
}