using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockControl : MonoBehaviour
{
    public GameObject rock; // ������ ������Ʈ
    private float spawnInterval = 3f; // ���� ����
    private float timer = 0f; // Ÿ�̸�

    void Update()
    {
        // Ÿ�̸Ӹ� �������� ���� ���ݸ��� ������Ʈ ����
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRock();
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    private void SpawnRock()
    {
        if (rock == null)
        {
            Debug.LogError("rock ������ �������� �ʾҽ��ϴ�! Inspector���� Ȯ���ϼ���.");
            return;
        }

        int x = Random.Range(-9, 9);
        int y = Random.Range(-4, -1);

        GameObject spawnedRock = Instantiate(rock);
        spawnedRock.transform.position = new Vector3(x, y, 0);

        // y���� -3�� ��� ũ�� ����
        if (y == -3)
        {
            spawnedRock.transform.localScale = new Vector3(0.1f, 0.2f, 2f); // ���ϴ� ũ��� ����
        }
        else if (y == -4)
        {
            spawnedRock.transform.localScale = new Vector3(0.04f, 0.03f, 2f); // ���ϴ� ũ��� ����
        }

        // 4�� �Ŀ� ����
        Destroy(spawnedRock, 4f);
    }

}
