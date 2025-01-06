using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public SpriteRenderer sr;
    public TextMeshProUGUI tmp;

    private void Start()
    {

        if (StaticData.valueToKeep >= 0)
        {
            tmp.text = "Final Score: " + StaticData.valueToKeep;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("urgh");
        SceneManager.LoadScene("SampleScene");

    }

    private void OnMouseEnter()
    {
        sr.color = Color.gray;
    }

    private void OnMouseExit()
    {
        sr.color = Color.white;
    }



}
