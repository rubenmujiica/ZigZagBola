using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorBolaNivel3 : MonoBehaviour
{

    public Camera camara;
    public GameObject suelo;
    public GameObject estrella;
    public float velocidad = 5.0f;
    public Text Contador;
    public GameObject obstaculo;
    public GameObject piedramalvada;

    private Vector3 offset;
    private float ValX, ValZ;
    private Vector3 DireccionActual;
    private int totalEstrellas = 0;

    // Start is called before the first frame update
    void Start()
    {
        offset = camara.transform.position - transform.position;
        CrearSueloInicial();
        DireccionActual = Vector3.forward;
        
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position = transform.position + offset;
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            DireccionActual = Vector3.forward;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            DireccionActual = Vector3.right;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            DireccionActual = Vector3.left;
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            DireccionActual = Vector3.back;
        }

        transform.Translate(DireccionActual * velocidad * Time.deltaTime);
    }

    

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Suelo")
        {
            estrella.gameObject.SetActive(true);
            StartCoroutine(BorrarSuelo(other.gameObject));
            
        }
    }


    IEnumerator BorrarSuelo(GameObject suelo)
    {
        float aleatorio = Random.Range(0.0f, 1.0f);
        if(aleatorio > 0.5)
        {
            ValX += 8.0f;
        }
        else{
            ValZ += 10.0f;
        }
    
        Instantiate(suelo, new Vector3(ValX, 0, ValZ), Quaternion.identity);

        float aleatorio2 = Random.Range(0.0f, 1.0f);
        if(aleatorio2 > 0.5)
        {
            yield return new WaitForSeconds(2);
            Instantiate(estrella, new Vector3(ValX -3, 1.5f, ValZ-3), estrella.transform.rotation);
        }
        else{
            yield return new WaitForSeconds(2);
            Instantiate(estrella, new Vector3(ValX + 3, 1.5f, ValZ + 3), estrella.transform.rotation);
        }

        float aleatorio3 = Random.Range(0.0f, 1.0f);
        if(aleatorio3 > 0.5)
        {
            yield return new WaitForSeconds(1);
            Instantiate(obstaculo, new Vector3(ValX, 1.5f, ValZ), obstaculo.transform.rotation);
        }
        else{
            yield return new WaitForSeconds(1);
            Instantiate(obstaculo, new Vector3(ValX +2, 1.5f, ValZ +2), obstaculo.transform.rotation);
        }

        float aleatorio4 = Random.Range(0.0f, 1.0f);
        if(aleatorio4 > 0.5)
        {
            yield return new WaitForSeconds(1);
            Instantiate(piedramalvada, new Vector3(ValX-2, 2.0f, ValZ-2), piedramalvada.transform.rotation);
        }
        else{
            yield return new WaitForSeconds(1);
            Instantiate(piedramalvada, new Vector3(ValX +2, 2.0f, ValZ +2), piedramalvada.transform.rotation);
        }

        yield return new WaitForSeconds(3);
        suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        suelo.gameObject.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2);
        Destroy(suelo);
    }
    

    void CambiarDireccion()
    {
        if (DireccionActual == Vector3.forward)
        {
            DireccionActual = Vector3.right;
        }
        else
        {
            if(DireccionActual == Vector3.right)
            {
                DireccionActual = Vector3.left;
            }
            else{
                DireccionActual = Vector3.forward;
            }
        }
    }

    void CrearSueloInicial()
    {
        for(int i = 0; i < 3;i++)
        {
            ValZ += 6.0f;
            Instantiate(suelo, new Vector3(ValX, 0, ValZ), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Estrella"))
        {
            totalEstrellas++;
            Contador.text = "Estrellas: " + totalEstrellas;
            Destroy(other.gameObject);
            
            }

        if (totalEstrellas == 13){
            SceneManager.LoadScene("Victoria");
        }
    }

}

