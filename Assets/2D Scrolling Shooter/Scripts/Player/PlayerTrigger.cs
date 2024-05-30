using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

// 플레이어의 충돌 처리를 담당하는 스크립트.
public class PlayerTrigger : MonoBehaviour
{
    // 적 탄약의 태그.
    [SerializeField] private string enemyBulletTag;

    // 플레이어의 체력(Health Power).
    [SerializeField] private float hp = 100f;

    // 이벤트.
    public UnityEvent OnPlayerDamaged;
    public UnityEvent<Vector3> OnPlayerDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 태그 비교.
        if (collision.CompareTag(enemyBulletTag))
        {
            // 적 탄약을 제거.
            Destroy(collision.gameObject);

            // 플레이어가 대미지를 입었다는 이벤트 발행.
            OnPlayerDamaged?.Invoke();

            // 대미지 처리.
            hp = hp - collision.GetComponent<BulletDamage>().Damage;
            hp = hp < 0f ? 0f : hp;

            // 죽음 확인 및 이벤트 발행.
            if (hp == 0f)
            {
                // 이벤트 발행.
                OnPlayerDead?.Invoke(transform.position);

                // 플레이어 게임 오브젝트 제거.
                Destroy(gameObject);
            }
        }
    }
}