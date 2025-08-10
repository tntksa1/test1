using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [SerializeField] private Canvas deathCanvas;
    [SerializeField] private Button reloadButton;
    [SerializeField] private Button exitButton;


    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Button resumeButton;

    private bool isPaused = false;

    private void Awake()
    {
        // Initialize all canvases
        deathCanvas.enabled = false;
        pauseCanvas.enabled = false;

        // Setup button listeners
        reloadButton.onClick.AddListener(ReloadScene);
        exitButton.onClick.AddListener(ExitGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    private void Update()
    {
        // Toggle pause when ESC is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ShowDeathScreen()
    {
        deathCanvas.enabled = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void PauseGame()
    {
        isPaused = true;
        pauseCanvas.enabled = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ResumeGame()
    {
        isPaused = false;
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Enm")) 
        {
            ShowDeathScreen();
        }
    }
}