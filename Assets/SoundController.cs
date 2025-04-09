using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public GameObject one;   // 레벨 1 배경음악 프리팹
    public GameObject two;   // 레벨 2 배경음악 프리팹
    public GameObject three; // 레벨 3 배경음악 프리팹

    private int lastLevel = -1; // 마지막 레벨 기록 (중복 방지)

    private void Start()
    {
        // 초기 설정: 레벨 1 음악 재생
        CheckLevel(1);
        lastLevel = 1;
    }

    private void Update()
    {
        // 현재 레벨 가져오기
        int level = int.Parse(GameObject.Find("LevelNumber").GetComponent<Text>().text);

        // 레벨이 변경되었을 때만 음악 전환
        if (level != lastLevel)
        {
            CheckLevel(level);
            lastLevel = level; // 레벨 업데이트
        }
    }

    void CheckLevel(int Level)
    {
        if (Level == 1 && GameObject.Find("one") == null)
        {
            // 레벨 1: 음악 "one" 재생
            DestroyExistingMusic();
            GameObject soundInstance = Instantiate(one);
            soundInstance.name = "one";
        }
        else if (Level == 2 && GameObject.Find("two") == null)
        {
            // 레벨 2: 기존 음악 삭제 후 음악 "two" 재생
            DestroyExistingMusic();
            GameObject soundInstance = Instantiate(two);
            soundInstance.name = "two";
        }
        else if (Level == 3 && GameObject.Find("three") == null)
        {
            // 레벨 3: 기존 음악 삭제 후 음악 "three" 재생
            DestroyExistingMusic();
            GameObject soundInstance = Instantiate(three);
            soundInstance.name = "three";
        }
    }

    void DestroyExistingMusic()
    {
        // 현재 재생 중인 음악 삭제
        GameObject existingMusic = GameObject.Find("one") ?? GameObject.Find("two") ?? GameObject.Find("three");
        if (existingMusic != null)
        {
            Destroy(existingMusic);
        }
    }

    // 소리 재생 메서드 (다른 클래스에서 사용 가능)
    public void PlaySound(GameObject soundPrefab, float duration)
    {
        if (soundPrefab != null)
        {
            GameObject soundInstance = Instantiate(soundPrefab);
            Destroy(soundInstance, duration); // 지정된 시간 후 소리 오브젝트 삭제
        }
        else
        {
            Debug.LogError("Sound prefab is not assigned!");
        }
    }
}
