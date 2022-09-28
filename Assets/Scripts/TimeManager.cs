using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool gameFinished = false;
    public bool gameOver = false;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float levelFinished = 7f;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();
    public GameObject startButton;


    void Start()
    {

        startButton = GameObject.FindWithTag("StartButton");
        startButton.SetActive(true);

        Time.timeScale = 0;


    }


    void Update()
    {

        if (gameOver == false && gameFinished == false)
        {
            UpdateTheTimer();
        }

        if (Time.timeSinceLevelLoad >= levelFinished && gameOver == false)
        {
            gameFinished = true;
            winPanel.SetActive(true);
            losePanel.SetActive(false);
            UpdateObjectList("Enemy");
            UpdateObjectList("Objects");
            foreach (GameObject allObjects in destroyAfterGame)
            {
                Destroy(allObjects);
            }
        }

        if (gameOver == true)
        {

            winPanel.SetActive(false);
            losePanel.SetActive(true);
            UpdateObjectList("Enemy");
            UpdateObjectList("Objects");
            foreach (GameObject allObjects in destroyAfterGame)
            {
                Destroy(allObjects);
            }
        }
    }
    private void UpdateObjectList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));

    }
    private void UpdateTheTimer()
    {
        timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
    }
    public void StartButton()
    {
        Time.timeScale = 1;

        startButton.SetActive(false);

    }
}
