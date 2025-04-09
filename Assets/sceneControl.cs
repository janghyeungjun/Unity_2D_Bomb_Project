using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // 화면 전환 로직
    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 시 다음 화면 또는 초기 화면으로 이동
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // 현재 씬 인덱스 가져오기
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 마지막 화면에서 클릭 시 SampleGame 화면으로 돌아가기
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene("SampleScene"); // SampleGame으로 이동
        }
        else if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene(currentSceneIndex + 1); // 다음 씬 로드
        }
        else
        {
            Debug.LogError("Scene index out of range.");
        }
    }
}
