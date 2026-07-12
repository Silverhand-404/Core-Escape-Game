using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEscapeScript : MonoBehaviour
{
    public GameObject interactText;
    private bool playerNearby = false;
    public GameObject End_Screen;


    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // скрывание текста, остановка времени
            interactText.SetActive(false);
            End_Screen.SetActive(true);
            Time.timeScale = 0f;

        }
    }


    public void RestartLevel()
    {
        //Перезапуск уровня
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        // Выход из игры
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            // активация подсказки
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            // скрытие подсказки
            interactText.SetActive(false);
        }
    }
}
