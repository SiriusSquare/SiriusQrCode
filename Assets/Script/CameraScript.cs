using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;            // ���� �÷��̾��� Transform
    public Vector3 offset = new Vector3(0, 0, -10);  // ī�޶�� �÷��̾� ������ �Ÿ�
    public float smoothTime = 0.3f;     // �ε巴�� �̵��ϴ� �� �ɸ��� �ð�

    private Vector3 velocity = Vector3.zero; // ī�޶��� ���� �ӵ� (SmoothDamp���� �ʿ�)

    void LateUpdate()
    {
        if (player != null)
        {
            // ��ǥ ��ġ ��� (�÷��̾� ��ġ + ������)
            Vector3 targetPosition = player.position + offset;

            // SmoothDamp�� ����� ī�޶� ��ġ�� �ε巴�� �̵���Ŵ
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
