using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public TextMeshProUGUI GoalText;
    public GameObject PausePanel;
    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    GameObject GamePointPrefab;
    [SerializeField]
    float ballForce;
    private GameObject ballInstance;
    private Vector3 touchStart;
    private Vector3 touchEnd;
    private float temp;
    public int count;
    private bool checkBall = false;
    public static int GameScore=0;


    float zDepth = 250f;
    float minSwipeDistance = 5f;
    private void Start()
    {
        temp = ballForce;
        CreateBall();
    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
            {
                touchStart = Input.mousePosition;
            }

            Vector3 hitPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDepth);
            hitPos = Camera.main.ScreenToWorldPoint(hitPos);
        if (ballInstance != null)
        {
            ballInstance.transform.LookAt(hitPos);
        }
            if (Input.GetMouseButton(0))
            {
                ballForce += 0.1f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                touchEnd = Input.mousePosition;

            }
        }
        private void LateUpdate()
        {
            if (Input.GetMouseButtonUp(0)&&ballInstance)
            {
                if (Vector3.Distance(touchStart, touchEnd) > minSwipeDistance)
                {
                    ballInstance.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * ballForce, ForceMode.Impulse);
                    ballForce = temp;
                }
            }

        }
        public void CreateBall()
    {  
        if(!CheckForBall())
        {
            ballInstance = Instantiate(ballPrefab, ballPrefab.transform.position, Quaternion.identity) as GameObject;
            count++;
        }
        }
    private bool CheckForBall()
    {
       checkBall= GameObject.FindGameObjectWithTag("Ball");
       return checkBall;
    }
   
    public IEnumerator ShowGoalText()
    {
        GoalText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        GoalText.gameObject.SetActive(false);

    }
    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Updatescore()
    {
        Instantiate(GamePointPrefab, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
    }

}
