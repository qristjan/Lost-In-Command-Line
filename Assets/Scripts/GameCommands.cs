using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameCommands
{
    private static readonly string commandStart = "/";

    public static Dictionary<string, Command> allCommands = new Dictionary<string, Command>();

    public static List<string> availableCommands = new List<string>();

    public static bool Allowed(string command)
    {
        return availableCommands.Contains(command);
    }

    public static void AddCommand(string text, Command command)
    {
        allCommands.Add(text, command);
        availableCommands.Add(text);
    }

    public static readonly string HelpText = 
        "Virtual Mind Interface Commands\n" 
        + "/help - ¥¢ .. ‰  and ð∂..ø Ø\n"
        + "/about - Information about the tool\n"
        + "/test - User will receive a simple test to check compability with Virtual Mind Interface\n"
        + "/cal≥☼/→ - User can ca/ÿ→┼0;* ☼-??? ¢◄*\n"
        + ".....\n"
        + ".....\n"
        + "Exception in thread main org.aperture.qbit.virtualassistant.interface.Tools\n"
        + "    at org.aperture.qbit.virtualassistant.interface.Tools(Function:13)";
    
    public static readonly string AboutText = 
        "Welcome to the Virtual Mind Interface Program (Default console*).\n"
        + "With us you can interact with the world like never before.\n"
        + "In front of you are virtual worlds and consoles with limitless possibilities.\n"
        + "Just write /help for all available commands to help you traverse through this amazing virtual realm\n"
        + "and our personal assistant {FALLBACK_MONITOR} will be alongside you to assist with all your needs.\n\n"
        + "Your mind and memories are safe with us.\n\n"
        + "* default console has limited capability - use command ▓??▐├┬#;Kæ├○ to access full featured console.\n"
        + "Version 1.0.0-alpha (fallback version/unsafe).\n"
        + "Tag-0.0.1.2 (Unsafe version, use only for AI testing)\n";
}
