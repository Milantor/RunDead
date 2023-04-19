#nullable enable
using System;
using System.Globalization;
using System.IO;
using System.Xml;
using UnityEngine;

public class XmlParser : MonoBehaviour
{
    private XmlDocument xmlDocument = new();

    private void Start()
    {
        var path = Application.dataPath + "\\" + "Items/baseItems.xml";
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File " + path + " do not exists!");
        }

        Debug.Log("File " + path + " exists!");
        xmlDocument.Load(path);
        LoadXMLData();
    }

    [ContextMenu("Load XML Data")] //test
    public void LoadXMLData()
    {
        XmlElement? rootRoot = xmlDocument.DocumentElement;
        if (rootRoot == null)
            throw new ArgumentNullException($"Xml root not found");
        foreach (XmlNode? node in rootRoot)
        {
            XmlNode? attribute = node.Attributes.GetNamedItem("id");
            if (attribute == null)
                throw new ArgumentNullException($"Xml attrinute 'id' not exists");
            var id = attribute.Value;
            decimal weight = 0;
            var reply = $"Loading item preset...\nItem id: {id}";
            foreach (XmlNode childnode in node.ChildNodes)
            {
                switch (childnode.Name)
                {
                    case "weight":
                        weight = Convert.ToDecimal(childnode.InnerText, CultureInfo.InvariantCulture);
                        reply += $"\nWeight: {weight}";
                        break;
                }
            }

            WorldController._instance.itemPresets.Add(id, new ItemPreset()
            {
                weight = weight
            });
            Debug.Log(reply);
        }
    }
}