using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    private Text BestScore;

    void Start()
    {
        GetObjects();
    }

    void GetObjects()
    {
        if (BestScore == null)
        {
            BestScore = GameObject.Find("BestScore").GetComponent<Text>();
        }
    }

    public void UpdateBestScore()
    {
        GetObjects();

        if (DataHandler.instance.fromUser != "" && DataHandler.instance.bestScore != 0)
        {
            BestScore.text = "Best Score: " + DataHandler.instance.fromUser + " with " + DataHandler.instance.bestScore + " points";
        }
        else
        {
            BestScore.text = "No Best Score yet!";
        }
    }
}
