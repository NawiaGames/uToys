using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum FallVariants {TorqueRight, TorqueRightAndForceBack}
public class FallTrain : MonoBehaviour
{
    [SerializeField] private float _forceTorque = 10f;
    [SerializeField] private float _forceBack = 2f;
    [SerializeField] private FallVariants _variants = FallVariants.TorqueRight;
    private Rigidbody[] _rigidbodyWagons;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Fall();

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    private void Fall()
    {
        switch (_variants)
        {
            case FallVariants.TorqueRight:
                foreach (var wagon in _rigidbodyWagons)
                {
                    wagon.AddTorque(- wagon.transform.forward * _forceTorque, ForceMode.VelocityChange);
                }
                break;
            case FallVariants.TorqueRightAndForceBack:
                foreach (var wagon in _rigidbodyWagons)
                {
                    wagon.AddForce( - wagon.transform.forward * _forceBack, ForceMode.VelocityChange);
                    wagon.AddTorque(- wagon.transform.forward * _forceTorque, ForceMode.VelocityChange);
                }
                break;
        }
        

    }

    public void SetRigidbodyWagons(Wagon[] wagons)
    {
        _rigidbodyWagons = new Rigidbody[wagons.Length];
        for (var i = 0; i < wagons.Length; i++)
        {
            _rigidbodyWagons[i] = wagons[i].Rigidbody; 
        }
    }
    
    
}
