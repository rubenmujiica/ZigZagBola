using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitarVidas1 : MonoBehaviour
{
    public GameObject player;
    public int vida = 3;
    private GameObject[] corazonesVida = new GameObject[3]; 
    // Start is called before the first frame update
    void Start()
    {
        corazonesVida[0] = GameObject.Find("Corazon Vida 1");
        corazonesVida[1] = GameObject.Find("Corazon Vida 2");
        corazonesVida[2] = GameObject.Find("Corazon Vida 3");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -10){
            SceneManager.LoadScene("Nivel2");
        }

        if(vida == 3)
        {
            corazonesVida[0].SetActive(true);
            corazonesVida[1].SetActive(true);
            corazonesVida[2].SetActive(true);
        }
        else if(vida == 2)
        {
            corazonesVida[0].SetActive(false);
            corazonesVida[1].SetActive(true);
            corazonesVida[2].SetActive(true);
        }
        else if(vida == 1)
        {
            corazonesVida[0].SetActive(false);
            corazonesVida[1].SetActive(false);
            corazonesVida[2].SetActive(true);
        }
        else
        {
            corazonesVida[0].SetActive(false);
            corazonesVida[1].SetActive(false);
            corazonesVida[2].SetActive(false);

            SceneManager.LoadScene("Game over");

        }
        
    }

        private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Enemigo"))
        {
            vida --;
            Destroy(other.gameObject);
        }

    }


}
