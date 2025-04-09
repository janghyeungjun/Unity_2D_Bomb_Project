using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    Text level;
    Text score;
    Text shieldNumber;
    int count3;
    int count;
    int count1;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0); // 점수 초기화
        PlayerPrefs.SetInt("Level", 1); // 레벨 초기화
        PlayerPrefs.Save(); // 즉시 저장

        // 텍스트 UI를 이용하여 점수를 +1점 시킨다
        score = GameObject.Find("ScoreNumber").GetComponent<Text>();
        count = 0;
        level = GameObject.Find("LevelNumber").GetComponent<Text>();
        count1 = 0;
        shieldNumber = GameObject.Find("ShieldNumber").GetComponent<Text>();
        count3 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        count += 1;
        score.text = count.ToString();
        PlayerPrefs.SetInt("Score", count);
        PlayerPrefs.Save();
    }

    public void AddLevel()
    {
        count1 += 1;
        level.text = count1.ToString();
        PlayerPrefs.SetInt("Level", count1);
        PlayerPrefs.Save();
    }
    public void Shield()
    {
        if (count3 > 0) // count3가 0 이상일 때만 감소
        {
            count3 -= 1;

            shieldNumber.text = count3.ToString();
        }
        else
        {
            Debug.Log("Shield count is already zero!");
        }
    }



}
