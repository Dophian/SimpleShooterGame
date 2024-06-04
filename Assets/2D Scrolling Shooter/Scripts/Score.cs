using System;
using System.IO;
using UnityEngine;

// �÷��̾��� ������ �����ϴµ� ����� ������ Ŭ����.
// [System.Serializable]�� �ٿ��� �ν����Ϳ��� �ʿ��� �� ������ ����.
[System.Serializable]
public class Score
{
    // �÷��̾��� ���� ����.
    //[SerializeField]
    //[NonSerialized]
    private int score = 0;

    // �÷��̾��� �ְ� ���� (���).
    [SerializeField] private int bestScore = 0;

    // �ؽ�Ʈ UI ���� ����.
    private TMPro.TextMeshProUGUI scoreText;
    private TMPro.TextMeshProUGUI bestScoreText;

    // �޽��� - ���� �޼ҵ� (�������̽�) - �ʱ�ȭ �Լ�.
    public void Initialize()
    {
        // �ְ� ���� �ε�.
        //bestScore = PlayerPrefs.GetInt("BestScore");

        // JSON �׽�Ʈ - ������ȭ.
        // 1. ������ �ҷ��� ���ڿ��� �о����.
        string jsonString = File.ReadAllText("Assets/Score.txt");

        // 2. �ҷ��� ���ڿ� ���� ��ü�� ���� (������ȭ).
        bestScore = JsonUtility.FromJson<Score>(jsonString).bestScore;


        // UI ������Ʈ
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }

        // UI ������Ʈ.
        if (bestScoreText != null)
        {
            bestScoreText.text = $"BestScore: {bestScore}";
        }
    }

    // �ؽ�Ʈ UI�� ���� ���� �����ϴ� �Լ�.
    public void SetTextUI(
        TMPro.TextMeshProUGUI scoreText,
        TMPro.TextMeshProUGUI bestScoreText)
    {
        this.scoreText = scoreText;
        this.bestScoreText = bestScoreText;
    }

    // ���� ȹ�� �Լ�.
    public void Add(int gainScore)
    {
        // ���� ����.
        score += gainScore;

        // UI ������Ʈ
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }

        // �ְ� �������� Ȯ�� �Ŀ� �Ѿ����� �ְ� ���� ������Ʈ.
        if (score > bestScore)
        {
            bestScore = score;

            // �ְ� ������ ���Ͽ� ���.
            PlayerPrefs.SetInt("BestScore", bestScore);

            // JSON���� ���.
            // 1. ������ ��ü�� JSON ���ڿ��� ����(��ȯ).
            string jsonString = JsonUtility.ToJson(this);

            // 2. ��ȯ�� JSON ���ڿ��� ���Ϸ� ����.
            // 2-1 ���Ϸ� �����Ϸ��� ���(�����Ϸ��� ��ġ)�� ���� �̸�, Ȯ���ڸ� �����ؾ���.
            File.WriteAllText("Assets/Score.txt", jsonString);

            // UI ������Ʈ
            if (bestScoreText != null)
            {
                bestScoreText.text = $"BestScore: {bestScore}";
            }
        }
    }
}