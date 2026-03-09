using UnityEngine;

//Singlton - доступен из любого скрипта
public class RoomManagerScript : MonoBehaviour
{
    public static RoomManagerScript Instance;

    // Команаты в порядке индексов
    public RoomStateScript[] rooms;

    private void Awake()
    {
        Instance = this;
    }

    // игрок вошел в комнату с индексом index
    public void PlayerEnteredRoom(int index)
    {
        int left = index - 1; // левая команта
        int right = index + 1; // правая команта

        // проверка существования комнат
        if (left >= 0)
        {
            rooms[left].ChangeState();
        }
        if (right < rooms.Length)
        {
            rooms[right].ChangeState();
        }
    }
}

