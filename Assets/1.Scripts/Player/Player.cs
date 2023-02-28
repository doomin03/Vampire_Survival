using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public struct PlayerData {
    public int id;
    public float HP;
    public float Damage;
    public float Speed;
    public float AttackRange;
    public float AttackSpeed;

}

public enum PlayerAnimation
{
    stand = 0,
    run
}

public abstract class Player : MonoBehaviour
{

    [SerializeField]
    private List<Sprite> runSp;
    [SerializeField]
    private List<Sprite> standSp;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Image hpImage;


    public float moveSpeed;
    
    public float runSpeed;

    public float AttackDistance;
    public Vector2 dis;

    private float maxHP;
    private float curHP;
    private RaycastHit2D[] hit;
    private BGController bg;
    public PlayerData playerData = new PlayerData();
    private PlayerAnimation dir = PlayerAnimation.stand;
   
    private float walkSpeed;

    public float HP
    {
        get { return curHP; }
        set
        {
            curHP -= value;
            hpImage.fillAmount = curHP / maxHP;
            Debug.Log(curHP);
        }
    }
    public void Init()
    {
        bg= GetComponent<BGController>();
        walkSpeed = moveSpeed;
        GetComponent<SpriteAnimation>().SetSprite(standSp, 0.2f);
        maxHP = playerData.HP;
        curHP = maxHP;
    }
    private void Update()
    {
        Move();
        
    }
    public virtual void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        float _moveX = Input.GetAxis("Horizontal");
        float _moveY = Input.GetAxis("Vertical");


        sr.flipX = _moveX > 0 ? false:true;
        if (_moveY>0 && dir != PlayerAnimation.run || _moveX > 0&&dir!=PlayerAnimation.run)
        {
            GetComponent<SpriteAnimation>().SetSprite(runSp, 0.2f);
            dir= PlayerAnimation.run;
        }
        else if(_moveY < 0 && dir != PlayerAnimation.run || _moveX < 0&&dir!=PlayerAnimation.run)
        {
            GetComponent<SpriteAnimation>().SetSprite(runSp, 0.2f);
            dir = PlayerAnimation.run;
        }
        if(_moveY == 0 && _moveX==0 &&dir!= PlayerAnimation.stand) {

            GetComponent<SpriteAnimation>().SetSprite(standSp,0.2f);
            dir= PlayerAnimation.stand;
        }
        
        
        dis = new Vector2(_moveX, _moveY) * moveSpeed * Time.deltaTime;
        transform.Translate(dis);
        _Basics_Attack();


    }
    public void _Basics_Attack()
    {
        hit = Physics2D.CircleCastAll(transform.position,playerData.AttackRange,Vector2.zero);
        foreach (RaycastHit2D targets in hit)
        {
            if (targets.collider.GetComponent<Enemy>())
            {
                targets.collider.GetComponent<Enemy>().HP = playerData.Damage;
            }
            
        }
        

    }
    //private Transform GetDic()
    //{
    //    Vector2 myPos = transform.position;
    //    Vector2 targetPos = GameObject.FindObjectOfType<Enemy>().transform.position;
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerData.AttackRange);
    }






}
