using UnityEngine;

// 플레이어의 애니메이션 상태를 설정하는 스크립트.
public class AnimationController : MonoBehaviour
{
    // 애니메이터 컴포넌트 참조 변수.
    private Animator refAnimator;

    private void Awake()
    {
        refAnimator = GetComponent<Animator>();
    }

    // Animator에 Shoot 트리거를 설정하는 함수 - 인터페이스.
    public void SetShootTrigger()
    {
        refAnimator.SetTrigger("Shoot");
    }
}