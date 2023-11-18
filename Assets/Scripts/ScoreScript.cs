using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreDisplay;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateScore()
    {
        view.RPC("UpdateScoreRPC", RpcTarget.All);
    }

    [PunRPC]
    public void UpdateScoreRPC()
    {
        score++;
        scoreDisplay.text = score.ToString();
    }
}
