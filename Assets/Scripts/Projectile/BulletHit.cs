using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCillisionEnter()
    {
        gameObject.SetActive(false);
    }
}
