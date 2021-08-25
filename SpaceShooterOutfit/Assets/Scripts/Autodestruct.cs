using UnityEngine;

public class Autodestruct : MonoBehaviour
{
    [SerializeField] private float seconds;
    private void Start()
    {
        Invoke("destroySelf", seconds);
    }

    private void destroySelf()
    {
        Destroy(gameObject);
    }
}
