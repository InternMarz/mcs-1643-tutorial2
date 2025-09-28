using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform startPos;
    public GameObject ballPrefab;
    public int opposingPlayer; 
    public AudioClip outSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ball"))
            AudioSource.PlayClipAtPoint(outSound, other.transform.position, 1.0f);
        // Debug.Log($"{other.transform.name} just entered {transform.name}");
        // TODO: set other player's score up by 1
        ScoreManager.AddScore(opposingPlayer);


        // TODO: destroy this ball (other)
        Destroy(other.gameObject);

        // TODO: instantiate a new ball in the center
        if (ScoreManager.playing)
        {
            Instantiate(ballPrefab, startPos.position, Quaternion.identity);
        }
    }
}
