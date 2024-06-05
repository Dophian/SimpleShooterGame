using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// 게임 결과 관련 기능을 담당하는 스크립트.
// 파일에서 게임 결과를 읽어와 화면에 보여주는 기능.
public class GameResult : MonoBehaviour
{
    // 텍스트 UI 참조 변수.
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI bestScoreText;

    // 컴포넌트가 활성화되면 실행되는 이벤트 함수.
    private void OnEnable()
    {
        // 게임 결과 파일 로드.
        // 1. 파일을 불러와 문자열로 읽어오기.
        string jsonString = File.ReadAllText("Assets/Score.txt");

        // 2. 불러온 문자열 값을 객체로 복원 (역직렬화).
        var score = JsonUtility.FromJson<Score>(jsonString);
        //int bestScore = score.bestScore;

        // 객체로부터 점수 값을 읽어와 텍스트에 표기.
        scoreText.text = $"Score: {score.score}";
        bestScoreText.text = $"BestScore: {score.bestScore}";
    }

    // Restart 버튼이 눌리면 실행될 함수.
    public void OnRestartClicked()
    {
        // 게임 씬을 다시 로드.
        SceneManager.LoadScene(0);
    }

    // Quit 버튼이 눌리면 실행될 함수.
    public void OnQuitClicked()
    {
        // 종료.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}