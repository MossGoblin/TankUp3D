using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UIMaster : MonoBehaviour
{
    // refs
    [SerializeField] Tank playerTank;

    // selfrefs
    [SerializeField] TextMeshProUGUI topLayerTextTMP;
    [SerializeField] TextMeshProUGUI playerStatsTextTMP;
    [SerializeField] TextMeshProUGUI debugFeedTMP;

    [SerializeField] int feedLenght = 10;

    private Queue<string> debugFeed;
    private StringBuilder stringBuilder;
    void Awake()
    {
        debugFeed = new Queue<string>();
    }

    void Start()
    {
        stringBuilder = new StringBuilder();

        // register listeners
        EventMaster.Instance.RegisterListener(EventType.LayerCreated, OnLayerCreated);
        EventMaster.Instance.RegisterListener(EventType.LayerAdded, OnLayerAdded);
        EventMaster.Instance.RegisterListener(EventType.TankUpdated, OnTankUpdated);
    }

    void Update()
    {
        UpdateTopPlayerLayerGUI();
        UpdatePlayerStatsGUI();
        UpdateDebugFeed();
    }

    private void UpdateTopPlayerLayerGUI()
    {
        WeaponType playerTopLayer = playerTank.tankData.GetTopType();
        topLayerTextTMP.text = playerTopLayer.ToString();
    }

    private void UpdatePlayerStatsGUI()
    {
        int playerSize = playerTank.sizeFactor;
        float playerScale = ToolBox.Sigmoid(playerSize);
        float playerDisbalance = playerTank.speedFactor;
        playerStatsTextTMP.text = $"Size: {playerSize}: {playerScale}\nBalance: {playerDisbalance}";
    }
    private void UpdateDebugFeed()
    {
        stringBuilder.Clear();
        string[] debugStringArray = debugFeed.ToArray();
        foreach (string feedItem in debugFeed)
        {
            stringBuilder.AppendLine(feedItem);
        }
        debugFeedTMP.text = stringBuilder.ToString();
    }

    // define listeners
    private void OnLayerCreated(EventData eventData)
    {
        debugFeed.Enqueue(eventData.EventMessage);
        if (debugFeed.Count > feedLenght)
        {
            debugFeed.Dequeue();
        }
    }

    private void OnLayerAdded(EventData eventData)
    {
        debugFeed.Enqueue(eventData.EventMessage);
        if (debugFeed.Count > feedLenght)
        {
            debugFeed.Dequeue();
        }
    }

    private void OnTankUpdated(EventData eventData)
    {
        debugFeed.Enqueue(eventData.EventMessage);
        if (debugFeed.Count > feedLenght)
        {
            debugFeed.Dequeue();
        }
    }

}
