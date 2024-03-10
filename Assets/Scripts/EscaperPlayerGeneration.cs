using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscaperPlayerGeneration : MonoBehaviour
{
    [SerializeField] private GameObject escaperObject;
    private GameObject curEscaper;
    private Vector3 startPos;
    void Start()
    {
        startPos = new Vector3(38.07f, 1.05f, 0);
        GenerateEscaper();
    }

    public void GenerateEscaper()
    {
        curEscaper = Instantiate(escaperObject, startPos, Quaternion.identity);
    }




    private void Update()
    {
        if (!curEscaper)
        {
            GenerateEscaper();
        }

    }
}
