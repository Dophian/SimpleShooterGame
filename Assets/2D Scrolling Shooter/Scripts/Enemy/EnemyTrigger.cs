using UnityEngine;
using UnityEngine.Events;

// �÷��̾�/�÷��̾� ź��� �浹 ó���� ����� ��ũ��Ʈ.
public class EnemyTrigger : MonoBehaviour
{
    // �浹 ó���� �÷��̾� ź�� �±�.
    [SerializeField] private string playerBulletTag;

    // ü�� (Health Power).
    [SerializeField] private float hp = 50f;

    // ����� �̺�Ʈ.
    public UnityEvent OnDamaged;

    // ���� �̺�Ʈ.
    public UnityEvent<Vector3> OnDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���𰡿� �浹�� ������, �±׸� ��.
        if (collision.CompareTag(playerBulletTag))
        {
            // �ϴ� ź�� ����.
            Destroy(collision.gameObject);

            // ������� �޾Ҵٴ� �̺�Ʈ ����.
            OnDamaged?.Invoke();

            // ����� ó��.
            // ����� ó�� ���� ���� ����.
            hp = hp - collision.GetComponent<BulletDamage>().Damage;
            hp = hp < 0f ? 0f : hp;

            // ü���� ��� ���������� ����.
            if (hp == 0f)
            {
                // ���� �̺�Ʈ ����.
                OnDead?.Invoke(transform.position);

                // ���� ȹ�� ó��.
                // 1. ���� ������ �˻�
                //var scoreManager = FindFirstObjectByType<ScoreManager>();

                // 2. ���� �����ڿ� ���� ȹ�� ���� ����.
                //scoreManager.AddScore(100);

                // �̱��� ���� �����ڿ��� �ٷ� ���� ȹ�� ����.
                ScoreManager.Get().AddScore(100);
                //ScoreManager.Instance.AddScore(100);

                // ����.
                Destroy(gameObject);
            }
        }
    }
}