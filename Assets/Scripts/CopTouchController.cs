using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CopTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool m_IsPressed;
    public CopMovementController snakeMovementController; 

    public void OnPointerDown(PointerEventData eventData)
    {
        m_IsPressed = true;
        StartCoroutine(Execute());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_IsPressed = false;
    }

    private IEnumerator Execute()
    {
        while (m_IsPressed)
        {
            if (gameObject.name.Contains("Left"))
            {
                snakeMovementController.LeftTouchMove();
            }
            else if (gameObject.name.Contains("Right"))
            {
                snakeMovementController.RightTouchMove();
            }

            yield return null; 
        }
    }
}
