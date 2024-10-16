using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;            // 따라갈 플레이어의 Transform
    public Vector3 offset = new Vector3(0, 0, -10);  // 카메라와 플레이어 사이의 거리
    public float smoothTime = 0.3f;     // 부드럽게 이동하는 데 걸리는 시간

    private Vector3 velocity = Vector3.zero; // 카메라의 현재 속도 (SmoothDamp에서 필요)

    void LateUpdate()
    {
        if (player != null)
        {
            // 목표 위치 계산 (플레이어 위치 + 오프셋)
            Vector3 targetPosition = player.position + offset;

            // SmoothDamp를 사용해 카메라 위치를 부드럽게 이동시킴
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
