using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodControl : MonoBehaviour
{
    GameObject hp;
    public GameObject heelSound;
    private bool isTriggered = false; // 중복 방지 플래그

    private void Start()
    {
        // HP라는 이름의 GameObject를 찾아 hp에 할당
        hp = GameObject.Find("HP");
        if (hp == null)
        {
            Debug.LogError("HP GameObject not found in the scene.");
        }

        // 새로 생성된 과일의 플래그를 초기화
        isTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 중복 호출 방지
        if (isTriggered) return;

        if (collision.gameObject.tag == "Player")
        {
            isTriggered = true; // 이벤트 처리 시작

            // 힐 처리
            if (hp != null)
            {
                GameObject.Find("SoundController").GetComponent<SoundController>().PlaySound(heelSound, 1f);

                int healAmount = GetHealAmount(); // 힐량 계산
                hp.GetComponent<HPController>().heel(healAmount); // 힐량 전달
            }

            // 새로운 과일 생성
            GameObject makeFood = GameObject.Find("NewFood");
            if (makeFood != null)
            {
                makeFood.GetComponent<NewFood>().makefood();
            }
            else
            {
                Debug.LogError("NewFood GameObject not found in the scene.");
            }

            // 현재 과일 삭제
            Destroy(gameObject);
        }
    }

    private int GetHealAmount()
    {
        // 프리팹 이름 또는 태그에 따라 힐량 결정
        switch (gameObject.name)
        {
            case "Apple(Clone)": // Apple 프리팹
                return 10; // 힐량 10
            case "orange(Clone)": // Orange 프리팹
                return 20; // 힐량 20
            case "stone(Clone)": // Stone 프리팹
                return 5; // 힐량 감소
            default:
                return 5; // 기본 힐량
        }
    }
}
