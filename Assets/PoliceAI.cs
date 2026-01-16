using UnityEngine;

public class PoliceAI : MonoBehaviour
{
    public Transform hrac;
    public float rychlostPolicie = 28f; // O trochu pomalejší než hráè, aby šlo klièkovat

    void FixedUpdate()
    {
        if (hrac != null)
        {
            // Policie se vždy dívá na hráèe
            transform.LookAt(hrac);
            // A jede pøímo za ním
            transform.Translate(Vector3.forward * rychlostPolicie * Time.deltaTime);
        }
    }

    // Co se stane, když tì chytí?
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Hrac")
        {
            Debug.Log("GAME OVER! Chytili tì!");
            Time.timeScale = 0; // Zastaví hru
        }
    }
}