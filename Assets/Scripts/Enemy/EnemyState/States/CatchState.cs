using UnityEngine;

public class CatchState : EnemyState, IEnemyState
{
    public CatchState(Enemy enemy) : base(enemy) { }

    public override void Enter()
    {
        //enemy.StopMove();
        //EventBus.PlayerCatched(enemy);        
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {

    }

    public override void Exit()
    {

    }
}