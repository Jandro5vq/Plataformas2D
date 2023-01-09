using UnityEngine;

public class GunLogic : MonoBehaviour
{
    [SerializeField] private GameObject Gun;
    [SerializeField] private SpriteRenderer HelpText;
    [SerializeField] private int FadeTime;
    [SerializeField] private bool Carry = false;

    private Collider2D StandColl;
    private SpriteRenderer GunSprite;
    private DistanceJoint2D Joint;

    private void Start()
    {
        StandColl = this.GetComponent<Collider2D>();
        GunSprite = Gun.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.U) && !Carry)
            {
                // Coloca el arma en la manos del robot
                GunSprite.sortingOrder = 10;
                Gun.transform.SetParent(collision.transform);
                Gun.transform.localPosition = new Vector3(0.35f, -0.25f, 0);
                Gun.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                Gun.GetComponent<LaserShoot>().enabled = true;

                // Limita el movimiento del robot
                Joint = collision.gameObject.AddComponent<DistanceJoint2D>();
                Joint.enableCollision = true;
                Joint.connectedAnchor = this.transform.position;
                Joint.autoConfigureDistance = false;
                Joint.distance = 13;
                Joint.maxDistanceOnly = true;

                Carry = true;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.U) && Carry)
            {
                // Elimina la limitacion de movimiento del robot
                Destroy(collision.gameObject.GetComponent<DistanceJoint2D>());

                // Coloca el arma en el stand
                GunSprite.sortingOrder = 0;
                Gun.transform.SetParent(this.transform);
                Gun.transform.localPosition = new Vector3(0, 0.35f, 0);
                Gun.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                Gun.GetComponent<LaserShoot>().enabled = false;

                Carry = false;
            }
        }
    }

    private void Update()
    {
        GameObject Player = GameObject.Find("Robot");
        float dist = Vector2.Distance(this.transform.position, Player.transform.position);

        if (dist <= 3)
        {
            float alpha = (CScale(dist, 0.5f, 3, 1, 0));
            HelpText.color = new Color(255, 255, 255, alpha);
        }
    }

    // Funcion para reescalar
    private float CScale(float oldValue, float oldScaleMin, float oldScaleMax, float newScaleMin, float newScaleMax)
    {
        float NewValue;

        float OldRange = (oldScaleMax - oldScaleMin);

        if (OldRange == 0)
        {
            NewValue = newScaleMin;
        }
        else
        {
            float NewRange = (newScaleMax - newScaleMin);
            NewValue = (((oldValue - oldScaleMin) * NewRange) / OldRange) + newScaleMin;
        }

        return NewValue;
    }
}
