using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class sticky_test
{
    public bool IsTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        IsTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsTriggered = false;
    }

    // A Test behaves as an ordinary method
    [Test]
    public void editmodeSimplePasses()
    {
        var triggerGameObject = new GameObject("Trigger");

        var triggerObject = triggerGameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        var triggerBoxCollider = triggerGameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        triggerBoxCollider.isTrigger = true;

        var colliderObject = new GameObject("Player");
        colliderObject.AddComponent<Rigidbody2D>();
        colliderObject.AddComponent<BoxCollider2D>();

        colliderObject.transform.position = triggerBoxCollider.transform.position;

        Assert.IsTrue(triggerBoxCollider.isTrigger);
        // Use the Assert class to test conditions
    }
}
