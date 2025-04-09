using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundControl : MonoBehaviour
{
    GameObject background;
    public GameObject evening;
    public GameObject nignt;
    public GameObject levelUpSound;

 
    
    private bool isTriggered = false; // �ߺ� ���� �÷���

    private int lastCheckedLevel = -1; // ���������� Ȯ�ε� ����

    private void Start()
    {
        background = GameObject.Find("sky");
    }

    void Update()
    {
        int Level = int.Parse(GameObject.Find("LevelNumber").GetComponent<Text>().text);

        // ���� ������ ���������� Ȯ�ε� ������ �ٸ��� ����
        if (Level != lastCheckedLevel)
        {
            CheckLevel(Level);
            lastCheckedLevel = Level; // ������ Ȯ�� ���� ������Ʈ
        }
    }

    void CheckLevel(int Level)
    {
        isTriggered = true; // �̺�Ʈ ó�� ����
        if (Level == 2)
        {

            // ���� ��� ����
            if (background != null)
            {
                Destroy(background);
            }

            // ���� ��� ����
            GameObject backEvening = Instantiate(evening);
            backEvening.transform.position = Vector3.zero;

            //�Ҹ�

            if (levelUpSound != null)
            {
                GameObject levelSound = Instantiate(levelUpSound);
                Destroy(levelSound, 1f); // 1�� �ڿ� ���� �Ҹ� ������Ʈ ����
            }

        }
        else if (Level == 3)
        {
            // ���� ���� ��� ����
            GameObject existingEvening = GameObject.Find(evening.name + "(Clone)");
            if (existingEvening != null)
            {
                Destroy(existingEvening);
            }

            // �� ��� ����
            GameObject backNight = Instantiate(nignt);
            backNight.transform.position = Vector3.zero;
            //�Ҹ�
            if (levelUpSound != null)
            {
                GameObject levelSound = Instantiate(levelUpSound);
                Destroy(levelSound, 1f); // 1�� �ڿ� ���� �Ҹ� ������Ʈ ����
            }
        }
    }
}
