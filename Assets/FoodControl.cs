using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodControl : MonoBehaviour
{
    GameObject hp;
    public GameObject heelSound;
    private bool isTriggered = false; // �ߺ� ���� �÷���

    private void Start()
    {
        // HP��� �̸��� GameObject�� ã�� hp�� �Ҵ�
        hp = GameObject.Find("HP");
        if (hp == null)
        {
            Debug.LogError("HP GameObject not found in the scene.");
        }

        // ���� ������ ������ �÷��׸� �ʱ�ȭ
        isTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ߺ� ȣ�� ����
        if (isTriggered) return;

        if (collision.gameObject.tag == "Player")
        {
            isTriggered = true; // �̺�Ʈ ó�� ����

            // �� ó��
            if (hp != null)
            {
                GameObject.Find("SoundController").GetComponent<SoundController>().PlaySound(heelSound, 1f);

                int healAmount = GetHealAmount(); // ���� ���
                hp.GetComponent<HPController>().heel(healAmount); // ���� ����
            }

            // ���ο� ���� ����
            GameObject makeFood = GameObject.Find("NewFood");
            if (makeFood != null)
            {
                makeFood.GetComponent<NewFood>().makefood();
            }
            else
            {
                Debug.LogError("NewFood GameObject not found in the scene.");
            }

            // ���� ���� ����
            Destroy(gameObject);
        }
    }

    private int GetHealAmount()
    {
        // ������ �̸� �Ǵ� �±׿� ���� ���� ����
        switch (gameObject.name)
        {
            case "Apple(Clone)": // Apple ������
                return 10; // ���� 10
            case "orange(Clone)": // Orange ������
                return 20; // ���� 20
            case "stone(Clone)": // Stone ������
                return 5; // ���� ����
            default:
                return 5; // �⺻ ����
        }
    }
}
