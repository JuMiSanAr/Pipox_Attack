using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyMode : MonoBehaviour
{
    public GameObject manager;

    public GameObject[] allPipoxes;

    public GameObject character;
    public GameObject pipox;

    public GameObject shootingPoint;

    public AudioSource loop;

    public AudioSource crazyAudio;

    public Light light1;
    public Light light2;
    public Color red;
    Color white = Color.white;

    public Animator OSAYR;

    public Material obstacles;

    public Shader standard;
    public Shader crazy;

    public float tempPipoxSpeed = 0f;

    public int ripoxCount = 0;
    int pipoxLevel = 25;

    public bool isCrazyModeActive = false;
    bool canActivateCrazyMode = true;

    float crazyModeDuration = 24f;
    float thisCrazyModeDuration = 0f;

    double drop = 1.7;

    void Update()
    {     
        if (ripoxCount >= pipoxLevel && canActivateCrazyMode)
        {
            if (drop == 1.7)
            {
                OSAYR.Play("OSAYR");
                crazyAudio.Play();
                manager.GetComponent<GameMusic>().pipoxLoop.Stop();
            }
            
            drop = drop -= 1f * Time.deltaTime;       

            if (drop < 0) 
            {            
            loop.Play();
            isCrazyModeActive = true;
            canActivateCrazyMode = false;
            thisCrazyModeDuration = crazyModeDuration;
            manager.GetComponent<SpawnPipoxes>().InstaSpawn();
            manager.GetComponent<SpawnPipoxes>().pipoxCount = manager.GetComponent<SpawnPipoxes>().pipoxCount + 8;
            manager.GetComponent<SpawnPipoxes>().maxPepoxes = manager.GetComponent<SpawnPipoxes>().maxPepoxes + 100;

            pipox.GetComponent<Pipox>().pipoxSpeed = pipox.GetComponent<Pipox>().pipoxSpeed + 5;
            tempPipoxSpeed = pipox.GetComponent<Pipox>().pipoxSpeed;
            allPipoxes = GameObject.FindGameObjectsWithTag("Pipox");
            for (int i = 0; i < allPipoxes.Length; i++)
                {
                    allPipoxes[i].GetComponent<Pipox>().pipoxSpeed = tempPipoxSpeed;
                }            
            }
        }

        if (isCrazyModeActive)
        {
            thisCrazyModeDuration = thisCrazyModeDuration -= 1f * Time.deltaTime;

            if (thisCrazyModeDuration > 0)
            {
                shootingPoint.GetComponent<Shooting>().firingSpeed = 0.1f;
                character.GetComponent<Character>().moveForce = 650;                
                manager.GetComponent<SpawnPipoxes>().spawnRatio = 0.5f;
                obstacles.shader = crazy;
                light1.color = red;
                light2.color = red;  
            } 
            else
            {                
                ripoxCount = 0;
                pipoxLevel = pipoxLevel + 30;

                isCrazyModeActive = false;
                canActivateCrazyMode = true;

                crazyModeDuration = crazyModeDuration + 24f;
                thisCrazyModeDuration = 1;

                obstacles.shader = standard;

                loop.Stop();
                drop = 1.7;

                light1.color = white;
                light2.color = white;

                shootingPoint.GetComponent<Shooting>().firingSpeed = 0.5f;
                character.GetComponent<Character>().moveForce = 550;
                manager.GetComponent<SpawnPipoxes>().spawnRatio = 1f;

                pipox.GetComponent<Pipox>().pipoxSpeed = pipox.GetComponent<Pipox>().pipoxSpeed - 2;
                tempPipoxSpeed = pipox.GetComponent<Pipox>().pipoxSpeed;

                allPipoxes = GameObject.FindGameObjectsWithTag("Pipox");
                for (int i = 0; i < allPipoxes.Length; i++)
                {
                    allPipoxes[i].GetComponent<Pipox>().pipoxSpeed = tempPipoxSpeed;
                    Debug.Log("Pipox " + i + " speed is " + tempPipoxSpeed);
                }

                manager.GetComponent<GameMusic>().pipoxLoop.Play();

                manager.GetComponent<SpawnPipoxes>().maxPepoxes = manager.GetComponent<SpawnPipoxes>().maxPepoxes + 10 - 100;
            }
        }        
    }
}
