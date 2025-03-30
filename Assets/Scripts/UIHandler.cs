using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandler : MonoBehaviour
{
    private TMP_InputField inputField;
    private TextMeshProUGUI bestScoreText;
    private GameObject errorObject;
    private bool onError;

    private string username;

    private void Start()
    {
        inputField = GameObject.Find("Username").GetComponent<TMP_InputField>();
        errorObject = GameObject.Find("NameError").gameObject;
        bestScoreText = GameObject.Find("Best Score").GetComponent<TextMeshProUGUI>();

        errorObject.SetActive(false);

        LoadBestScore();

        inputField.onEndEdit.AddListener(SetUsername);
    }

    public void LoadBestScore()
    {
        if (DataHandler.instance.fromUser != "" && DataHandler.instance.bestScore != 0)
        {
            bestScoreText.text = "Best Score: " + DataHandler.instance.fromUser + " with " + DataHandler.instance.bestScore + " points";
        } else
        {
            bestScoreText.text = "No Best Score yet!";
        }
    }

    private void SetUsername(string name)
    {
        username = name;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void PlayGame()
    {
        if (username != null && !onError)
        {
            DataHandler.instance.currentUser = username;
            SceneManager.LoadScene(1);
            return;
        }

        StartCoroutine(ShowError());
    }

    IEnumerator ShowError()
    {
        errorObject.SetActive(true);
        onError = true;

        yield return new WaitForSeconds(2);

        errorObject.SetActive(false);
        onError = false;
    }
}
