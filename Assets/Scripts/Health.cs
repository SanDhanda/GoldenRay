using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Health : MonoBehaviour
{

    public int health = 10;
    public Text healthDisplay;
    PhotonView view;

    public GameObject gameOver;


    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC", RpcTarget.All);
    }

    [PunRPC]
    public void TakeDamageRPC()
    {
        if (health > 0)
        {
            health--;
            healthDisplay.text = health.ToString();
            if (health <= 0)
            {
                gameOver.SetActive(true);
                
            }
        }
    }
}
