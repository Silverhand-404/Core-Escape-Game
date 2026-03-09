using UnityEngine;

public class RoomStateScript : MonoBehaviour
{
    // номер комнаты в массиве RoomManager
    public int roomIndex;
    // состояние комнаты
    public GameObject state1;
    public GameObject state2;
    // false = state1 / true = state2
    private bool currentState = false;

    public void ChangeState()
    {
        currentState = !currentState;
        // активация/деактивация объектов
        state1.SetActive(!currentState);
        state2.SetActive(currentState);
    }

}
