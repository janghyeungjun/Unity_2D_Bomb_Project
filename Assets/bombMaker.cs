using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bombMaker : MonoBehaviour
{
    float interval = 0.7f;
    float delta = 0f;
    public GameObject bmprefab;
    private int currentLevel = 0; // 현재 레벨을 추적

    void Update()
    {
        // 점수 가져오기
        int score = int.Parse(GameObject.Find("ScoreNumber").GetComponent<Text>().text);

        // 레벨 조건 체크
        CheckLevel(score);

        // 폭탄 생성 로직
        delta += Time.deltaTime;
        if (delta > interval)
        {
            int x = Random.Range(-7, 8);
            delta = 0f;
            GameObject bomb = Instantiate(bmprefab);
            bomb.transform.position = new Vector3(x, 5.5f, 0);
        }
    }

    void CheckLevel(int score)
    {
        // 레벨 1: 점수 3 이상
        if (score >= 5 && currentLevel < 1)
        {
            interval = 0.7f; // 생성 간격 감소
            GameObject.Find("AddScore").GetComponent<ScoreControl>().AddLevel();
            currentLevel = 1; // 레벨 업데이트
        }

        // 레벨 2: 점수 6 이상
        if (score >= 10 && currentLevel < 2)
        {
            interval = 0.4f; // 생성 간격 감소
            GameObject.Find("AddScore").GetComponent<ScoreControl>().AddLevel();
            currentLevel = 2; // 레벨 업데이트
        }

        // 레벨 3: 점수 6 이상
        if (score >= 15 && currentLevel < 3)
        {
            interval = 0.2f; // 생성 간격 감소
            GameObject.Find("AddScore").GetComponent<ScoreControl>().AddLevel();
            currentLevel = 3; // 레벨 업데이트
        }
    }
}
