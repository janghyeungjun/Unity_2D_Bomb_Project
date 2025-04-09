using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public GameObject one;   // ���� 1 ������� ������
    public GameObject two;   // ���� 2 ������� ������
    public GameObject three; // ���� 3 ������� ������

    private int lastLevel = -1; // ������ ���� ��� (�ߺ� ����)

    private void Start()
    {
        // �ʱ� ����: ���� 1 ���� ���
        CheckLevel(1);
        lastLevel = 1;
    }

    private void Update()
    {
        // ���� ���� ��������
        int level = int.Parse(GameObject.Find("LevelNumber").GetComponent<Text>().text);

        // ������ ����Ǿ��� ���� ���� ��ȯ
        if (level != lastLevel)
        {
            CheckLevel(level);
            lastLevel = level; // ���� ������Ʈ
        }
    }

    void CheckLevel(int Level)
    {
        if (Level == 1 && GameObject.Find("one") == null)
        {
            // ���� 1: ���� "one" ���
            DestroyExistingMusic();
            GameObject soundInstance = Instantiate(one);
            soundInstance.name = "one";
        }
        else if (Level == 2 && GameObject.Find("two") == null)
        {
            // ���� 2: ���� ���� ���� �� ���� "two" ���
            DestroyExistingMusic();
            GameObject soundInstance = Instantiate(two);
            soundInstance.name = "two";
        }
        else if (Level == 3 && GameObject.Find("three") == null)
        {
            // ���� 3: ���� ���� ���� �� ���� "three" ���
            DestroyExistingMusic();
            GameObject soundInstance = Instantiate(three);
            soundInstance.name = "three";
        }
    }

    void DestroyExistingMusic()
    {
        // ���� ��� ���� ���� ����
        GameObject existingMusic = GameObject.Find("one") ?? GameObject.Find("two") ?? GameObject.Find("three");
        if (existingMusic != null)
        {
            Destroy(existingMusic);
        }
    }

    // �Ҹ� ��� �޼��� (�ٸ� Ŭ�������� ��� ����)
    public void PlaySound(GameObject soundPrefab, float duration)
    {
        if (soundPrefab != null)
        {
            GameObject soundInstance = Instantiate(soundPrefab);
            Destroy(soundInstance, duration); // ������ �ð� �� �Ҹ� ������Ʈ ����
        }
        else
        {
            Debug.LogError("Sound prefab is not assigned!");
        }
    }
}
