using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float strength;
    public float health;
    public float magicPower;
    public int skillPoints;
    public string coolness;
    public Text statDisplay;

    void Start()
    {
        strength = 12f;
        health = 25f;
        magicPower = 5f;
        skillPoints = 7;
        coolness = "no";
    }

    // Update is called once per frame
    void Update()
    {
        statDisplay.text = "Strength: " + strength + "\nHealth: " + health + "\nMagic Power: " + magicPower + "\nSkill Points: " +  skillPoints + "\nCool? " + coolness;
    }
}
