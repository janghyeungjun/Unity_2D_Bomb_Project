using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFood : MonoBehaviour
{
    [SerializeField] private GameObject[] foodItems;// ���� �� ���� ��� �迭
    private bool isSpawning = false; // ���� ���� �� ���θ� Ȯ���ϴ� �÷���

    private void Start()
    {
        // �迭�� ��� �ִ��� Ȯ�� (������)
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
            return; // �̹� ���� ���̶�� ȣ�� ����
        }

        Debug.Log("makefood() called");
        StartCoroutine(SpawnFoodWithDelay()); // �ڷ�ƾ���� 2�� ��� �� ����
    }

    private IEnumerator SpawnFoodWithDelay()
    {
        isSpawning = true; // ���� �� ���� ����
        Debug.Log("Waiting 2 seconds before spawning food...");
        yield return new WaitForSeconds(7f); // 10�� �Ŀ� ���� ����
        Debug.Log("Spawning food!");

        // ���� ��ġ
        int x = Random.Range(-9, 9);
        int y = Random.Range(-4, -2);

        // �������� ���� ����
        int randomIndex = Random.Range(0, foodItems.Length); // �迭 �ε��� ����
        GameObject selectedFood = foodItems[randomIndex]; // ���õ� ����

        // ���� ����
        GameObject food = Instantiate(selectedFood);
        food.transform.position = new Vector3(x, y, 0);

        isSpawning = false; // ���� �Ϸ� ���� ����
    }
}
