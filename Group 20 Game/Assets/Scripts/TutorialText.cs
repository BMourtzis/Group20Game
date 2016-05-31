using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    public void WalkTip()
    {
        text.text = "Use A and D or the Right and Left arrows to walk";
    }

    public void JumpTip()
    {
        text.text = "Use the Spacebar to Jump";
    }

    public void DoubleJumpTip()
    {
        text.text = "Jump once and then again to jump longer";
    }

    public void EnemyTip()
    {
        text.text = "Be careful, there is an enemy over there\n";
        text.text += "In order to kill it, you need to just on it's head";
    }

    public void EnemyKilledTip()
    {
        text.text = "Good Job, but be careful there are more enemies in the way";
    }

    public void HealthTip()
    {
        text.text = "Are you hurt? There is a health pack over there";
    }

    public void GunTip()
    {
        text.text = "Oh such Luck ,there is a Pistol over there. Pick it up!";
    }

    public void UseGunTip()
    {
        text.text = "Use the Left Click to fire the your weapon, aim with the mouse";
        text.text += "All your weapons are stored in your Inventory, accessible by pressing 1-5";
    }

    public void AmmoPackTip()
    {
        text.text = "You can pick ammo pack, to replenish your ammo";
    }

    public void End()
    {
        text.text = "Now move to the your left to reach to the next level   ";
    }
}
