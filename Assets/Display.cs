using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    private Text scoreText;
    private Text levelText;

    private void Start()
    {
        // PlayerPrefs에서 데이터 로드
        LoadData();
    }

    private void LoadData()
    {
        // Hierarchy에서 UI Text 컴포넌트를 찾아옴
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        // PlayerPrefs 값 로드
        int score = PlayerPrefs.GetInt("Score", 0);
        int level = PlayerPrefs.GetInt("Level", 0);

        // 데이터가 유효할 때만 표시
        if (scoreText != null && levelText != null)
        {
            scoreText.text = "Score: " + score.ToString();
            levelText.text = "Level: " + level.ToString();
        }
        else
        {
            Debug.LogError("ScoreText 또는 LevelText를 찾을 수 없습니다.");
        }

        Debug.Log($"Score: {score}, Level: {level}");
    }
}
