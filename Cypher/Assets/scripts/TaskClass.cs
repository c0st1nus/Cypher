using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string Taskname;
    public string TaskDescription;
    public int taskConditionsCount;
    public List<string> TaskConditions = new();
    public string taskSender;
    public bool TaskCompleted;
    public bool ScenariumTask;

    public Task(string taskname, string taskDescription, int TaskConditionsCount, string taskSender, bool scenariumTask)
    {
        Taskname = taskname;
        TaskDescription = taskDescription;
        taskConditionsCount = TaskConditionsCount;
        this.taskSender = taskSender;
        ScenariumTask = scenariumTask;
    }

    public void printTask()
    {
        string result = $"{Taskname} : sended by {taskSender} : {TaskDescription} : {taskConditionsCount} : {ScenariumTask}";
        for (int i = 0; i < taskConditionsCount; i++)
        {
            result += $"Condition{i} : {TaskConditions[i]}";
        }
        Debug.Log(result);
    }
}
