using System;
using System.Collections.Generic;
using System.Text;

namespace WpfOrganizer.Models
{
    class TagManager
    {
        static private TagManager instance;
        static public TagManager Inst
        {
            get => instance ?? (instance = new TagManager());
            set{ }
        }

        public delegate void TagRemoved(Tag removedTag);
        public event TagRemoved OnTagRemoved;

        public void RemoveTag(Tag tag)
        {
            OnTagRemoved?.Invoke(tag);
        }
    }
}
