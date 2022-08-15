using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextInfo : MonoBehaviour
{

    [SerializeField]
    Text m_Text;

    public void SetText(string text)
    {
        m_Text.text = text;
    }
    private void OnEnable()
    {
        StartCoroutine(bounce());
    }

    IEnumerator bounce()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }
}
