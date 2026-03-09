using UnityEngine;
using UnityEngine.UI;
public class CoreInteractScript : MonoBehaviour
{
    public GameObject interactText;
    
    private bool playerNearby = false;
    private PlayerScript player;

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            PickUpCore();
        }
    }

    void PickUpCore()
    {
        // игрок получает ядро
        player.hasCore = true;
        // скрывание текста
        interactText.SetActive(false);
        // скрывание ядра
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            // получение скрипта игрока
            player = other.GetComponent<PlayerScript>();
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
