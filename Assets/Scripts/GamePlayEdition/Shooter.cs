using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool RandomShouter = false;
    public float RandomSpawnTimeOffset1 = 0.4f;
    public float RandomSpawnTimeOffset2 = 3.4f;
    public GameObject BulletObj;// Объект пули летящий
    public float TimeOffset = 0.3f;
    public float OffsetInstantate = 0.5f;// растояние для начала спамна
    //public static bool ShootRightSt = true;// в какую сторону стрелять (static)
    private void Start()
    {
        if (RandomShouter)
        {
            StartCoroutine(RandomSpawnBullet());
        }
        else StartCoroutine(SpawnBullet());
    }
    IEnumerator SpawnBullet()
    {
        while (true)
        {
            //BulletObj.transform.localScale = gameObject.transform.localScale;
            Instantiate(BulletObj, new Vector3(transform.position.x + OffsetInstantate, transform.position.y, transform.position.z + 1), Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - BulletObj.transform.eulerAngles.z));
            yield return new WaitForSeconds(TimeOffset);
        }
    }
    IEnumerator RandomSpawnBullet()
    {
        //!GamePlayProvider.PauseGamePlay
        while (true)
        {
            //BulletObj.transform.localScale = gameObject.transform.localScale;
            Instantiate(BulletObj, new Vector3(transform.position.x + OffsetInstantate, transform.position.y, transform.position.z + 1), Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - BulletObj.transform.eulerAngles.z));
            yield return new WaitForSeconds(Random.Range(RandomSpawnTimeOffset1, RandomSpawnTimeOffset2));
        }
    }

}
