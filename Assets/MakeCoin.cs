using System.Collections;
using UnityEngine;

public class MakeCoin : MonoBehaviour
{
    public GameObject Coinprefab;
    private bool isSpawning = false; // ���� ���� �� ���θ� Ȯ���ϴ� �÷���

    private void Start()
    {
        Debug.Log("MakeCoin script initialized.");
        // �ʱ� ���� ������ ���� �ʿ� �� �ּ� ó��
        // makecoin();
    }

    public void makecoin()
    {
        if (isSpawning)
        {
            Debug.LogWarning("makecoin() is already running. Skipping additional call.");
            return; // �̹� ���� ���̶�� ȣ�� ����
        }

        Debug.Log("makecoin() called");
        StartCoroutine(SpawnCoinWithDelay()); // �ڷ�ƾ���� 3�� ��� �� ����
    }

    private IEnumerator SpawnCoinWithDelay()
    {
        isSpawning = true; // ���� ���� ����
        Debug.Log("Waiting 5 seconds before spawning coin...");
        yield return new WaitForSeconds(3f); // �� ���
        Debug.Log("Spawning coin!");

        int x = Random.Range(-9, 9);
        int y = Random.Range(-4, -2);

        GameObject coin = Instantiate(Coinprefab);
        coin.transform.position = new Vector3(x, y, 0);

        isSpawning = false; // ���� ���� �Ϸ�
    }
}
