using UnityEngine;

// 탄약을 이동시키는 스크립트.

public class BulletMove : MonoBehaviour
{
    // 탄약의 이동 속도.
    [SerializeField] private float moveSpeed = 10f;

    // 트랜스폼 컴포넌트 참조 변수.
    private Transform refTransform;

    private void Awake()
    {
        refTransform = transform;
    }

    private void Update()
    {
        refTransform.position += refTransform.up * moveSpeed * Time.deltaTime;
    }
}
