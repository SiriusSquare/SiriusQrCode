using UnityEngine;
using UnityEngine.UI;

public class BossHpslider : MonoBehaviour
{
    public Slider sourceSlider;   // ���� �������� �� �����̴�
    public Slider targetSlider;   // �����ϰ� ���� ���� �����̴�

    private void Start()
    {
        if (sourceSlider != null && targetSlider != null)
        {
            // �ʱ� �ִ밪�� ���� ����ȭ
            SyncSliders();
        }
    }

    // �����̴� ���� ����ȭ�ϴ� �޼���
    public void SyncSliders()
    {
        if (sourceSlider != null && targetSlider != null)
        {
            targetSlider.maxValue = sourceSlider.maxValue;
            targetSlider.value = sourceSlider.value;
        }
    }
}
