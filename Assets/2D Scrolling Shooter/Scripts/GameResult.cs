using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// ���� ��� ���� ����� ����ϴ� ��ũ��Ʈ.
// ���Ͽ��� ���� ����� �о�� ȭ�鿡 �����ִ� ���.
public class GameResult : MonoBehaviour
{
    // �ؽ�Ʈ UI ���� ����.
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI bestScoreText;

    // ������Ʈ�� Ȱ��ȭ�Ǹ� ����Ǵ� �̺�Ʈ �Լ�.
    private void OnEnable()
    {
        // ���� ��� ���� �ε�.
        // 1. ������ �ҷ��� ���ڿ��� �о����.
        string jsonString = File.ReadAllText("Assets/Score.txt");

        // 2. �ҷ��� ���ڿ� ���� ��ü�� ���� (������ȭ).
        var score = JsonUtility.FromJson<Score>(jsonString);
        //int bestScore = score.bestScore;

        // ��ü�κ��� ���� ���� �о�� �ؽ�Ʈ�� ǥ��.
        scoreText.text = $"Score: {score.score}";
        bestScoreText.text = $"BestScore: {score.bestScore}";
    }

    // Restart ��ư�� ������ ����� �Լ�.
    public void OnRestartClicked()
    {
        // ���� ���� �ٽ� �ε�.
        SceneManager.LoadScene(0);
    }

    // Quit ��ư�� ������ ����� �Լ�.
    public void OnQuitClicked()
    {
        // ����.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}