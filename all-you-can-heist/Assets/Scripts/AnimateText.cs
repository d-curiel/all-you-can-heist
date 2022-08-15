using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateText : MonoBehaviour
{

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
