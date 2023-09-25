using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // 子弹的速度，可以在Inspector中调整
    private Vector3 shootDirection;

    private void Update()
    {
        // 在Y轴方向移动子弹
        Vector3 newPosition = transform.position + shootDirection * speed * Time.deltaTime;
        transform.position = newPosition;

        // 如果子弹超出屏幕外，销毁它
        if (transform.position.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
