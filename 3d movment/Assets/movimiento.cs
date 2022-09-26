using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float velocidad;
    public bool tocoElPiso;
    public float salto;
    public Text score;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tocoElPiso = true;
    }

    // Update is called once per frame

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    public int puntaje;


    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movmentX = new Vector3(inputX, 0, 0);
        Vector3 movmentY = new Vector3(0, 0, inputY);

        rb.transform.Translate(movmentX * velocidad * Time.deltaTime);
        rb.transform.Translate(movmentY * velocidad * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space)&&tocoElPiso)
        {
            rb.AddForce(Vector3.up * salto * Time.deltaTime);
            tocoElPiso = false;
        }

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
       // float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(/*v*/0, h, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            tocoElPiso = true;
        }
        if (collision.gameObject.CompareTag("item"))
        {
            Destroy(collision.gameObject);
            puntaje ++;
            score.text = ("PUNTUACION: " + puntaje);
        }
    }
}
