using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EntityState entityState = new EntityState();
    }

    // Update is called once per frame
    void Update()
    {
        // 상태 머신 현재 상태 업데이트를 수행
        //Statemachine.currentState.Update();
    }
}
