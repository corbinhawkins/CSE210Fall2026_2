using System;
using System.Collections.Generic;

class PromptGenerator
{
    private readonly List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What is something you learned today?",
        "Who helped you today, and how?",
        "What challenge did you face today?",
        "What are you grateful for today?"
    };

    private readonly Random _random = new Random();

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}