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
        PlayerPrefs.SetInt("Score", 0); // ���� �ʱ�ȭ
        PlayerPrefs.SetInt("Level", 1); // ���� �ʱ�ȭ
        PlayerPrefs.Save(); // ��� ����

        // �ؽ�Ʈ UI�� �̿��Ͽ� ������ +1�� ��Ų��
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
        if (count3 > 0) // count3�� 0 �̻��� ���� ����
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
