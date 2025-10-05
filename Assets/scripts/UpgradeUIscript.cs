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
        Debug.Log("Upgrade Garlic Button Clicked");
        UpgradeGarlic();
    }
    public void UpgradeGarlic()
    {
        garlicWeapon.garlicStrength += 1;
        GameManager.instance.ChangeState(GameState.Playing);
    }
    public void UpgradeWhip()
    {

    }
    public void UpgradeMoveSpeed()
    {

    }
}
