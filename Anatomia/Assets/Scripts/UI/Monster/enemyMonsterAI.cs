using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMonsterAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public Animator aiAnim;
    int randNum;
    public Transform playerTrans, aiTrans, randDest1, randDest2, randDest3, randDest4, randDest5, randDest6, randDest7, randDest8;
    public bool walking, chasing, idel;
    public Vector3 dest;

    private void Start()
    {
        walking = true;
        randNum = Random.Range(0, 8);
        aiAnim.SetTrigger("walk");
        if(randNum == 0)
        {
            dest = randDest1.position;
        }
        if (randNum == 1)
        {
            dest = randDest2.position;
        }
        if (randNum == 2)
        {
            dest = randDest3.position;
        }
        if (randNum == 3)
        {
            dest = randDest4.position;
        }
        if (randNum == 4)
        {
            dest = randDest5.position;
        }
        if (randNum == 5)
        {
            dest = randDest6.position;
        }
        if (randNum == 6)
        {
            dest = randDest7.position;
        }
        if (randNum == 7)
        {
            dest = randDest8.position;
        }
    }

    private void Update()
    {
        if(walking == true)
        {
            ai.destination = dest;
            ai.speed = 3;
        }
        if(chasing == true)
        {
            dest = playerTrans.position;
            ai.destination = dest;
            ai.speed = 6;
        }
    }

}
