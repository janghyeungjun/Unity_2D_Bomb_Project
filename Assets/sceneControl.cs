using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // ȭ�� ��ȯ ����
    void Update()
    {
        // ���콺 ���� ��ư Ŭ�� �� ���� ȭ�� �Ǵ� �ʱ� ȭ������ �̵�
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // ���� �� �ε��� ��������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ������ ȭ�鿡�� Ŭ�� �� SampleGame ȭ������ ���ư���
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene("SampleScene"); // SampleGame���� �̵�
        }
        else if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene(currentSceneIndex + 1); // ���� �� �ε�
        }
        else
        {
            Debug.LogError("Scene index out of range.");
        }
    }
}
