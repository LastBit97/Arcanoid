using System.Collections;
using UnityEngine;

public class ShootingPaddleBonus : Bonus
{
    private ObjectPool _bulletsPool;
    private const float OffsetY = 0.7f;
    private const float OffsetX = 0.5f;

    public override void Apply()
    {
        StartTimer();
        StartCoroutine(StartShoot());
    }

    private void OnEnable()
    {
        if (_bulletsPool == null)
        {
            ObjectPool[] objectPools = FindObjectsOfType<ObjectPool>();
            for (int i = 0; i < objectPools.Length; i++)
            {
                if (objectPools[i].gameObject.CompareTag("BulletsPool"))
                {
                    _bulletsPool = objectPools[i];
                    break;
                }
            }
        }
    }

    private IEnumerator StartShoot()
    {
        while (true)
        {
            PlayParticles();
            ActivateBullet(OffsetX);
            ActivateBullet(-OffsetX);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ActivateBullet(float offsetX)
    {
        GameObject bullet = _bulletsPool.GetObject();
        if (bullet != null)
        {
            bullet.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y + OffsetY);
            bullet.SetActive(true);
        }
    }

    private void PlayParticles()
    {
        PaddleController paddleController = GetComponentInParent<PaddleController>();
        if (paddleController != null)
        {
            paddleController.PlayEffects();
        }
    }

    protected override IEnumerator Timer()
    {
        yield return base.Timer();
        Destroy(gameObject);
    }
}
