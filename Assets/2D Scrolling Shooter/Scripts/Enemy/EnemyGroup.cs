using UnityEngine;

// 자식 게임 오브젝트가 없으면 삭제를 하도록 처리하는 스크립트.
public class EnemyGroup : MonoBehaviour
{
    private void Awake()
    {
        // 간헐적으로 확인.
        InvokeRepeating("CheckChildState", 0f, 0.5f);
    }

    // 자식 게임 오브젝트가 있는지 없는지 확인하는 함수.
    private void CheckChildState()
    {
        // 자식이 없으면 게임 오브젝트 삭제.
        if (transform.childCount == 0)
        {
            CancelInvoke("CheckChildState");
            Destroy(gameObject);
        }
    }
}
