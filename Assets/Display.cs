using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    private Text scoreText;
    private Text levelText;

    private void Start()
    {
        // PlayerPrefs���� ������ �ε�
        LoadData();
    }

    private void LoadData()
    {
        // Hierarchy���� UI Text ������Ʈ�� ã�ƿ�
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        // PlayerPrefs �� �ε�
        int score = PlayerPrefs.GetInt("Score", 0);
        int level = PlayerPrefs.GetInt("Level", 0);

        // �����Ͱ� ��ȿ�� ���� ǥ��
        if (scoreText != null && levelText != null)
        {
            scoreText.text = "Score: " + score.ToString();
            levelText.text = "Level: " + level.ToString();
        }
        else
        {
            Debug.LogError("ScoreText �Ǵ� LevelText�� ã�� �� �����ϴ�.");
        }

        Debug.Log($"Score: {score}, Level: {level}");
    }
}
