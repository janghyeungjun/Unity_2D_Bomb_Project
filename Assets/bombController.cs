using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombController : MonoBehaviour
{
    public GameObject bombSound;
    GameObject hp; // Player�� HP�� �����ϴ� GameObject
    public GameObject shellExplosionPrefab; // �ܺο��� ������ ���� ����Ʈ ������

    private void Start()
    {
        if (hp == null)
        {
            hp = GameObject.Find("HP");
            if (hp == null)
            {
                Debug.LogError("HP GameObject not found!");
            }
        }

        if (shellExplosionPrefab == null)
        {
            Debug.LogError("Shell Explosion Prefab not assigned!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bomb(Clone)" )
        {
            return; // �ƹ� ���۵� ���� �ʰ� ����
        }

        if (collision.gameObject.tag == "Player")
        {
            // Player�� HP�� ���ҽ�Ű�� �޼��� ȣ��
            if (hp != null)
            {

                GameObject.Find("SoundController").GetComponent<SoundController>().PlaySound(bombSound, 1f);
                hp.GetComponent<HPController>().HpControl();
            }

            // ���� ����Ʈ�� ���� ��ġ�� ���� �� ���
            GameObject explosion = Instantiate(shellExplosionPrefab, transform.position, Quaternion.identity);
            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }

            // 0.5�� �ڿ� ����Ʈ ����
            Destroy(explosion, 0.5f);

            // bomb ����
            Destroy(gameObject);
        }
        else
        {
            // Player�� �ƴ� �ٸ� ������Ʈ�� �浹���� ��� ��ź�� ����
            Destroy(gameObject);
        }
    }
}
