using UnityEngine;

// 배경을 스크롤 시키는 스크립트.
public class BGScroller : MonoBehaviour
{
    // 배경을 흘러가게 할 때 사용하는 조정 값.
    [SerializeField] private float speed = 0.1f;

    // 메시 렌더러가 관리하는 머티리얼의 Offset 값을 조정해야 함.
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // 머티리얼이 관리하는 텍스처의 Offset 값 중 Y 값을 조정.
        meshRenderer.material.mainTextureOffset
            += new Vector2(0f, speed) * Time.deltaTime;
    }
}