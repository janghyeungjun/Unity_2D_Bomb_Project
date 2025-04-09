using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombController : MonoBehaviour
{
    public GameObject bombSound;
    GameObject hp; // Player의 HP를 관리하는 GameObject
    public GameObject shellExplosionPrefab; // 외부에서 연결할 폭발 이펙트 프리팹

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
            return; // 아무 동작도 하지 않고 종료
        }

        if (collision.gameObject.tag == "Player")
        {
            // Player의 HP를 감소시키는 메서드 호출
            if (hp != null)
            {

                GameObject.Find("SoundController").GetComponent<SoundController>().PlaySound(bombSound, 1f);
                hp.GetComponent<HPController>().HpControl();
            }

            // 폭발 이펙트를 현재 위치에 생성 및 재생
            GameObject explosion = Instantiate(shellExplosionPrefab, transform.position, Quaternion.identity);
            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }

            // 0.5초 뒤에 이펙트 삭제
            Destroy(explosion, 0.5f);

            // bomb 삭제
            Destroy(gameObject);
        }
        else
        {
            // Player가 아닌 다른 오브젝트와 충돌했을 경우 폭탄만 삭제
            Destroy(gameObject);
        }
    }
}
