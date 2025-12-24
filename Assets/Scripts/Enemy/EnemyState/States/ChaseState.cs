using UnityEngine;

public class ChaseState : EnemyState, IEnemyState
{
    private GameObject _player;

    public ChaseState(Enemy enemy) : base(enemy) { }

    public override void Enter()
    {
        _player = GameManager.Instance.player;
        Debug.Log("Enter Chasing");
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {

        if (enemy.DistanceToPlayer <= GameManager.Instance.enemyAttackDistance)
        {            
            enemy.ChangeState(new AttackState(enemy));
            return;
        }

        

        Vector2 direction = enemy.PlayerDirection;
        enemy.RotateTo(direction);

        RaycastHit2D hit = Physics2D.Raycast(
            (Vector2)enemy.transform.position + direction,
            direction * 0.1f, 0.1f);

        if (hit.collider != null)
        {           
            if (hit.collider.gameObject.GetComponent<Player>() == null)
            {
                Debug.Log("i can't move!!!"); 
                enemy.StopMoving();
                return;              
            }
        }

        enemy.MoveToPlayer();

    }

    public override void Exit()
    {
    }
}