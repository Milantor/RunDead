using System.Xml.Serialization;
using UnityEngine;

public class XmlParser : MonoBehaviour
{
    private XmlSerializer itemSerializer = new XmlSerializer(typeof(Item));
    
    [ContextMenu("Load XML Data")] //test
    public void LoadXMLData()
    {
        TextAsset item = (TextAsset)Resources.Load("Items/apple", typeof(TextAsset));
    } 
}
