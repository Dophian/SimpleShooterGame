using UnityEngine;

// 점수 관리자 - 컴포넌트로 관리할 스크립트.
// 싱글톤(Singleton) - 디자인 패턴.
// - 싱행 환경에서 1개만 존재해야하는 제한 사항이 있음.
// - 1개이기 때문에 없어도 안되고 , 2개여도 안됨.
// - 사용하는 이유: 어디에서나 쉽게 접근이 가능한 구조를 제공하기 위해.
public class ScoreManager : MonoBehaviour
{
    // 싱글톤 필드.
    private static ScoreManager instance = null;

    // 점수 데이터.
    [SerializeField] private Score score = new Score();

    // 텍스트 UI 참조 변수.
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI bestScoreText;

    // 싱글톤 접근 프로퍼티.
    public static ScoreManager Instance
    {
        get { return instance; } 
    }

    // 싱글톤 접근 메세지 - 공개 메소드.
    public static ScoreManager Get()
    {
        return instance;
    }

    // 점수 획득 함수 (메세지 - 인터페이스, 공개 메소드).
    public void AddScore(int gainScore)
    {
        score.Add(gainScore);
    }

    // 점수 저장 함수 (메세지).
    public void SaveScore()
    {
        score.Save();
    }

    private void Awake()
    {
        // 싱글톤 초기화.
        // instance가 null인 경우는 생성이 필요한 경우이기 때문에
        // 이 게임 오므젝트를 싱글톤 객체로 설정.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // 점수 초기화.
        score.SetTextUI(scoreText, bestScoreText);
        score.Initialize();

    }
}