using UnityEngine;
using System.Collections;

public class RoomTriggerScript : MonoBehaviour
{
    // индекс комнаты к которой принадлежит триггер
    public int roomIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверка игрока по тегу
        if (other.CompareTag("Player"))
        {
            // Вызов функции (движение камеры в центр комнаты)
            CameraScript.Instance.MoveToRoom(transform.parent.position);

            // проверка что игрок существует и держит ядро
            PlayerScript player = other.GetComponent<PlayerScript>();
            if (player != null && player.hasCore)
            {
                // сообщение менеджеру что игрок вошел в комнату (С задержкой)
                StartCoroutine(ChangeRoomSate());
            }
        }
    }

    IEnumerator ChangeRoomSate()
    {
        yield return new WaitForSeconds(0.5f); //задержка
        if (RoomManagerScript.Instance != null)
        {
            RoomManagerScript.Instance.PlayerEnteredRoom(roomIndex);
        }
    }
}
