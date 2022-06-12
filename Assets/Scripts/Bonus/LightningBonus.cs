using System;
using System.Collections;
public class LightningBonus : Bonus
{
    public static event Action<bool> OnLightning;
    public override void Apply()
    {
        base.Apply();
        StartTimer();
        OnLightning?.Invoke(true);
    }

    protected override IEnumerator Timer()
    {
        yield return base.Timer();
        Remove();        
        Destroy(gameObject);
    }

    private void Remove()
    {
        OnLightning?.Invoke(false);
    }
}
