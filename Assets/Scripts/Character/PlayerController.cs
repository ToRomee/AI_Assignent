using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 控制角色移动速度
    public Animator animator; // 引用角色的Animator组件

    private Rigidbody2D rb; // 用于控制角色刚体
    private Vector2 moveDirection; // 用于存储移动方向

    public GameObject bulletPrefab; // 子弹的预制体
    public Transform firePoint; // 发射子弹的位置

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 获取玩家输入
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // 计算移动方向
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // 翻转角色朝向
        FlipCharacter(horizontalInput);

        // 更新Animator参数，控制行走动画的播放
        bool isMoving = Mathf.Abs(horizontalInput) !=0|| Mathf.Abs(verticalInput) !=0 ;
        animator.SetBool("Walking", isMoving);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // 移动角色
        MoveCharacter(moveDirection);
    }

    private void MoveCharacter(Vector2 direction)
    {
        rb.velocity = direction * moveSpeed;
    }

    private void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Shoot()
    {
        // 在发射点位置实例化子弹
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Rigidbody2D>().AddForce(moveDirection * 200);
    }
}
