using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PathProgression : MonoBehaviour
{
    public Image startNode;
    public Image goalNode;
    public Image[] nodes;   // Node_1, Node_2, ..., Node_9
    public Image[] bridges; // Bridge_1, Bridge_2, ..., Bridge_10

    public Color redColor = Color.red;
    public Color greenColor = Color.green;

    [SerializeField] GameObject levelCompletePanel;
    int currentSolutionCounter; 
    private void Awake()
    {
        currentSolutionCounter = GameManager.Instance.solutionCounter;
    }
    void Start()
    {
        UpdateCounter(currentSolutionCounter);
    }

    public void UpdateCounter(int counter)
    {
        if (counter % 10 == 0 && counter != 0)
        {
            int bridgeIndex = (counter / 10) - 1;
            StartCoroutine(AnimatePath(bridgeIndex));
        }
    }

    private IEnumerator AnimatePath(int upToIndex)
    {
        for (int i = 0; i <= upToIndex; i++)
        {
            if (i < bridges.Length)
                yield return StartCoroutine(ChangeColor(bridges[i], redColor, greenColor, 0.5f));

            if (i < nodes.Length)
                yield return StartCoroutine(ChangeColor(nodes[i], redColor, greenColor, 0.5f));
        }
        // Se abbiamo completato tutti i nodi, coloriamo anche il Goal
        if (upToIndex == bridges.Length - 1)
        {
            yield return StartCoroutine(ChangeColor(goalNode, redColor, greenColor, 0.5f));
            // Show Well Done! 
            levelCompletePanel.SetActive(true);
        }
    }

    private IEnumerator ChangeColor(Image img, Color start, Color end, float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            img.color = Color.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        img.color = end;
    }

    private void ResetColors()
    {
        startNode.color = greenColor;
        goalNode.color = redColor;

        foreach (var node in nodes) node.color = redColor;
        foreach (var bridge in bridges) bridge.color = redColor;
    }
}
