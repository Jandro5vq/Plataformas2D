using UnityEngine;

public class HelpFade : MonoBehaviour
{
    [SerializeField] private SpriteRenderer HelpText;
    [SerializeField] private float Maxrange = 3;
    [SerializeField] private float Minrange = 0.5f;

    private void Update()
    {
        GameObject Player = GameObject.Find("Robot");
        float dist = Vector2.Distance(this.transform.position, Player.transform.position);

        if (dist <= Maxrange)
        {
            float alpha = (CScale(dist, Minrange, Maxrange, 1, 0));
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
