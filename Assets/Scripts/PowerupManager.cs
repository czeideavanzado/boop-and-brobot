using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour {

	private bool hasShield;
	private bool hasJetPack;
	private bool hasMagnet;
	private bool canFly;

	private bool isPowerupActive;
	private float shieldTime;
	private float jetpackTime;
	private float wingsTime;
	private float magnetTime;

	private float shieldTotalTime;
	private float jetpackTotalTime;
	private float wingsTotalTime;
	private float magnetTotalTime;

	public PlayerController playerController;
	private GameObject shield;
	private GameObject jetpack;
	private GameObject magnet;
	private GameObject wings;

	public Image shieldTimer;
	public Image jetpackTimer;
	public Image wingsTimer;
	public Image magnetTimer;

	public AudioSource powerUpSound;

	// Use this for initialization
	void Start () {
		shield = playerController.transform.Find("Shield").gameObject; 
		jetpack = playerController.transform.Find("Jetpack").gameObject;
		magnet = playerController.transform.Find("Magnet").gameObject;
		wings = playerController.transform.Find("Wings").gameObject;

		
	}
	
	// Update is called once per frame
	void Update () {
		if(isPowerupActive) {
			
			if(hasShield) {
				shieldTime -= Time.deltaTime;
				shieldTimer.fillAmount = shieldTime/shieldTotalTime;
			}
			
			if(hasJetPack) {
				jetpackTime -= Time.deltaTime;
				jetpackTimer.fillAmount = jetpackTime/jetpackTotalTime;

			}

			if(hasMagnet) {
				magnetTime -= Time.deltaTime;
				magnetTimer.fillAmount = magnetTime/magnetTotalTime;
			}

			if(canFly) {
				wingsTime-= Time.deltaTime;
				wingsTimer.fillAmount = wingsTime/wingsTotalTime;
			}
			

			if(shieldTime <= 0) {
				SetHasShield(false);
			}

			if(magnetTime <= 0) {
				SetHasMagnet(false);
			}

			if(wingsTime <= 0) {
				SetCanFly(false);
			}

			if(jetpackTime <= 0) {
				SetHasJetpack(false);
			}

			if(!hasJetPack && !hasMagnet && !hasShield && !canFly) isPowerupActive = false;
		}
	}

	public void ActivatePowerup (bool shield, bool jetpack, bool magnet, bool fly, float time) {
		
		if(shield) 
		{
			shieldTotalTime = time;
			shieldTime = shieldTotalTime;
			SetHasShield(shield);
		}
		if(jetpack) 
		{
			jetpackTotalTime = time;
			jetpackTime = jetpackTotalTime;
			SetHasJetpack(jetpack);
			
		}
		if(magnet)
		{
			magnetTotalTime = time;
			magnetTime = magnetTotalTime;
			SetHasMagnet(magnet);
		} 
		if(fly) 
		{
			wingsTotalTime = time;
			wingsTime = wingsTotalTime;
			SetCanFly(fly);
		}

		isPowerupActive = true;
		powerUpSound.Play();
	}

	public void DeactivatePowerups () {
		SetHasShield(false);

		SetHasMagnet(false);

		SetHasJetpack(false);

		SetCanFly(false);

		isPowerupActive = false;
	}

	public bool GetHasShield()
	{
		return this.hasShield;
	}

	public bool GetHasMagnet()
	{
		return this.hasMagnet;
	}

	public void SetHasShield(bool hasShield)
	{
		this.hasShield = hasShield;
		shield.SetActive(hasShield);
		shieldTimer.gameObject.SetActive(hasShield);
	}

	public void SetHasMagnet(bool hasMagnet)
	{
		this.hasMagnet = hasMagnet;
		magnet.SetActive(hasMagnet);
		magnetTimer.gameObject.SetActive(hasMagnet);
	}

	public void SetHasJetpack(bool hasJetpack)
	{
		this.hasJetPack = hasJetpack;
		jetpack.SetActive(hasJetpack);
		playerController.hasJetPack = hasJetpack;
		jetpackTimer.gameObject.SetActive(hasJetpack);
	}

	public void SetCanFly(bool canFly)
	{
		this.canFly = canFly;
		wings.SetActive(canFly);
		playerController.canFly = canFly;
		wingsTimer.gameObject.SetActive(canFly);
	}
}
