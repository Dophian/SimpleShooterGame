using UnityEngine;

// 폭발 이펙트를 재생시키는 스크립트.
public class ExplosionEffector : MonoBehaviour
{
    // 폭발 애니메이션을 재생할 프리팹.
    [SerializeField] private GameObject explosion;

    // 공개 메소드 - 인터페이스.
    public void PlayExplosionEffect(Vector3 explosionPosition)
    {
        // 전달 받은 위치에 explosion 프리팹 생성.
        Instantiate(explosion, explosionPosition, Quaternion.identity);
    }
}