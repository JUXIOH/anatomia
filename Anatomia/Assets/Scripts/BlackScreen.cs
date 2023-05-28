using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    public Animator anim;
    public GameObject screenToLoad;

    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(finished == true)
        {
            screenToLoad.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    void isFinished()
    {
        finished = true;
    }
}
