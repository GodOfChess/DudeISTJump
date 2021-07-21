using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    public GameObject platform, brokenplatform, boostplatform, istmoney;
    private float genY = -4f;
    public static int count = 0, brokencount = 0;
    private int currentcount = 0;

    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GenerateNormalPlatform();
        }
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        if (count < 10)
        {
            if (currentcount % 10 == 0)
            {
                GenerateBoostPlatform();
            }
            else
            {   
                GenerateNormalPlatform();
            }
            if (currentcount % 15 == 0)
            {
                GenerateISTMoney();
            }
            else
            {
                GenerateBrokenPlatform();
            }
            currentcount += 1;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Generate());
    }

    private void GenerateNormalPlatform()
    {
        Vector3 position = new Vector3();
        position.x = Random.Range(-2f, 2f);
        position.y = genY + Random.Range(3f, 4f);
        genY = position.y;
        Instantiate(platform, position, Quaternion.identity);
        count += 1;
    }

    private void GenerateBrokenPlatform()
    {
        Vector3 position = new Vector3();
        position.x = Random.Range(-2f, 2f);
        position.y = genY + Random.Range(1f, 2f);
        Instantiate(brokenplatform, position, Quaternion.identity);
        brokencount += 1;
    }

    private void GenerateBoostPlatform()
    {
        Vector3 position = new Vector3();
        position.x = Random.Range(-2f, 2f);
        position.y = genY + Random.Range(3f, 4f);
        genY = position.y;
        Instantiate(boostplatform, position, Quaternion.identity);
        count += 1;
    }

    private void GenerateISTMoney()
    {
        Vector3 position = new Vector3();
        position.x = Random.Range(-2, 2);
        position.y = genY + Random.Range(1f, 2f);
        Instantiate(istmoney, position, Quaternion.identity);
    }
}
