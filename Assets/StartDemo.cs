using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDemo : MonoBehaviour
{
    public void LoadDemo()
    {
    	SceneManager.LoadScene("Scene01", LoadSceneMode.Single);
    }
}
