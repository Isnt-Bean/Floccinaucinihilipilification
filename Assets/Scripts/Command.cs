using UnityEngine;
using System.Collections.Generic;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class CommandInvoker
{
    static Stack<ICommand> undoStack = new Stack<ICommand>();

    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }

    public static void UndoCommand()
    {
        if (undoStack.Count > 0)
        {
            ICommand command = undoStack.Pop();
            command.Undo();
        }
    }
}

public class DialogStuff
{
    public void NextDialog(NPC npc)
    {
        npc.Increment();
    }

    public void PreviousDialog(NPC npc)
    {
        npc.Deincrement();
    }
}

public class Commands : ICommand
{
    NPC npc;
    
    public Commands(NPC o)
    {
        this.npc = o;
    }

    public void Execute()
    {
        npc.Increment();
    }

    public void Undo()
    {
        npc.Deincrement();
    }
}
