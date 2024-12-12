using UnityEngine;

public class CallGameManager : MonoBehaviour
{
    //Call active game manager
    public void CallChangeScene(int sceneIndex)
    {
        GameManager.Instance.ChangeScene(sceneIndex);
    }
}
