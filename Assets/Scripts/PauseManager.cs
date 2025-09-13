using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public TextMeshProUGUI countdownText;

    private bool isPaused = false;
    private Coroutine countdownRoutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (countdownRoutine != null)
            {
                // Cancel countdown and reopen pause menu
                StopCoroutine(countdownRoutine);
                countdownRoutine = null;
                countdownText.gameObject.SetActive(false);
                PauseGame();
            }
            else if (isPaused)
            {
                ResumeWithCountdown();   // ? ensure countdown always runs
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ResumeWithCountdown()
    {
        if (countdownRoutine == null)
        {
            countdownRoutine = StartCoroutine(CountdownAndResume());
        }
    }

    private IEnumerator CountdownAndResume()
    {
        // Close pause menu
        pauseMenuUI.SetActive(false);

        countdownText.gameObject.SetActive(true);

        int count = 3;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            Debug.Log("Count: " + count);  // ?? debug
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        countdownText.text = "GO!";
        Debug.Log("GO!"); // ?? debug
        yield return new WaitForSecondsRealtime(0.5f);

        countdownText.gameObject.SetActive(false);

        countdownRoutine = null;
        ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
