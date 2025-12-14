public class ChaseState : EnemyState
{
    public ChaseState(Enemy enemy) : base(enemy) { }
    
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