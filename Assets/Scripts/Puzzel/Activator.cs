using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private GameObject BDoor;

    [SerializeField] private List<Sprite> Sprites = new List<Sprite>();
    
    public bool active;

    private SpriteRenderer SRender;

    private void Start()
    {
        SRender = GetComponent<SpriteRenderer>();
        SRender.sprite = Sprites[0];
    }


    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            BDoor.GetComponent<DoorMechanism>().Open = true;
            SRender.sprite = Sprites[1];
            active = false;
        }
        else
        {
            SRender.sprite = Sprites[0];
        }
    }
}
