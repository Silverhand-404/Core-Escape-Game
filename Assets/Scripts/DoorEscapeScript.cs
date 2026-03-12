using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEscapeScript : MonoBehaviour
{
    public GameObject interactText;
    private bool doorEscape = false;
    private bool playerNearby = false;
    // текстуры
    public Texture2D Exit_Button;
    public Texture2D Return_Button;
    // Интерфейс
    private string labelText = "Конец демо уровня №1";
    GUIStyle labelStyle;


    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // скрывание текста, остановка времени
            interactText.SetActive(false);
            Time.timeScale = 0f;

            doorEscape = true;
        }
    }

    // Интерфейс и его параметры
    private void OnGUI()
    {
        if (doorEscape)
        {
            labelStyle = new GUIStyle(GUI.skin.label);
            labelStyle.fontSize = 70;
            labelStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Label(new Rect(Screen.width / 2 - 300,
                Screen.height / 2 - 350, 600, 300), labelText, labelStyle);

            if (GUI.Button(new Rect(Screen.width / 2 - 225,
                      Screen.height / 2 - 100, 200, 200), Return_Button))
            {
                // Перезапуск уровня
                SceneManager.LoadScene(0);
                Time.timeScale = 1f;
            }

            if (GUI.Button(new Rect(Screen.width / 2 + 25,
                      Screen.height / 2 - 100, 200, 200), Exit_Button))
            {
                // Выход из игры
                Application.Quit();
            }
        }
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
