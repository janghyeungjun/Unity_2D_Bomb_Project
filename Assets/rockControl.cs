using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockControl : MonoBehaviour
{
    public GameObject rock; // 생성할 오브젝트
    private float spawnInterval = 3f; // 생성 간격
    private float timer = 0f; // 타이머

    void Update()
    {
        // 타이머를 증가시켜 일정 간격마다 오브젝트 생성
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRock();
            timer = 0f; // 타이머 초기화
        }
    }

    private void SpawnRock()
    {
        if (rock == null)
        {
            Debug.LogError("rock 변수가 설정되지 않았습니다! Inspector에서 확인하세요.");
            return;
        }

        int x = Random.Range(-9, 9);
        int y = Random.Range(-4, -1);

        GameObject spawnedRock = Instantiate(rock);
        spawnedRock.transform.position = new Vector3(x, y, 0);

        // y값이 -3일 경우 크기 변경
        if (y == -3)
        {
            spawnedRock.transform.localScale = new Vector3(0.1f, 0.2f, 2f); // 원하는 크기로 변경
        }
        else if (y == -4)
        {
            spawnedRock.transform.localScale = new Vector3(0.04f, 0.03f, 2f); // 원하는 크기로 변경
        }

        // 4초 후에 삭제
        Destroy(spawnedRock, 4f);
    }

}
