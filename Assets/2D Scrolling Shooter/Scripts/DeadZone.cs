using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // 이 영역을 벗어난 콜라이더를 삭제.
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 게임 오브젝트 삭제.
        Destroy(collision.gameObject);
    }
}