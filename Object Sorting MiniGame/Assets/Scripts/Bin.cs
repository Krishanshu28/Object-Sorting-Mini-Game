using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour {
    public string acceptedTag;

    public void CheckObject(GameObject obj)
    {
        string objectTag = obj.tag;

        if (objectTag == acceptedTag)
        {
            GameManager.Instance.AddScore(1);
            GetComponent<GlowFeedback>().TriggerGlow();

            obj.SetActive(false);
        }
        else
        {
            GameManager.Instance.LoseLife();
        }
        obj.SetActive(false);
    }
}
