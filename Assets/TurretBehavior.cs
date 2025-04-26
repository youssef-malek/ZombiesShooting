using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{

    public ParticleSystem particleFX;
    public AudioClip soundFX;
    public float damageAmuount = 10;
    private AudioSource audioSource;
    private GameObject target;
    private bool lookingAt;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Fire());
        audioSource = GetComponent<AudioSource>();

        if (soundFX && audioSource)
        {
            audioSource.clip = soundFX;

        }
        else
        {
            Debug.LogWarning("No soundFX or AudioSource found on ");
            return;

        }
    }

    // Update is called once per frame
    void Update()
    {
        target = FindClosestEnemy();
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Vector3 targetDir;
        if (target != null)
        {
            targetDir = target.transform.position - transform.position;
            float step = 2 * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(fwd, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);

            if (Physics.Raycast(transform.position, fwd, out hit))
            {

                Debug.DrawRay(transform.position, fwd * 20, Color.green);

                if (hit.collider.tag == "Target")
                {
                    lookingAt = true;
                }
                else
                {
                    lookingAt = false;
                }

            }
            else
            {
                lookingAt = false;
            }
        }
    }
    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (lookingAt)
            {
                if (particleFX != null)
                {
                    particleFX.Play();
                }
                if (audioSource && soundFX)
                {
                    audioSource.Play();
                }
                target.transform.SendMessage("ApplyDamage", damageAmuount);
            }
            yield return null;
        }
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;

        gos = GameObject.FindGameObjectsWithTag("Target");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;

    }
}
