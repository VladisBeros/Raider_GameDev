using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDungeon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadScene("Arena");
    }
}