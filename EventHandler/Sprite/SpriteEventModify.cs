using System;
using System.Collections.Generic;
using EventHandler.Modifiers;

namespace EventHandler.Sprite {
    using Funct = Func<float, float>;
    public class SpriteEventModify {
        public SpriteEventList EventList;

        public SpriteEventModify(SpriteEventList eventList) { EventList = eventList; }
        
        public SpriteEventModify SetAlpha   (Funct value) { return WithModifiers(new EventSetAlpha   (value)); }
        public SpriteEventModify SetAlpha   (float value) { return WithModifiers(new EventSetAlpha   (value)); }
        public SpriteEventModify AddRotate  (Funct value) { return WithModifiers(new EventAddRotate  (value)); }
        public SpriteEventModify AddRotate  (float value) { return WithModifiers(new EventAddRotate  (value)); }
        public SpriteEventModify AddRotateXY(Funct value) { return WithModifiers(new EventAddRotateXY(value)); }
        public SpriteEventModify AddRotateXY(float value) { return WithModifiers(new EventAddRotateXY(value)); }
        public SpriteEventModify ScaleX     (Funct value) { return WithModifiers(new EventScaleX     (value)); }
        public SpriteEventModify ScaleX     (float value) { return WithModifiers(new EventScaleX     (value)); }
        public SpriteEventModify AddX       (Funct value) { return WithModifiers(new EventAddX       (value)); }
        public SpriteEventModify AddX       (float value) { return WithModifiers(new EventAddX       (value)); }
        public SpriteEventModify AddY       (Funct value) { return WithModifiers(new EventAddY       (value)); }
        public SpriteEventModify AddY       (float value) { return WithModifiers(new EventAddY       (value)); }
        public SpriteEventModify ScaleXY    (Funct value) { return WithModifiers(new EventScaleXY    (value)); }
        public SpriteEventModify ScaleXY    (float value) { return WithModifiers(new EventScaleXY    (value)); }
        public SpriteEventModify ScaleY     (Funct value) { return WithModifiers(new EventScaleY     (value)); }
        public SpriteEventModify ScaleY     (float value) { return WithModifiers(new EventScaleY     (value)); }
        public SpriteEventModify SetSize    (Funct value) { return WithModifiers(new EventSetSize    (value)); }
        public SpriteEventModify SetSize    (float value) { return WithModifiers(new EventSetSize    (value)); }
        public SpriteEventModify SetX       (Funct value) { return WithModifiers(new EventSetX       (value)); }
        public SpriteEventModify SetX       (float value) { return WithModifiers(new EventSetX       (value)); }
        public SpriteEventModify SetY       (Funct value) { return WithModifiers(new EventSetY       (value)); }
        public SpriteEventModify SetY       (float value) { return WithModifiers(new EventSetY       (value)); }

        public SpriteEventModify AlignRotate(float radiansOffset = 0f) {
            return WithModifiers(new EventAlignRotate(radiansOffset));
        }
        public SpriteEventModify AlignRotate(Funct radiansFunc) {
            return WithModifiers(new EventAlignRotate(radiansFunc));
        }
        
        public SpriteEventModify SetTimeRange
            (float toBegin, float toEnd, float fromBegin, float fromEnd) {
            return WithModifiers(new EventSetTimeRange(toBegin, toEnd, fromBegin, fromEnd));
        }
        public SpriteEventModify SetTimeRange(float toBegin, float toEnd) {
            return WithModifiers(
                new EventSetTimeRange(toBegin, toEnd, EventList.TimeBegin(), EventList.TimeEnd())); }

        public SpriteEventModify WithModifiers(EventModifier modifier) {
            modifier.ModifyAll(EventList);
            return this;
        }

        public SpriteEventModify WithModifiers(List<EventModifier> modifiers) {
            foreach (var modifier in modifiers) 
                WithModifiers(modifier);
            
            return this;
        }
    }
}