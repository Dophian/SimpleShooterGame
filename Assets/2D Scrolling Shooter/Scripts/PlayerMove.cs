using UnityEngine;

// ���콺 �巡��(�����-��ġ)�� ����ؼ� �÷��̾ �̵���Ű�� ��ũ��Ʈ.
public class PlayerMove : MonoBehaviour
{
    // �÷��̾ �̵��� �� ������ ������ �ӵ� ��.
    [SerializeField] private float lagSpeed = 5f;

    // ī�޶� ������ ���� ����.
    private Camera mainCamera;

    // �÷��̾�� �巡�� ��ġ�� ������ ��.
    private Vector3 offset;

    // Ʈ������ ���� ����.
    private Transform refTransform;

    private void Awake()
    {
        // ���� ī�޶� ������ ����.
        mainCamera = Camera.main;

        // Ʈ������ ����.
        refTransform = transform;
    }

    private void Update()
    {
        // ���콺 Ŭ���� ������ �� ���콺 Ŭ�� ��ġ�� �÷��̾��� ��ġ�� ���������� ���.
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�� 3���� ���� ��ǥ�� ��ȯ.
            Vector3 clickPosition
                = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;

            // ������ ��� �� ����
            offset = refTransform.position - clickPosition;
        }

        // ���콺 Ŭ�� �� �ݺ�.
        if (Input.GetMouseButton(0))
        {
            // ���콺 ��ġ�� 3���� ���� ��ǥ�� ��ȯ.
            Vector3 clickPosition
                = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;

            // �������� ������ �̵��ؾ��� ���� ��ġ�� �ϴ� ����.
            Vector3 targetPosition = clickPosition + offset;

            // x ���� ��ġ�� ȭ���� ����� �ʵ��� ����.
            targetPosition.x = Mathf.Clamp(targetPosition.x, -1.05f, 1.05f);

            // 3�������� ��ȯ�� ��ģ ��ġ�� �÷��̾��� ��ġ�� ����.
            //refTransform.position = clickPosition + offset;
            refTransform.position = Vector3.Lerp(
                refTransform.position,
                targetPosition,
                Time.deltaTime * lagSpeed
            );
        }

        // Ŭ�� ���� �� ������ ����.
        if (Input.GetMouseButtonUp(0))
        {
            offset = Vector3.zero;
        }
    }
}