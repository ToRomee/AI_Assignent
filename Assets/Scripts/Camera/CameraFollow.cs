using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 要跟随的目标（通常是玩家角色）
    public float smoothSpeed = 5.0f; // 平滑速度
    private Vector3 offset; // 相机相对于目标的偏移

    private void LateUpdate()
    {
        //print(offset);
        offset = target.position - transform.position;

        offset.z = 0;

        // 更新摄像机的位置
        transform.position += offset / smoothSpeed;

        //transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}
