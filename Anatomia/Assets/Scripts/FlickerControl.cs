using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    public bool isFlickering = false;
    public float rangeTop = 0.7f;
    public float rangeBot = 0.7f;
    public float timeDelay;

    public GameObject lightGO;
    public GameObject OnGO;
    public GameObject OffGO;

    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering=true;
        lightGO.gameObject.GetComponent<Light>().enabled = false;
        OnGO.gameObject.SetActive(false);
        OffGO.gameObject.SetActive(true);
        timeDelay = Random.Range(0.01f, rangeTop);
        yield return new WaitForSeconds(timeDelay);
        lightGO.gameObject.GetComponent<Light>().enabled = true;
        OnGO.gameObject.SetActive(true);
        OffGO.gameObject.SetActive(false);
        timeDelay = Random.Range(0.01f, rangeBot);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
