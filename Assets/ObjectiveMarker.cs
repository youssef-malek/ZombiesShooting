using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveMarker : MonoBehaviour
{

    public Transform target;
    public TextMeshProUGUI display;
    public float distance = 3f;
    public float fadeTime = 0.3f;
    private float angle;
    private RectTransform rectTransform;
    private GameObject player;
    private Image image;// Prefab for the objective marker 
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance;
        transform.LookAt(target);

        if (target != null)
        {
            Vector3 relative = player.transform.InverseTransformPoint(target.position);
            angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            angle *= -1;
        }

        rectTransform.transform.eulerAngles = new Vector3(0, 0, angle);
        currentDistance = Vector3.Distance(player.transform.position, target.transform.position);

        if (display != null)
        {
            display.text = (Mathf.Round(currentDistance * 10f) / 10f).ToString() + "Meters";

        }
        if (angle <= 30 && angle >= -30 && currentDistance < distance)
        {
            image.CrossFadeAlpha(0, fadeTime, false);

            if (display != null)
            {
                display.CrossFadeAlpha(0, fadeTime, false);
            }
            else
            {
                image.CrossFadeAlpha(1, fadeTime, false);
                if (display != null)
                    display.CrossFadeAlpha(1, fadeTime, false);


            }
        }
    }
}
