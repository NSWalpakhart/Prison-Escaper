using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFinish : MonoBehaviour
{
    CopMovementController _helper;
    [SerializeField] private GameObject FinishText;
    [SerializeField] private int finishScore;
    [SerializeField] private int level;
    private float _score;

    void Start()
    {
        _helper = FindAnyObjectByType<CopMovementController>();

    }

    void Update()
    {
            _score = _helper.GetScore();
            if (_score == (float)finishScore)
            {
            FinishText.SetActive(true);
            StartCoroutine(LoadNextLevelAfterDelay(3f));
            }
    }

    IEnumerator LoadNextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(level);
    }


}
