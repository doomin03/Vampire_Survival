using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public float moveSpeed;
    
    public float runSpeed;
    public Camera camera;

    private float walkSpeed;
    private SpriteRenderer sr;
    public void Init()
    {
        sr= GetComponent<SpriteRenderer>();
        walkSpeed = moveSpeed;
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
        if (_moveX > 0)
        {
            sr.flipX= false;
        }
        else if(_moveX < 0)
        {
            sr.flipX= true;
        }
        if(_moveY == 0||_moveX==0) {
            animator.SetTrigger("idle");
        }
        Vector2 dis = new Vector2(_moveX, _moveY) * moveSpeed * Time.deltaTime;
        if (_moveX > 0 && _moveY > 0)
        {
            animator.SetTrigger("Run");
        }
        transform.Translate(dis);
    }

    private void Update()
    {
        Move();
    }

    public virtual void CameraMove()
    {
        camera.transform.position = Vector2.Lerp(camera.transform.position, transform.position, 1f);
        camera.transform.Translate(0, 0, -10);
    }
}
