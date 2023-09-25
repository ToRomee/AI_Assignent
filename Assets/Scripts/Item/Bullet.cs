using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // �ӵ����ٶȣ�������Inspector�е���
    private Vector3 shootDirection;

    private void Update()
    {
        // ��Y�᷽���ƶ��ӵ�
        Vector3 newPosition = transform.position + shootDirection * speed * Time.deltaTime;
        transform.position = newPosition;

        // ����ӵ�������Ļ�⣬������
        if (transform.position.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
