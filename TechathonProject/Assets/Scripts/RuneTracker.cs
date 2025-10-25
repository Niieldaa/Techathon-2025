using UnityEngine;
using UnityEngine.InputSystem; // if using new Input System

public class RuneTracker : MonoBehaviour
{
    public RunePath runePath;
    public InputActionProperty drawButton; // assign VR trigger or grip
    public LineRenderer lineRenderer;

    private int currentPointIndex = 0;
    private bool isDrawing = false;

    void Start()
    {
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        bool buttonPressed = drawButton.action.ReadValue<float>() > 0.5f;

        if (buttonPressed)
        {
            if (!isDrawing)
            {
                StartDrawing();
            }

            UpdateDrawing();
        }
        else if (isDrawing)
        {
            StopDrawing();
        }
    }

    void StartDrawing()
    {
        isDrawing = true;
        currentPointIndex = 0;
        lineRenderer.positionCount = 0;
    }

    void UpdateDrawing()
    {
        // Add current position to line
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);

        // Check proximity to the next point
        if (currentPointIndex < runePath.points.Length)
        {
            float dist = Vector3.Distance(transform.position, runePath.points[currentPointIndex].position);
            if (dist < runePath.pointsThreshold)
            {
                currentPointIndex++;
                if (currentPointIndex >= runePath.points.Length)
                {
                    RuneCompleted();
                }
            }
        }
    }

    void StopDrawing()
    {
        isDrawing = false;
        // You can clear or keep the line for visual feedback
    }

    void RuneCompleted()
    {
        isDrawing = false;
        Debug.Log("Rune completed!");
        // TODO: Trigger rune magic, particle effects, etc.
    }
}
