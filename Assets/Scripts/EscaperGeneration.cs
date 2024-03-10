using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EscaperGeneration : MonoBehaviour
{
    [SerializeField] private GameObject escaperObject;
    [SerializeField] private GameObject cop;
    [SerializeField] private float _widthSize = 12.14f;
    [SerializeField] private float _heightSize = 12.14f;
    [SerializeField] private float _escaperSpeed;
    [Range(0, 20)][SerializeField] private int tailSize;
    private GameObject curEscaper;
    private Vector3 randomPos;
    private Vector3 startPos;
    private bool escaperIsRunning = false;
    void Start()
    {
        startPos = new Vector3(38.07f, 1.05f, 0);
        GenerateEscaper();
        SetTailSize();
    }

    public void GenerateEscaper()
    {
        curEscaper = Instantiate(escaperObject, startPos, Quaternion.identity);
        StartCoroutine(MoveEscaperFromStart());
    }

    public IEnumerator MoveEscaperFromStart()
    {
        randomEscPos();
        while (Vector3.Distance(curEscaper.transform.position, randomPos) > 0.1f)
        {
            curEscaper.transform.LookAt(randomPos);
            curEscaper.transform.position = Vector3.MoveTowards(curEscaper.transform.position, randomPos, _escaperSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator EscaperRunAway()
    {
        randomEscPos();
        while (Vector3.Distance(curEscaper.transform.position, randomPos) > 0.1f)
        {
            curEscaper.transform.LookAt(randomPos);
            curEscaper.transform.position = Vector3.MoveTowards(curEscaper.transform.position, randomPos, _escaperSpeed / 5 * Time.deltaTime);
            yield return null;
        }
        if(Vector3.Distance(curEscaper.transform.position, randomPos) <= 0.1f)
        {
            escaperIsRunning = false;
        }
    }

    void randomEscPos()
    {
        randomPos = new Vector3(Random.Range(_widthSize * -1, _widthSize), 1.05f, Random.Range(_heightSize * -1, _heightSize));
    }

    private void SetTailSize()
    {
        for (int i = 0; i < tailSize; i++) {cop.GetComponent<CopMovementController>().AddTailPart(); }
    }

    private void Update()
    {
        if (!curEscaper)
        {
            GenerateEscaper();
            MoveEscaperFromStart();
        }
        else { 
        curEscaper.transform.LookAt(cop.transform.position);
            if(Vector3.Distance( cop.transform.position, curEscaper.transform.position) < 5f && escaperIsRunning==false)
            {
                escaperIsRunning = true;         
                StartCoroutine(EscaperRunAway());
                EscaperRunAway();
            }
            
        }

    }

}
