using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Speed;
    [SerializeField] private TextMeshProUGUI Coords;
    [SerializeField] private List<Image> Lifes;
    [SerializeField] private GameObject Player;
    [SerializeField] public int Life = 3;


    private Vector2 PPos;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Speed.text = Player.GetComponent<Rigidbody2D>().velocity.magnitude.ToString("0.00") + " m/s";
        PPos = Player.transform.position;
        Coords.text = "X: " + PPos.x.ToString("0.00") + " Y: " + PPos.y.ToString("0.00");

        switch (Life)
        {
            case 0:
                Lifes[0].enabled = false;
                Lifes[1].enabled = false;
                Lifes[2].enabled = false;
                break;
            case 1:
                Lifes[0].enabled= true;
                Lifes[1].enabled = false;
                Lifes[2].enabled = false;
                break;
            case 2:
                Lifes[0].enabled = true;
                Lifes[1].enabled = true;
                Lifes[2].enabled = false;
                break;
            case 3:
                Lifes[0].enabled = true;
                Lifes[1].enabled = true;
                Lifes[2].enabled = true;
                break;
            default:
                break;
        }
    }
}
