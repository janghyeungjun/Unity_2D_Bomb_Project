using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundControl : MonoBehaviour
{
    GameObject background;
    public GameObject evening;
    public GameObject nignt;
    public GameObject levelUpSound;

 
    
    private bool isTriggered = false; // 중복 방지 플래그

    private int lastCheckedLevel = -1; // 마지막으로 확인된 레벨

    private void Start()
    {
        background = GameObject.Find("sky");
    }

    void Update()
    {
        int Level = int.Parse(GameObject.Find("LevelNumber").GetComponent<Text>().text);

        // 현재 레벨과 마지막으로 확인된 레벨이 다르면 실행
        if (Level != lastCheckedLevel)
        {
            CheckLevel(Level);
            lastCheckedLevel = Level; // 마지막 확인 레벨 업데이트
        }
    }

    void CheckLevel(int Level)
    {
        isTriggered = true; // 이벤트 처리 시작
        if (Level == 2)
        {

            // 기존 배경 삭제
            if (background != null)
            {
                Destroy(background);
            }

            // 저녁 배경 생성
            GameObject backEvening = Instantiate(evening);
            backEvening.transform.position = Vector3.zero;

            //소리

            if (levelUpSound != null)
            {
                GameObject levelSound = Instantiate(levelUpSound);
                Destroy(levelSound, 1f); // 1초 뒤에 코인 소리 오브젝트 삭제
            }

        }
        else if (Level == 3)
        {
            // 기존 저녁 배경 삭제
            GameObject existingEvening = GameObject.Find(evening.name + "(Clone)");
            if (existingEvening != null)
            {
                Destroy(existingEvening);
            }

            // 밤 배경 생성
            GameObject backNight = Instantiate(nignt);
            backNight.transform.position = Vector3.zero;
            //소리
            if (levelUpSound != null)
            {
                GameObject levelSound = Instantiate(levelUpSound);
                Destroy(levelSound, 1f); // 1초 뒤에 코인 소리 오브젝트 삭제
            }
        }
    }
}
