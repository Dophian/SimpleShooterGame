using UnityEngine;
using UnityEngine.SceneManagement;

// 게임에 관련된 제어를 담당하는 클래스.
// 싱글톤(Singleton) 클래스.
public class GameManager : MonoBehaviour
{
    // 싱글톤으로 외부 접근이 가능하도록 하는 프로퍼티.
    public static GameManager Instance { get; private set; }

    // 게임이 시작됐는지를 알려주는 프로퍼티.
    public bool IsGameStarted {  get; private set; }

    private void Awake()
    {
        // 초기화.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 플레이어가 죽었을 때 실행할 리스너 함수.
    public void OnPlayerDead()
    {
        // 게임 시작 값을 false로 설정.
        IsGameStarted = false;

        // 점수 저장.
        ScoreManager.Instance.SaveScore();

        // 게임 결과 씬 로드.
        SceneManager.LoadScene(1);
    }

    // Fade 애니메이션이 종료되면 발행되는 이벤트에 등록할 리스너 함수.
    public void OnFadeAnimaitionEnd()
    {
        IsGameStarted = true;
    }
}
