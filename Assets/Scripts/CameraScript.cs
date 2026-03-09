using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static CameraScript Instance; // Чтобы другие скрипты могли обращатсья к камере
    public float moveSpeed = 5f; // Скорость движения камеры

    private Vector3 targetPosition; // Цель перемещения камеры

    private void Awake()
    {
        // Сохранение ссылки на камеру
        Instance = this;
    }

    private void Start()
    {
        // Начальная цель = текущее положение камеры
        targetPosition = transform.position;
    }

    private void LateUpdate()
    {
        // Осуществление перемещения
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    // Метод вызываеться из триггера комнаты
    public void MoveToRoom(Vector3 roomCenter)
    {
        // Установка новой цели камеры (z всегда одинаковый)
        targetPosition = new Vector3(roomCenter.x, roomCenter.y, transform.position.z);
    }
}
