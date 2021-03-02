using System;
using System.Collections.Generic;
using EventHandler.Modifiers;

namespace EventHandler.Sprite
{
    public class SpriteEventModify
    {
        public SpriteEventList EventList;

        public SpriteEventModify(SpriteEventList eventList)
        {
            EventList = eventList;
        }

        public SpriteEventModify Alpha(Func<float, float> funcAlpha)
        {
            return WithModifiers(new EventAlpha(funcAlpha));
        }
        
        public SpriteEventModify Alpha(float constAlpha)
        {
            return WithModifiers(new EventAlpha(constAlpha));
        }

        public SpriteEventModify Rotate(Func<float, float> funcRotate)
        {
            return WithModifiers(new EventRotate(funcRotate));
        }
        
        public SpriteEventModify Rotate(float constRotate)
        {
            return WithModifiers(new EventRotate(constRotate));
        }

        public SpriteEventModify ScaleX(Func<float, float> funcScaleX)
        {
            return WithModifiers(new EventScaleX(funcScaleX));
        }
        
        public SpriteEventModify ScaleX(float constScaleX)
        {
            return WithModifiers(new EventScaleX(constScaleX));
        }

        public SpriteEventModify ScaleY(Func<float, float> funcScaleY)
        {
            return WithModifiers(new EventScaleY(funcScaleY));
        }
        
        public SpriteEventModify ScaleY(float constScaleY)
        {
            return WithModifiers(new EventScaleY(constScaleY));
        }

        public SpriteEventModify Size(Func<float, float> funcSize)
        {
            return WithModifiers(new EventSize(funcSize));
        }
        
        public SpriteEventModify Size(float constSize) 
        {
            return WithModifiers(new EventSize(constSize));
        }

        public SpriteEventModify TimeRange(float toBegin, float toEnd,
            float fromBegin = -1f, float fromEnd = 0f)
        {
            return WithModifiers(new EventTimeRange(toBegin, toEnd, fromBegin, fromEnd));
        }

        public SpriteEventModify WithModifiers(EventModifier modifier)
        {
            modifier.ModifyAll(EventList);
            return this;
        }
        public SpriteEventModify WithModifiers(List<EventModifier> modifiers)
        {
            foreach (var modifier in modifiers) 
                WithModifiers(modifier);
            
            return this;
        }
    }
}