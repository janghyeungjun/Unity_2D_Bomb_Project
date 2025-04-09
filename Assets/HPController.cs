using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    GameObject hp;

    private void Start()
    {
        hp = GameObject.Find("HP");
        if (hp == null)
        {
            Debug.LogError("HP GameObject not found in the scene.");
        }
    }

    public void HpControl()
    {
        hp.GetComponent<Image>().fillAmount -= 0.2f;

        if (hp.GetComponent<Image>().fillAmount < 0.01f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void heel(int healAmount)
    {
        float newFillAmount = hp.GetComponent<Image>().fillAmount + (healAmount / 100f);
        hp.GetComponent<Image>().fillAmount = Mathf.Clamp(newFillAmount, 0f, 1f); // °ª Á¦ÇÑ
    }
}
