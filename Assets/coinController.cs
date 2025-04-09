using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    public GameObject coinSound;

    GameObject score;

    private bool isTriggered = false; // �ߺ� ���� �÷���

    private void Start()
    {
        // AddScore��� �̸��� GameObject�� ã�� score�� �Ҵ�
        score = GameObject.Find("AddScore");
        if (score == null)
        {
            Debug.LogError("AddScore GameObject not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // �ߺ� ȣ�� ����
        if (isTriggered) return;

        if (collision.gameObject.tag == "Player")
        {
            isTriggered = true; // �̺�Ʈ ó�� ����

            // ���� �߰�
            if (score != null)
            {
                GameObject.Find("SoundController").GetComponent<SoundController>().PlaySound(coinSound, 1f);

                score.GetComponent<ScoreControl>().AddScore();
            }

            // ���ο� ���� ����
            GameObject makeCoinObject = GameObject.Find("Makecoin");
            if (makeCoinObject != null)
            {
                makeCoinObject.GetComponent<MakeCoin>().makecoin();
            }
            else
            {
                Debug.LogError("Makecoin GameObject not found in the scene.");
            }

            // ���� ���� ����
            Destroy(gameObject);
        }
    }
}
