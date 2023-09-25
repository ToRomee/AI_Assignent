using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ҫ�����Ŀ�꣨ͨ������ҽ�ɫ��
    public float smoothSpeed = 5.0f; // ƽ���ٶ�
    private Vector3 offset; // ��������Ŀ���ƫ��

    private void LateUpdate()
    {
        //print(offset);
        offset = target.position - transform.position;

        offset.z = 0;

        // �����������λ��
        transform.position += offset / smoothSpeed;

        //transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}
