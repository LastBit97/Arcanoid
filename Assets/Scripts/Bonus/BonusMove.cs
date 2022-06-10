using UnityEngine;

public class BonusMove : MonoBehaviour
{
    private const float Speed = 2f;

    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
}
