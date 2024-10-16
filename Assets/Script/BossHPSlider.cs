using UnityEngine;
using UnityEngine.UI;

public class BossHpslider : MonoBehaviour
{
    public Slider sourceSlider;   // 값을 기준으로 할 슬라이더
    public Slider targetSlider;   // 동일하게 값을 따라갈 슬라이더

    private void Start()
    {
        if (sourceSlider != null && targetSlider != null)
        {
            // 초기 최대값과 값을 동기화
            SyncSliders();
        }
    }

    // 슬라이더 값을 동기화하는 메서드
    public void SyncSliders()
    {
        if (sourceSlider != null && targetSlider != null)
        {
            targetSlider.maxValue = sourceSlider.maxValue;
            targetSlider.value = sourceSlider.value;
        }
    }
}
