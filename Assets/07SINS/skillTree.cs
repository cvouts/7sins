using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillTree : MonoBehaviour
{
    public GameObject player;
    public GameObject skillTreePanel;

    public GameObject innerStrengthObject;
    public GameObject exaltedStrengthObject;
    public GameObject bloodlineObject;
    public GameObject heritageObject;
    public GameObject ascendedObject;

    public int innerGain;
    public int exaltedGain;
    public int exaltedBonus;
    public int bloodlineGain;
    public int heritageGain;
    
    private playerController playerScript;
    private int innerStrengthCounter;
    private int exaltedStrengthCounter;
    private int bloodlineCounter;
    private int heritageCounter;

    void Start()
    {
    	playerScript = player.GetComponent<playerController>();

    	innerStrengthCounter = 0;
    	exaltedStrengthCounter = 0;
    	bloodlineCounter = 0;
    	heritageCounter = 0;

    	enableButton(innerStrengthObject);
    	enableButton(bloodlineObject);
    	enableButton(heritageObject);
    	disableButton(exaltedStrengthObject, exaltedStrengthCounter);
    	disableButton(ascendedObject, 0);
    }

    void Update()
    {
    	if(Input.GetKeyDown("p"))
		{
			if(skillTreePanel.activeInHierarchy == true)
			{
				skillTreePanel.SetActive(false);
			}
			else
				skillTreePanel.SetActive(true);
		} 

    	if(playerScript.skillPoints == 0)
    	{
    		disableButton(innerStrengthObject, innerStrengthCounter);
    		disableButton(exaltedStrengthObject, exaltedStrengthCounter);
    		disableButton(bloodlineObject, bloodlineCounter);
    		disableButton(heritageObject, heritageCounter);
    	}

    	if(exaltedStrengthCounter == 5 && bloodlineCounter == 5 && heritageCounter == 5)
    	{
    		enableButton(ascendedObject);
    	}
    }

    void enableButton(GameObject buttonObject)
    {
    	GameObject button;
    	GameObject name;
    	GameObject points;

    	button = buttonObject.transform.GetChild(0).gameObject;
    	name = buttonObject.transform.GetChild(1).gameObject;
		points = buttonObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

    	button.GetComponent<Button>().enabled = true;
    	button.GetComponent<Image>().color = new Color32(255,255,255,255);
    	name.GetComponent<Text>().color = new Color32(255,255,255,255);
    	points.GetComponent<Text>().color = new Color32(255,255,255,255);
    }

    void disableButton(GameObject buttonObject, int counter)
    {
    	GameObject button;
    	GameObject name;
    	GameObject points;


    	button = buttonObject.transform.GetChild(0).gameObject;
    	name = buttonObject.transform.GetChild(1).gameObject;
    	points = buttonObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

    	button.GetComponent<Button>().enabled = false;

    	if(counter == 5)
    	{
    		name.GetComponent<Text>().color = new Color32(255,255,0,255);
    		points.GetComponent<Text>().color = new Color32(255,255,0,255);
    	}
    	else if(counter > 0 && counter < 5)
    	{
    		name.GetComponent<Text>().color = new Color32(255,165,0,255);
    		points.GetComponent<Text>().color = new Color32(255,165,0,255);
    	}
		else if(counter == 0)
    	{
    		button.GetComponent<Image>().color = new Color32(70,70,70,255);
    		points.GetComponent<Text>().color = new Color32(70,70,70,255);
    	}
    }

    void increasePoints(GameObject buttonObject, int counter)
    {
    	GameObject points;

    	points = buttonObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

    	if(buttonObject.name == "Ascension")
    	{
    		points.GetComponent<Text>().text = "1/1";
    	}
		else
		{
			points.GetComponent<Text>().text = counter + "/5";
		}
    }

    public void innerStrength()
    {
    	innerStrengthCounter++;

    	playerScript.strength = playerScript.strength + innerGain;
    	
    	playerScript.skillPoints--;
    	increasePoints(innerStrengthObject, innerStrengthCounter);

    	if(innerStrengthCounter == 5)
    	{
    		disableButton(innerStrengthObject, innerStrengthCounter);
    		enableButton(exaltedStrengthObject);
    	}
    }

    public void exaltedStrength()
    {
    	exaltedStrengthCounter++;

    	playerScript.strength = playerScript.strength + exaltedGain;
    	
    	playerScript.skillPoints--;
    	increasePoints(exaltedStrengthObject, exaltedStrengthCounter);

    	if(exaltedStrengthCounter == 5)
    	{
    		disableButton(exaltedStrengthObject, exaltedStrengthCounter);
    	}
    }

     public void bloodline()
    {
    	bloodlineCounter++;

    	playerScript.health = playerScript.health + bloodlineGain;
    	
    	playerScript.skillPoints--;
    	increasePoints(bloodlineObject, bloodlineCounter);

    	if(bloodlineCounter == 5)
    	{
    		disableButton(bloodlineObject, bloodlineCounter);
    	}
    }

    public void heritage()
    {
    	heritageCounter++;

    	playerScript.magicPower = playerScript.magicPower + heritageGain;
    	
    	playerScript.skillPoints--;
    	increasePoints(heritageObject, heritageCounter);

    	if(heritageCounter == 5)
    	{
    		disableButton(heritageObject, heritageCounter);
    	}
    }

    public void ascended()
    {
    	playerScript.coolness = "YES";
    	increasePoints(ascendedObject, 0);  
    	disableButton(ascendedObject, 1);
	}

    public void getSkillPoints()
    {
    	playerScript.skillPoints++;
    }
}