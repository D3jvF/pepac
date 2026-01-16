using UnityEngine;

public class CarController : MonoBehaviour
{
    public float rychlost = 15f;
    public float silaZatoceni = 100f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Tohle je klíèové - auto se nepøevrátí
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        float vpredu = Input.GetAxis("Vertical"); // W a S
        float zatacka = Input.GetAxis("Horizontal"); // A a D

        // Pohyb vpøed/vzad
        Vector3 pohyb = transform.forward * vpredu * rychlost * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + pohyb);

        // Zatáèení jen když se hýbeš
        if (vpredu != 0)
        {
            float otacka = zatacka * silaZatoceni * Time.fixedDeltaTime;
            Quaternion naseRotace = Quaternion.Euler(0f, otacka, 0f);
            rb.MoveRotation(rb.rotation * naseRotace);
        }
    }
}