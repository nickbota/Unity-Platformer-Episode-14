using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private AudioClip gameOverSound;

    private void Awake()
    {
        PauseGame(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseUI.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

    //Game over function
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    //Pause menu functions
    public void PauseGame(bool _status)
    {
        pauseUI.SetActive(_status);
        Time.timeScale = System.Convert.ToInt32(!_status);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ChangeSoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(20);
        //Update UI text
    }
    public void ChangeMusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(20);
        //Update UI text
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}