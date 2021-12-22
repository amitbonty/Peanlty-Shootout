using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LevelController lc;
    private void Awake()
    {
        lc = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelController>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
            LevelController.GameScore++;
            lc.Updatescore();
            lc.GoalText.text = "GOAL!!";
            StartCoroutine(lc.ShowGoalText());
        }
        else if(other.gameObject.CompareTag("Boundary"))
        {
            lc.GoalText.text = "Out of bounds";
            StartCoroutine(lc.ShowGoalText());
        }
        if(gameObject)
        {
            Destroy(gameObject);
        }
    }
    private void LateUpdate()
    {
        if (gameObject)
        {
            Destroy(gameObject, 3f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Goalkeeper"))
        {
            lc.GoalText.text = "BLOCKED!!";
            StartCoroutine(lc.ShowGoalText());
        }
      
    }
}
