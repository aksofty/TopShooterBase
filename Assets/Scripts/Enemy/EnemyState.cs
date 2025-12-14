public abstract class EnemyState
{
    protected Enemy enemy;
    
    public EnemyState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class IdleState : EnemyState
{
    public IdleState(Enemy enemy) : base(enemy) { }
    
    public override void Enter()
    {
        // Начало ожидания
        //enemy.StopMovement();
    }
    
    public override void Update()
    {
        /*if (enemy.PlayerDetected())
        {
            enemy.ChangeState(new AttackingState(enemy));
        }*/
    }
    
    public override void Exit()
    {
        // Очистка состояния ожидания
    }
}

public class AttackingState : EnemyState
{
    public AttackingState(Enemy enemy) : base(enemy) { }
    
    public override void Enter()
    {
        // Начало атаки
        //enemy.StartAttackAnimation();
    }
    
    public override void Update()
    {
        /*enemy.MoveTowardsPlayer();
        
        if (!enemy.PlayerInRange())
        {
            enemy.ChangeState(new IdleState(enemy));
        }*/
    }
    
    public override void Exit()
    {
        // Очистка состояния атаки
        //enemy.StopAttackAnimation();
    }
}
