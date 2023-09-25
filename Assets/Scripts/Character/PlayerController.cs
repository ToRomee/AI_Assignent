using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // ���ƽ�ɫ�ƶ��ٶ�
    public Animator animator; // ���ý�ɫ��Animator���

    private Rigidbody2D rb; // ���ڿ��ƽ�ɫ����
    private Vector2 moveDirection; // ���ڴ洢�ƶ�����

    public GameObject bulletPrefab; // �ӵ���Ԥ����
    public Transform firePoint; // �����ӵ���λ��

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // ��ȡ�������
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // �����ƶ�����
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // ��ת��ɫ����
        FlipCharacter(horizontalInput);

        // ����Animator�������������߶����Ĳ���
        bool isMoving = Mathf.Abs(horizontalInput) !=0|| Mathf.Abs(verticalInput) !=0 ;
        animator.SetBool("Walking", isMoving);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // �ƶ���ɫ
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
        // �ڷ����λ��ʵ�����ӵ�
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Rigidbody2D>().AddForce(moveDirection * 200);
    }
}
