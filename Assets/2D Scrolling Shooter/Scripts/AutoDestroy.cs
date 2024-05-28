using UnityEngine;

// 지정한 시간이 지나면 게임 오브젝트를 자동 삭제해주는 스크립트.
public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime = 1f;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
}
