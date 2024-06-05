using UnityEngine;
using UnityEngine.SceneManagement;

// ���ӿ� ���õ� ��� ����ϴ� Ŭ����.
// �̱���(Singleton) Ŭ����.
public class GameManager : MonoBehaviour
{
    // �̱������� �ܺ� ������ �����ϵ��� �ϴ� ������Ƽ.
    public static GameManager Instance { get; private set; }

    // ������ ���۵ƴ����� �˷��ִ� ������Ƽ.
    public bool IsGameStarted {  get; private set; }

    private void Awake()
    {
        // �ʱ�ȭ.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �÷��̾ �׾��� �� ������ ������ �Լ�.
    public void OnPlayerDead()
    {
        // ���� ���� ���� false�� ����.
        IsGameStarted = false;

        // ���� ����.
        ScoreManager.Instance.SaveScore();

        // ���� ��� �� �ε�.
        SceneManager.LoadScene(1);
    }

    // Fade �ִϸ��̼��� ����Ǹ� ����Ǵ� �̺�Ʈ�� ����� ������ �Լ�.
    public void OnFadeAnimaitionEnd()
    {
        IsGameStarted = true;
    }
}
