using System;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if(text.Length != 3 && text.Length != 5)
            {
                return "I dont know how to look like that";
            } else if(text[0] != "look")
            {
                return "Error in look input";
            } else if(text[1] != "at")
            {
                return "What do you want to look at?";
            } else if(text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            } else if(text.Length == 3)
            {
                return LookAtIn(text[2], p);
            } else if(text.Length == 5)
            {
                IHaveInventory container = FetchContainer(p, text[4]);
                if (container == null)
                {
                    return "I cannot find the " + text[4];
                } else
                {
                    return LookAtIn(text[2], container);
                }
            }
            return null;
        }

        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            return p.Locate(containerID) as IHaveInventory;
        }

        private string LookAtIn(string thingID, IHaveInventory container)
        {
            if (container.Locate(thingID) == null)
            {
                return "I cannot find " + thingID + " in " + container.Name;
            } else
            { 
                return (container.Locate(thingID)).FullDescription;
            }
        }
    }
}
