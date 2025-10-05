using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class UpgradeUIscript : MonoBehaviour
{
    [SerializeField] GarlicWeapon garlicWeapon;
    [SerializeField] WhipWeapon whipWeapon;
    [SerializeField] PlayerMovement playerMovement;

    public void UpgradeGarlic()
    {
        garlicWeapon.garlicStrength += 1f;
        GameManager.instance.ChangeState(GameState.Playing);
        Debug.Log("Garlic Upgraded");
    }
    public void UpgradeWhip()
    {
        whipWeapon.whipStrength += 1;
        GameManager.instance.ChangeState(GameState.Playing);
    }
    public void UpgradeMoveSpeed()
    {
        playerMovement.Speed += 1;
        GameManager.instance.ChangeState(GameState.Playing);
    }
}
