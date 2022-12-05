using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    public GameObject CreditsPanel;

    private bool isActive;

    private void Update()
    {
        if (isActive == true && Input.anyKey)
        {
            CreditsPanel.SetActive(false);
            isActive = false;
        }
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("1-1");
    }

    public void CreditsScroll()
    {
        CreditsPanel.SetActive(true);
        isActive = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
