using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject gameOver;

    public float time;

    public FirstPersonShooter myShooter;

    public Text timeText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        spawnNewTarget();
    }

    // Update is called once per frame
    void Update()
    {

        if (time <= 0)
        {
            gameOver.SetActive(true); //if run out of time, activate the game over text
        }
        else {
            time -= Time.deltaTime; 
        }



        timeText.text = "Time : " + Mathf.Round(time); //display time
        scoreText.text = "Score : " + myShooter.score;//display score


    }

    void spawnNewTarget()
    {
        GameObject tatget = Instantiate(targetPrefab); // instantiate a object
        tatget.transform.position = new Vector3(//set its position to a specific range
                            Random.Range(-6,6),
                            -6,
                             0);

        if (time > 0) // if you still have time
        {
            Invoke("spawnNewTarget", time / 30); //keep spawning new cube, but the time gap will become smaller and smaller
        }

    }


    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu"); //load menu scene
    }


}
