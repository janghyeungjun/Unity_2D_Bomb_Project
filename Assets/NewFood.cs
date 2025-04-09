using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFood : MonoBehaviour
{
    [SerializeField] private GameObject[] foodItems;// 과일 및 돌을 담는 배열
    private bool isSpawning = false; // 코인 생성 중 여부를 확인하는 플래그

    private void Start()
    {
        // 배열이 비어 있는지 확인 (디버깅용)
        if (foodItems == null || foodItems.Length == 0)
        {
            Debug.LogError("No food items assigned to foodItems array.");
        }
    }

    public void makefood()
    {
        if (isSpawning)
        {
            Debug.LogWarning("makefood() is already running.");
            return; // 이미 실행 중이라면 호출 무시
        }

        Debug.Log("makefood() called");
        StartCoroutine(SpawnFoodWithDelay()); // 코루틴으로 2초 대기 후 생성
    }

    private IEnumerator SpawnFoodWithDelay()
    {
        isSpawning = true; // 생성 중 상태 설정
        Debug.Log("Waiting 2 seconds before spawning food...");
        yield return new WaitForSeconds(7f); // 10초 후에 과일 생성
        Debug.Log("Spawning food!");

        // 랜덤 위치
        int x = Random.Range(-9, 9);
        int y = Random.Range(-4, -2);

        // 랜덤으로 음식 선택
        int randomIndex = Random.Range(0, foodItems.Length); // 배열 인덱스 선택
        GameObject selectedFood = foodItems[randomIndex]; // 선택된 음식

        // 음식 생성
        GameObject food = Instantiate(selectedFood);
        food.transform.position = new Vector3(x, y, 0);

        isSpawning = false; // 생성 완료 상태 설정
    }
}
