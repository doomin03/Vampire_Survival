using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Burst.CompilerServices;
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
    [SerializeField]
    private SpriteRenderer[] hanhs;
    [SerializeField]
    private GameObject Fire;


    [SerializeField]
    private Bullet bullet;
    public float moveSpeed;
    
    public float runSpeed;

    public Bullet Bullet;
    public float AttackDistance;
    public Vector2 dis;
    private RaycastHit2D[] hit;

    private float maxHP;
    private float curHP;
    
    
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
        
        walkSpeed = moveSpeed;
        GetComponent<SpriteAnimation>().SetSprite(standSp, 0.2f);
        maxHP = playerData.HP;
        curHP = maxHP;
    }
    private void Update()
    {
        Move();
        hit = Physics2D.CircleCastAll(transform.position, 100, Vector2.zero);
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
    }

    public Transform Finding_Target()
    {
        Transform result = null;
        float diff = 100;
        if (hit == null)
        {
            return null;
        }

        foreach (RaycastHit2D targets in hit)
        {
            Vector2 playerPos = transform.position;
            Vector2 target = targets.transform.position;
            float dir = Vector2.Distance(playerPos, target);
            if (dir < diff)
            {
                diff = dir;
                result = targets.transform;
            }
        }

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 100);
    }
}
