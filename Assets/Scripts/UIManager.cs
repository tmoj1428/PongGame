using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public EventSystemController eventSys;
    public Text heartsText;
    public Button restartButton;

    void Start()
    {
        eventSys.onBallLose.AddListener(UpdatePlayerHearts);
        eventSys.onCanPlay.AddListener(ReloadSceneButton);
    }

    // Update is called once per frame
    void UpdatePlayerHearts()
    {
        int Hearts = int.Parse(heartsText.text) - 1;
        if (Hearts >= 0)
            heartsText.text = Hearts.ToString();
    }

    private void ReloadSceneButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
