using UnityEngine;

public class PotionCombos : MonoBehaviour
{
    public RagePotionEffect ragePotionEffect;
    public ParalysePotionEffect paralysePotionEffect;
    public FreezePotionEffect freezePotionEffect;

    public void ApplyRageAndFreezeCombo()
    {
        ragePotionEffect.ActivateRageEffect();
        freezePotionEffect.ActivateFreezeEffect();
        freezePotionEffect.ActivateFreezeEffect();
    }

    public void ApplyFreezeAndParalyseCombo()
    {
        freezePotionEffect.ActivateFreezeEffect();
        paralysePotionEffect.ActivateParalyseEffect();
        paralysePotionEffect.ActivateParalyseEffect();
    }

    public void ApplyRageAndParalyseCombo()
    {
        ragePotionEffect.ActivateRageEffect();
        paralysePotionEffect.ActivateParalyseEffect();
        paralysePotionEffect.ActivateParalyseEffect();
    }

    public void ApplyFreezeAndRageCombo()
    {
        freezePotionEffect.ActivateFreezeEffect();
        ragePotionEffect.ActivateRageEffect();
        freezePotionEffect.ActivateFreezeEffect();
        ragePotionEffect.ActivateRageEffect();
    }
}
