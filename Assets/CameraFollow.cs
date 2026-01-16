using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cil; // Sem pøetáhneš Hráèe
    public Vector3 offset = new Vector3(0, 5, -10);
    public float plynulost = 5f;

    void LateUpdate()
    {
        Vector3 zadouciPozice = cil.position + cil.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, zadouciPozice, plynulost * Time.deltaTime);
        transform.LookAt(cil);
    }
}