using System.Diagnostics;

public class IdleState : EnemyState, IEnemyState
{
    public IdleState(Enemy enemy) : base(enemy) { }

    public override void Enter()
    {

    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
        if (enemy.PlayerDetected())
        {
            enemy.ChangeState(new ChaseState(enemy));
        }
    }

    public override void Exit()
    {

    }
}