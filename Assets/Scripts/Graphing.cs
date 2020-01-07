using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;


public class Graphing : MonoBehaviour
{
    List<float> value = new List<float>();
    List<GameObject> points = new List<GameObject>();
    List<GameObject> yMarks = new List<GameObject>();

    float scale;
    float max = 0;
    bool CreatedLabels = false;
    RectTransform Canvas;
    public float stockValue;

    GameObject tooltipGameObject;


    private void Awake()
    {
        GameObject Point1 = GameObject.Find("Point");
        GameObject Point2 = GameObject.Find("Point2");
        GameObject Point3 = GameObject.Find("Point3");
        GameObject Point4 = GameObject.Find("Point4");
        GameObject Point5 = GameObject.Find("Point5");
        GameObject Point6 = GameObject.Find("Point6");
        GameObject Point7 = GameObject.Find("Point7");
        GameObject Point8 = GameObject.Find("Point8");
        GameObject Point9 = GameObject.Find("Point9");
        GameObject Point10 = GameObject.Find("Point10");

        GameObject yMark1 = GameObject.Find("Ymark1");
        GameObject yMark2 = GameObject.Find("Ymark2");
        GameObject yMark3 = GameObject.Find("Ymark3");
        GameObject yMark4 = GameObject.Find("Ymark4");
        GameObject yMark5 = GameObject.Find("Ymark5");
        GameObject yMark6 = GameObject.Find("Ymark6");
        GameObject yMark7 = GameObject.Find("Ymark7");

        tooltipGameObject = GameObject.Find("tooltip");


        Canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();

        points = new List<GameObject> { Point1, Point2, Point3, Point4, Point5, Point6, Point7, Point8, Point9, Point10 };
        value = new List<float>{ 3,5.8f,6,3,10,6,2,7,1,9};
        yMarks = new List<GameObject> { yMark1, yMark2, yMark3, yMark4, yMark5, yMark6, yMark7 };

        max = FindMax(max);
        GraphingPoints(max);
        CreateYAxisLabels();
        CreatedLabels = true;

        HideToolTip();
        Point1.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[0].ToString(), new Vector2(-290,Point1.transform.position.y - 125));
        };
        Point1.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };

        Point2.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[1].ToString(), new Vector2(-230, Point2.transform.position.y - 125));
        };
        Point2.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };

        Point3.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[2].ToString(), new Vector2(-160, Point3.transform.position.y - 125));
        };
        Point3.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };

        Point4.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[3].ToString(), new Vector2(-100, Point4.transform.position.y - 125));
        };
        Point4.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };

        Point5.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[4].ToString(), new Vector2(-35, Point5.transform.position.y - 125));
        };
        Point5.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };

        Point6.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[5].ToString(), new Vector2(30, Point6.transform.position.y - 125));
        };
        Point6.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };

        Point7.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[6].ToString(), new Vector2(95, Point7.transform.position.y - 125));
        };
        Point7.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };

        Point8.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[7].ToString(), new Vector2(160, Point8.transform.position.y - 125));
        };
        Point8.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };

        Point9.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[8].ToString(), new Vector2(220, Point9.transform.position.y - 125));
        };
        Point9.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };

        Point10.AddComponent<Button_UI>().MouseOverOnceFunc += () =>
        {
            ShowTooltip(value[9].ToString(), new Vector2(285, Point10.transform.position.y - 125));
        };
        Point10.AddComponent<Button_UI>().MouseOutOnceFunc += () =>
        {
            HideToolTip();
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown("p") == true)
        {
            DestroyPointConnections();
            for (int i = 0; i < value.Count; i++)
            {
                if (i > 0)
                {
                    value[i - 1] = value[i];
                }
            }
            float newValue = Random.Range(1f, 10f);
            value[value.Count - 1] = newValue;
            
            max = FindMax(max);
            GraphingPoints(max);
            CreateYAxisLabels();
        }

        
    }

    void GraphingPoints(float maximum)
    {
        scale = 296 / maximum;
        Debug.Log(scale);
        for (int i = 0; i < value.Count; i++)
        {
            float yPos = value[i] * scale;
            points[i].transform.localPosition = new Vector2(0, yPos);
            if (i > 0)
            {
                CreatePointConnection(points[i - 1].transform.position, points[i].transform.position);
            }
        }
        stockValue = value[9];
        
    }

    void CreatePointConnection (Vector2 PointA, Vector2 PointB)
    {
        GameObject gameObject = new GameObject("PointConnection", typeof(Image));
        gameObject.transform.SetParent(Canvas, false);
        gameObject.tag = "Player";
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (PointB - PointA).normalized;
        float distance = Vector2.Distance(PointA, PointB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = PointA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));

    }

    private float FindMax (float maximum)
    {
        maximum = 0;
        for (int i = 0; i < value.Count; i++)
        {
            float num = value[i];
            if (num >= maximum)
            {
                maximum = num;
            }
        }
        return maximum;
    }

    void DestroyPointConnections()
    {
        GameObject[] connections = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject connection in connections)
        {
            Destroy(connection);
        }
    }

    void CreateYAxisLabels()
    {
        float yAxisSpace = max / 7;
        float label = 0;
        if (CreatedLabels == false)
        {
            for (int i = 0; i < yMarks.Count; i++)
            {
                label = label + yAxisSpace;
                GameObject labelHolder = new GameObject("label", typeof(Text));
                labelHolder.tag = "Finish";
                labelHolder.transform.SetParent(yMarks[i].transform, false);
                Text labelText = labelHolder.GetComponent<Text>();
                labelText.text = label.ToString("F1");
                labelText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                labelText.alignment = TextAnchor.MiddleLeft;
            }
        }
        else
        {
            GameObject[] labels = GameObject.FindGameObjectsWithTag("Finish");
            foreach(GameObject num in labels)
            {
                Destroy(num);
            }
            for (int i = 0; i < yMarks.Count; i++)
            {
                label = label + yAxisSpace;
                GameObject labelHolder = new GameObject("label", typeof(Text));
                labelHolder.tag = "Finish";
                labelHolder.transform.SetParent(yMarks[i].transform, false);
                Text labelText = labelHolder.GetComponent<Text>();
                labelText.text = label.ToString("F1");
                labelText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                labelText.alignment = TextAnchor.MiddleLeft;
            }
        }
        
    }

    void ShowTooltip(string tooltipText, Vector2 anchordedPosition)
    {
        tooltipGameObject.SetActive(true);

        tooltipGameObject.GetComponent<RectTransform>().anchoredPosition = anchordedPosition;

        Text tooltipUIText = tooltipGameObject.transform.Find("text").GetComponent<Text>();
        tooltipUIText.text = tooltipText;

        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(
            tooltipUIText.preferredWidth + textPaddingSize * 2f,
            tooltipUIText.preferredHeight + textPaddingSize * 2f);
        tooltipGameObject.transform.Find("background").GetComponent<RectTransform>().sizeDelta = backgroundSize;
        tooltipGameObject.transform.SetAsLastSibling();

    }

    void HideToolTip()
    {
        tooltipGameObject.SetActive(false);
    }




}
