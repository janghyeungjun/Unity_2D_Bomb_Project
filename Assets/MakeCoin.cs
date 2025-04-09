using System.Collections;
using UnityEngine;

public class MakeCoin : MonoBehaviour
{
    public GameObject Coinprefab;
    private bool isSpawning = false; // 코인 생성 중 여부를 확인하는 플래그

    private void Start()
    {
        Debug.Log("MakeCoin script initialized.");
        // 초기 생성 방지를 위해 필요 시 주석 처리
        // makecoin();
    }

    public void makecoin()
    {
        if (isSpawning)
        {
            Debug.LogWarning("makecoin() is already running. Skipping additional call.");
            return; // 이미 실행 중이라면 호출 무시
        }

        Debug.Log("makecoin() called");
        StartCoroutine(SpawnCoinWithDelay()); // 코루틴으로 3초 대기 후 생성
    }

    private IEnumerator SpawnCoinWithDelay()
    {
        isSpawning = true; // 코인 생성 시작
        Debug.Log("Waiting 5 seconds before spawning coin...");
        yield return new WaitForSeconds(3f); // 초 대기
        Debug.Log("Spawning coin!");

        int x = Random.Range(-9, 9);
        int y = Random.Range(-4, -2);

        GameObject coin = Instantiate(Coinprefab);
        coin.transform.position = new Vector3(x, y, 0);

        isSpawning = false; // 코인 생성 완료
    }
}
