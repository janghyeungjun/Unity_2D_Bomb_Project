using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    public GameObject coinSound;

    GameObject score;

    private bool isTriggered = false; // 중복 방지 플래그

    private void Start()
    {
        // AddScore라는 이름의 GameObject를 찾아 score에 할당
        score = GameObject.Find("AddScore");
        if (score == null)
        {
            Debug.LogError("AddScore GameObject not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // 중복 호출 방지
        if (isTriggered) return;

        if (collision.gameObject.tag == "Player")
        {
            isTriggered = true; // 이벤트 처리 시작

            // 점수 추가
            if (score != null)
            {
                GameObject.Find("SoundController").GetComponent<SoundController>().PlaySound(coinSound, 1f);

                score.GetComponent<ScoreControl>().AddScore();
            }

            // 새로운 코인 생성
            GameObject makeCoinObject = GameObject.Find("Makecoin");
            if (makeCoinObject != null)
            {
                makeCoinObject.GetComponent<MakeCoin>().makecoin();
            }
            else
            {
                Debug.LogError("Makecoin GameObject not found in the scene.");
            }

            // 현재 코인 삭제
            Destroy(gameObject);
        }
    }
}
