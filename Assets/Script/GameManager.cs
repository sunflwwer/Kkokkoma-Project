using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stageIndex;
    public int health;
    public GameObject[] Stages;
    public PlayerMove player;


    public float Level(int score)
    {
        int defaultSpeed = -7;
        int increSpeed = (score * -1) / 120;
        if (increSpeed <=-6)
            increSpeed = -5;

        return defaultSpeed + increSpeed;
    }

    public void NextStage()
    {
       /* //Change Stage
        if(stageIndex<Stages.Length-1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
        }

        else*/
        { //Game Clear
            //Time.timeScale = 0; 

        }

    }
/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
            //health--;
    }*/

    void PlayerReposition()
    {
        player.transform.position=new Vector3(-8 ,-4.9f,0);
        //player.VelocityZero();
    }
}
