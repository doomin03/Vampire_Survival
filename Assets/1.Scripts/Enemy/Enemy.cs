using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public struct EnemyData
{
    public float HP;
    public float Speed;
    public float Damege;
    public float AttackDistance;
    public float AttackSpeed;
}
public enum EnemyAnimation
{
    hit = 0,
    run,
    delay
}
public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private List<Sprite> runSp;
    [SerializeField]
    private List<Sprite> hitSp;
    [SerializeField]
    private Sprite bullet;

    RaycastHit2D[] hits;
    public EnemyData enemyData = new EnemyData();
    EnemyAnimation animation = EnemyAnimation.delay;    
    private int layerMask;
    private float delayTime;

    private float maxHP;
    private float curHP;
    public void Init()
    {
        GetComponent<SpriteAnimation>().SetSprite(runSp, 0.2f);
        animation= EnemyAnimation.run;
        layerMask = 1 << LayerMask.NameToLayer("Player");
        maxHP = enemyData.HP;
        curHP = maxHP;
    }
    public float HP
    {
        get { return curHP; }
        set
        {
            curHP -= value;
            if (animation != EnemyAnimation.hit)
            {
                GetComponent<SpriteAnimation>().SetSprite(hitSp , 0.2f);
                animation = EnemyAnimation.hit;
            }
        }
    }
    void Update()
    {
        Vector2 target = GameManager.Instance.player.transform.position;
        Vector2 myPos = transform.position;
        Vector2 dir = target - myPos;
        
        transform.Translate(dir.normalized*moveSpeed*Time.deltaTime);
        sr.flipX = dir.normalized.x > 0 ? false: true;
        hits = Physics2D.CircleCastAll(transform.position, enemyData.AttackDistance , Vector2.zero, 0 ,layerMask );
       
        {
            delayTime += Time.deltaTime;
        }


        foreach (var targets in hits)
        {
            if(delayTime>= enemyData.AttackSpeed)
            {
                if (targets.collider.GetComponent<Player>())
                {
                    targets.collider.GetComponent<Player>().HP = enemyData.Damege;
                }
                delayTime = 0;
            }
        }
        
        if (animation != EnemyAnimation.run)
        {
            GetComponent<SpriteAnimation>().SetSprite(runSp, 0.2f);
            animation = EnemyAnimation.run;
        }
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyData.AttackDistance);
    }
}
