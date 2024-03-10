using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    [SerializeField] private Text textScore;
    [SerializeField] private GameObject EndTimeText;
    [SerializeField] public int _score;

    [SerializeField]
    private float timeInSeconds = 60;

    private float totalTimeInSeconds;
    private float currentTimeInSeconds;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        UpdateTimerDisplay();
        textScore.text=_score.ToString();
    }

    void StartTimer()
    {
        totalTimeInSeconds = timeInSeconds;
        currentTimeInSeconds = totalTimeInSeconds;

        StartCoroutine(Countdown());
    }
    public void MinusScore()
    {
        _score--;
    }

    IEnumerator Countdown()
    {
        while (currentTimeInSeconds > 0)
        {
            yield return new WaitForSeconds(1);
            currentTimeInSeconds--;

            UpdateTimerDisplay();
        }

        TimerExpired();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTimeInSeconds / 60);
        int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    IEnumerator LoadNextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Menu");
    }
    void TimerExpired()
    {
        EndTimeText.SetActive(true);
        StartCoroutine(LoadNextLevelAfterDelay(2f));
    }
}
