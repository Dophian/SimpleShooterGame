using System.Collections;
using UnityEngine;

// 대미지 효과를 보여줄 때 사용할 스크립트.
public class DamageEffector : MonoBehaviour
{
    // 필드.
    // 색상을 깜박이는 애니메이션을 재생하는 시간(단위: 초).
    [SerializeField] private float colorAnimationInterval = 0.1f;

    // 스프라이트 렌더러 참조 컴포넌트.
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 공개 메소드 - 인터페이스.
    public void PlayDamageEffect()
    {
        StartCoroutine(PlayDamageAnimation());
    }

    private IEnumerator PlayDamageAnimation()
    {
        // 스프라이트 렌더러의 색상을 빨간색으로 설정.
        spriteRenderer.color = Color.red;

        // 대기.
        yield return new WaitForSeconds(colorAnimationInterval);

        // 스프라이트 렌더러의 색상을 흰색으로 설정.
        spriteRenderer.color = Color.white;
    }
}