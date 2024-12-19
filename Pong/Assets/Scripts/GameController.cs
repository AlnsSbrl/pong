using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool isGameRunning=false;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    [SerializeField]
    Text txtScoreP1;
    [SerializeField]
    Text txtScoreP2;
    [SerializeField]
    GameObject pelota;
    public void addPointP1()
    {
        scoreP1++;
    }
    public void addPointP2() 
    { 
        scoreP2++;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameRunning && Input.GetKeyDown(KeyCode.Space))
        {
            isGameRunning = true;
            pelota.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();        
        }
    }

    private void OnGUI()
    {
        txtScoreP1.text = scoreP1.ToString();
        txtScoreP2.text = scoreP2.ToString();
    }
}
