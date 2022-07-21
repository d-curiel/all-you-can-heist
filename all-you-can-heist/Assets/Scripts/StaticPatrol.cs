using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPatrol : MonoBehaviour
{
    bool m_Rotating;
    bool m_InitPatrol;

    [SerializeField]
    float m_TimePatrol = 8f;


    void Awake()
    {
        m_Rotating = false;
        m_InitPatrol = true;
    }


    private void FixedUpdate()
    {
        if (!m_Rotating)
        {
            if (m_InitPatrol)
            {
                StartCoroutine(rotateObject(new Vector3(0, 90, 0), m_TimePatrol));
            } else
            {
                StartCoroutine(rotateObject(new Vector3(0, -90, 0), m_TimePatrol));
            }
        }
    }

    IEnumerator rotateObject(Vector3 eulerAngles, float duration)
    {
        if (m_Rotating)
        {
            yield break;
        }
        m_Rotating = true;

        Vector3 newRot = gameObject.transform.eulerAngles + eulerAngles;

        Vector3 currentRot = gameObject.transform.eulerAngles;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObject.transform.eulerAngles = Vector3.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        m_Rotating = false;
        m_InitPatrol = !m_InitPatrol;
    }

}
