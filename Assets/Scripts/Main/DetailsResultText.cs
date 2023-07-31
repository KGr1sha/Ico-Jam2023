using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailsResultText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI UHaveTo;
    [SerializeField] TextMeshProUGUI UAlready;
    [SerializeField] public CollectablesStatus data;

    public void ResultChanger()
    {
        UAlready.text = "You have already found: \n";
        UHaveTo.text = "You have to found: \n";
        if (data.Fragment1Collected && data.Fragment2Collected && data.Fragment3Collected)
        {
            UAlready.text = "You have already found all the fragments. Go to your spaceship!";
            UHaveTo.text = "";
        }
        else if (!data.Fragment1Collected && !data.Fragment2Collected && !data.Fragment3Collected)
        {
            UAlready.text = "All fragments are scattered across this uncharted planet. Find them and fix your ship!";
            UHaveTo.text = "";
        }
        else
        {
            if (data.Fragment1Collected)
            {
                UAlready.text += "First Fragment\n";
            }
            if (data.Fragment2Collected)
            {
                UAlready.text += "Second Fragment\n";
            }
            if (data.Fragment3Collected)
            {
                UAlready.text += "Third Fragment\n";
            }
            if (!data.Fragment1Collected)
            {
                UHaveTo.text += "First Fragment\n";
            }
            if (!data.Fragment2Collected)
            {
                UHaveTo.text += "Second Fragment\n";
            }
            if (!data.Fragment3Collected)
            {
                UHaveTo.text += "Third Fragment\n";
            }
        }

    }
}
