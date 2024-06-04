using System;
using System.IO;
using UnityEngine;

// 플레이어의 점수를 저장하는데 사용할 데이터 클래스.
// [System.Serializable]을 붙여야 인스펙터에서 필요할 때 노출이 가능.
[System.Serializable]
public class Score
{
    // 플레이어의 현재 점수.
    //[SerializeField]
    //[NonSerialized]
    private int score = 0;

    // 플레이어의 최고 점수 (기록).
    [SerializeField] private int bestScore = 0;

    // 텍스트 UI 참조 변수.
    private TMPro.TextMeshProUGUI scoreText;
    private TMPro.TextMeshProUGUI bestScoreText;

    // 메시지 - 공개 메소드 (인터페이스) - 초기화 함수.
    public void Initialize()
    {
        // 최고 점수 로드.
        //bestScore = PlayerPrefs.GetInt("BestScore");

        // JSON 테스트 - 역직렬화.
        // 1. 파일을 불러와 문자열로 읽어오기.
        string jsonString = File.ReadAllText("Assets/Score.txt");

        // 2. 불러온 문자열 값을 객체로 복원 (역질렬화).
        bestScore = JsonUtility.FromJson<Score>(jsonString).bestScore;


        // UI 업데이트
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }

        // UI 업데이트.
        if (bestScoreText != null)
        {
            bestScoreText.text = $"BestScore: {bestScore}";
        }
    }

    // 텍스트 UI의 참조 값을 설정하는 함수.
    public void SetTextUI(
        TMPro.TextMeshProUGUI scoreText,
        TMPro.TextMeshProUGUI bestScoreText)
    {
        this.scoreText = scoreText;
        this.bestScoreText = bestScoreText;
    }

    // 점수 획득 함수.
    public void Add(int gainScore)
    {
        // 점수 누적.
        score += gainScore;

        // UI 업데이트
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }

        // 최고 점수인지 확인 후에 넘었으면 최고 점수 업데이트.
        if (score > bestScore)
        {
            bestScore = score;

            // 최고 점수를 파일에 기록.
            PlayerPrefs.SetInt("BestScore", bestScore);

            // JSON으로 기록.
            // 1. 저장할 객체를 JSON 문자열로 생성(변환).
            string jsonString = JsonUtility.ToJson(this);

            // 2. 변환한 JSON 문자열을 파일로 저장.
            // 2-1 파일로 저장하려면 경로(저장하려는 위치)와 파일 이름, 확장자를 지정해야함.
            File.WriteAllText("Assets/Score.txt", jsonString);

            // UI 업데이트
            if (bestScoreText != null)
            {
                bestScoreText.text = $"BestScore: {bestScore}";
            }
        }
    }
}