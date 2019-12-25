
using UnityEngine;

public class playermove : MonoBehaviour
{
    public CharacterController cont;
    public float speed = 12f;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        cont.Move(move*speed*Time.deltaTime);
    }
}
