using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triangulo : MonoBehaviour
{
    public SpriteRenderer sr;
    public Transform go;//, hexagon;
    float latestTime = 0;
    float latestCdTime = 0;
    int rand;
    PolygonCollider2D pc2d;
    Coroutine coroutine;
    public GameObject obj;
    int finalScore;
    bool? syncFlag;

    public Sprite piedra, triangulito;

    private void Start()
    {

        transform.localScale = new Vector3(0, 0, 0);
        pc2d = GetComponent<PolygonCollider2D>();
    }

    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad >= latestTime + 5f)
        {
            rand = Random.Range(1, 100);
            if (rand <= 40)
            {
                sr.color = Color.red;
                sr.sprite = piedra;
                FadeSync();
            }
            else if (rand >= 90)
            {
                sr.sprite = triangulito;
                sr.color = Color.yellow;
                FadeSync();
            }
                
            latestTime = Time.timeSinceLevelLoad;
        }
        else if (Time.timeSinceLevelLoad >= 1f + latestCdTime)
        { 
            if (syncFlag == true)
            {
                pc2d.enabled = false;
                latestCdTime = Time.timeSinceLevelLoad;
                transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }

    private async void FadeSync()
    {
        Vector3 c = transform.localScale;

        if (Time.timeSinceLevelLoad < 10f)
        {
            for (float alpha = 0f; alpha <= .4375f; alpha += 0.001f)
            {
                c.x = alpha;
                c.y = alpha;

                transform.localScale = c;

                await Task.Yield();
            }
        }
        else if (Time.timeSinceLevelLoad < 30)
        {
            for (float alpha = 0f; alpha <= .4375f; alpha += 0.005f)
            {
                c.x = alpha;
                c.y = alpha;

                transform.localScale = c;

                await Task.Yield();
            }
        }
        else
        {
            for (float alpha = 0f; alpha <= .4375f; alpha += 0.0065f)
            {
                c.x = alpha;
                c.y = alpha;

                transform.localScale = c;

                await Task.Yield();
            }
        }
        pc2d.enabled = true;
        await Task.Delay(150);

        obj.GetComponent<scoreKeeper>().UpdateScore();
        syncFlag = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null && sr.color == Color.red)
        {
            finalScore = obj.GetComponent<scoreKeeper>().FinalizeScore();
            StaticData.valueToKeep = finalScore;
            SceneManager.LoadScene("MainMenu");
        }
        else if (sr.color == Color.yellow)
        {
            obj.GetComponent<scoreKeeper>().UpdateScore(5);
        }
    }
}
