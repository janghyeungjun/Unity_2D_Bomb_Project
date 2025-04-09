using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bombMaker : MonoBehaviour
{
    float interval = 0.7f;
    float delta = 0f;
    public GameObject bmprefab;
    private int currentLevel = 0; // ���� ������ ����

    void Update()
    {
        // ���� ��������
        int score = int.Parse(GameObject.Find("ScoreNumber").GetComponent<Text>().text);

        // ���� ���� üũ
        CheckLevel(score);

        // ��ź ���� ����
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
        // ���� 1: ���� 3 �̻�
        if (score >= 5 && currentLevel < 1)
        {
            interval = 0.7f; // ���� ���� ����
            GameObject.Find("AddScore").GetComponent<ScoreControl>().AddLevel();
            currentLevel = 1; // ���� ������Ʈ
        }

        // ���� 2: ���� 6 �̻�
        if (score >= 10 && currentLevel < 2)
        {
            interval = 0.4f; // ���� ���� ����
            GameObject.Find("AddScore").GetComponent<ScoreControl>().AddLevel();
            currentLevel = 2; // ���� ������Ʈ
        }

        // ���� 3: ���� 6 �̻�
        if (score >= 15 && currentLevel < 3)
        {
            interval = 0.2f; // ���� ���� ����
            GameObject.Find("AddScore").GetComponent<ScoreControl>().AddLevel();
            currentLevel = 3; // ���� ������Ʈ
        }
    }
}
