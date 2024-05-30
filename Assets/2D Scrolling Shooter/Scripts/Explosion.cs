using UnityEngine;

// Explosion 애니메이션 이벤트를 처리할 스크립트.
public class Explosion : MonoBehaviour
{
    // 애니메이션 이벤트와 연동할 함수.
    void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
