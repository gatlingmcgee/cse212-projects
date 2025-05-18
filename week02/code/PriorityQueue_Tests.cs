using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Checks if queue contains both data and priority
    // Expected Result: Returns the item with the highest priority first
    // Defect(s) Found: Originally did not remove the item from the queue.
    // Added "_queue.RemoveAt(highPriorityIndex);" line
    public void HighestPriorityItem()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 2);

        var result = queue.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Checks if queue contains multiple items with the same priority
    // Expected Result: Returns the first item queued with the highest priority first
    // Defect(s) Found: Needed to grab the first item with equal priority
    // Removed the "=" from "if (_queue[index].Priority >= _queue[highPriorityIndex].Priority)" line
    public void MultipleHighPriorityItems()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 2);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 5);

        var result = queue.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Queue is called when empty
    // Expected Result: An InvalidOperationException is thrown
    // Defect(s) Found: No defect
    [ExpectedException(typeof(InvalidOperationException))]
    public void EmptyQueueThrowsException()
    {
        var queue = new PriorityQueue();
        queue.Dequeue();
    }

    [TestMethod]
    // Scenario: Multiple items are added and removed multiple times
    // Expected Result: Items are removed in descending order according to priority
    // Defect(s) Found: Original did not remove the item from the queue
    // Added "_queue.RemoveAt(highPriorityIndex);" line
    public void RemoveCorrectItemsInOrder()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("X", 1);
        queue.Enqueue("Y", 3);
        queue.Enqueue("Z", 2);

        Assert.AreEqual("Y", queue.Dequeue());
        Assert.AreEqual("Z", queue.Dequeue());
        Assert.AreEqual("X", queue.Dequeue());
    }
}
