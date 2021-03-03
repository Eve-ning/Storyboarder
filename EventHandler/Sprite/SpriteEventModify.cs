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

        public SpriteEventModify SetAlpha(Func<float, float> value)
        {
            return WithModifiers(new EventSetAlpha(value));
        }
        
        public SpriteEventModify SetAlpha(float value)
        {
            return WithModifiers(new EventSetAlpha(value));
        }

        public SpriteEventModify AddRotate(Func<float, float> value)
        {
            return WithModifiers(new EventAddRotate(value));
        }
        
        public SpriteEventModify AddRotate(float value)
        {
            return WithModifiers(new EventAddRotate(value));
        }

        public SpriteEventModify ScaleX(Func<float, float> value)
        {
            return WithModifiers(new EventScaleX(value));
        }
        
        public SpriteEventModify ScaleX(float value)
        {
            return WithModifiers(new EventScaleX(value));
        }

        public SpriteEventModify AddX(Func<float, float> value)
        {
            return WithModifiers(new EventAddX(value));
        }
        
        public SpriteEventModify AddX(float value)
        {
            return WithModifiers(new EventAddX(value));
        }

        public SpriteEventModify AddY(Func<float, float> value)
        {
            return WithModifiers(new EventAddY(value));
        }
        
        public SpriteEventModify AddY(float value)
        {
            return WithModifiers(new EventAddY(value));
        }
        
        public SpriteEventModify ScaleXY(Func<float, float> value)
        {
            return WithModifiers(new EventScaleXY(value));
        }
        
        public SpriteEventModify ScaleXY(float value)
        {
            return WithModifiers(new EventScaleXY(value));
        }

        public SpriteEventModify ScaleY(Func<float, float> value)
        {
            return WithModifiers(new EventScaleY(value));
        }
        
        public SpriteEventModify ScaleY(float value)
        {
            return WithModifiers(new EventScaleY(value));
        }

        public SpriteEventModify SetSize(Func<float, float> value)
        {
            return WithModifiers(new EventSetSize(value));
        }
        
        public SpriteEventModify SetSize(float value) 
        {
            return WithModifiers(new EventSetSize(value));
        }

        public SpriteEventModify SetTimeRange(float toBegin, float toEnd,
            float fromBegin, float fromEnd)
        {
            return WithModifiers(new EventSetTimeRange(toBegin, toEnd, fromBegin, fromEnd));
        }
        
        public SpriteEventModify SetTimeRange(float toBegin, float toEnd)
        {
            return WithModifiers(new EventSetTimeRange(toBegin, toEnd, 
                EventList.TimeBegin(), EventList.TimeEnd()));
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