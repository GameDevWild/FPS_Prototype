using UnityEngine;

public class DoorKey : MonoBehaviour
{
   

    void Update()
    {
        //Mantenemos la tarjeta rotando en la posición Z
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }
}
