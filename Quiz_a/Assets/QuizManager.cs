using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Text[] resultTexts; // Array to hold resultText on canvases
    public float waitTime;
    public GameObject[] canvases; // Array to hold canvases

    private int currentCanvasIndex = 0;

    private void Start()
    {
        // Explicitly set canvasA as active and hide the others at the start
        SetCanvasVisibility(0);
    }

    public void ClickO()
    {
        SetResultText("Good!");
        StartCoroutine(Delay());
    }

    public void ClickX()
    {
        SetResultText("ddang!");
        StartCoroutine(Delay());
    }

    public void NextQuestion()
    {
        HideCanvas(currentCanvasIndex);
        currentCanvasIndex++;
        if (currentCanvasIndex < canvases.Length)
        {
            ShowCanvas(currentCanvasIndex);
        }
        else
        {
            Finish();
        }
    }

    public void Finish()
    {
        // This method is called when the "Finish" button on the last canvas is pressed
        HideCanvas(currentCanvasIndex);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(waitTime);
        SetResultText("");
    }

    private void SetResultText(string text)
    {
        foreach (var resultText in resultTexts)
        {
            resultText.text = text;
        }
    }

    private void ShowCanvas(int index)
    {
        if (index >= 0 && index < canvases.Length)
        {
            SetCanvasVisibility(index);
        }
    }

    private void HideCanvas(int index)
    {
        if (index >= 0 && index < canvases.Length)
        {
            canvases[index].SetActive(false);
        }
    }

    private void SetCanvasVisibility(int index)
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(i == index);
        }
    }
}
