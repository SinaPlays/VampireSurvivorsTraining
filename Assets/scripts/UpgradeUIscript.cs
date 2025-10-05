using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class UpgradeUIscript : MonoBehaviour
{
    [SerializeField] Button upgradeGarlic;
    [SerializeField] Button upgradeWhip;
    [SerializeField] Button upgradeMoveSpeed;

    GarlicWeapon garlicWeapon;
    WhipWeapon whipWeapon;
    PlayerMovement playerMovement;
    void Start()
    {
        garlicWeapon = GameObject.FindFirstObjectByType<GarlicWeapon>();
        whipWeapon = GameObject.FindFirstObjectByType<WhipWeapon>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void OnButtonClick()
    {
        Debug.Log("Upgrade button clicked!");
        GameManager.instance.currentState = GameState.Playing;
        this.gameObject.SetActive(false);
    }
    public void UpgradeGarlic()
    {
        garlicWeapon.garlicStrength += 1;
    }
    public void UpgradeWhip()
    {

    }
    public void UpgradeMoveSpeed()
    {

    }
}
