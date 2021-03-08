using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using EventMaker.Modifiers;

namespace EventMaker {
    using Funct = Func<float, float>;
    public class EventModify {
        public EventList Events;

        public EventModify(EventList events) { Events = events; }
        
        public EventModify SetAlpha   (Funct value) { return WithModifiers(new EventSetAlpha   (value)); }
        public EventModify SetAlpha   (float value) { return WithModifiers(new EventSetAlpha   (value)); }
        public EventModify AddRotate  (Funct value) { return WithModifiers(new EventAddRotate  (value)); }
        public EventModify AddRotate  (float value) { return WithModifiers(new EventAddRotate  (value)); }
        public EventModify AddRotateXY(Funct value) { return WithModifiers(new EventAddRotateXY(value)); }
        public EventModify AddRotateXY(float value) { return WithModifiers(new EventAddRotateXY(value)); }
        public EventModify ScaleX     (Funct value) { return WithModifiers(new EventScaleX     (value)); }
        public EventModify ScaleX     (float value) { return WithModifiers(new EventScaleX     (value)); }
        public EventModify AddX       (Funct value) { return WithModifiers(new EventAddX       (value)); }
        public EventModify AddX       (float value) { return WithModifiers(new EventAddX       (value)); }
        public EventModify AddY       (Funct value) { return WithModifiers(new EventAddY       (value)); }
        public EventModify AddY       (float value) { return WithModifiers(new EventAddY       (value)); }
        public EventModify ScaleXY    (Funct value) { return WithModifiers(new EventScaleXY    (value)); }
        public EventModify ScaleXY    (float value) { return WithModifiers(new EventScaleXY    (value)); }
        public EventModify ScaleY     (Funct value) { return WithModifiers(new EventScaleY     (value)); }
        public EventModify ScaleY     (float value) { return WithModifiers(new EventScaleY     (value)); }
        public EventModify SetSize    (Funct value) { return WithModifiers(new EventSetSize    (value)); }
        public EventModify SetSize    (float value) { return WithModifiers(new EventSetSize    (value)); }
        public EventModify SetX       (Funct value) { return WithModifiers(new EventSetX       (value)); }
        public EventModify SetX       (float value) { return WithModifiers(new EventSetX       (value)); }
        public EventModify SetY       (Funct value) { return WithModifiers(new EventSetY       (value)); }
        public EventModify SetY       (float value) { return WithModifiers(new EventSetY       (value)); }

        public EventModify AlignRotate(float radiansOffset = 0f, Vector2 origin = default(Vector2)) {
            return WithModifiers(new EventAlignRotate(radiansOffset, origin));
        }
        public EventModify AlignRotate(Funct radiansFunc, Vector2 origin = default(Vector2)) {
            return WithModifiers(new EventAlignRotate(radiansFunc, origin));
        }
        
        public EventModify FitXY(float toLowerX, float toUpperX, float toLowerY, float toUpperY) {
            var X = Events.X;
            var Y = Events.Y;
            
            return WithModifiers(
                new EventFitXY(X.Min(), X.Max(), toLowerX, toUpperX,
                    Y.Min(), Y.Max(), toLowerY, toUpperY));
        }
        public EventModify FitXY(
            float fromLowerX, float fromUpperX,
            float fromLowerY, float fromUpperY,
            float toLowerX, float toUpperX,
            float toLowerY, float toUpperY) {
            return WithModifiers(
                new EventFitXY(fromLowerX, fromUpperX,
                               fromLowerY, fromUpperY,
                               toLowerX, toUpperX,
                               toLowerY, toUpperY));
        }
        
        public EventModify SetTimeRange
            (float toBegin, float toEnd, float fromBegin, float fromEnd) {
            return WithModifiers(new EventSetTimeRange(toBegin, toEnd, fromBegin, fromEnd));
        }
        public EventModify SetTimeRange(float toBegin, float toEnd) {
            return WithModifiers(
                new EventSetTimeRange(toBegin, toEnd, Events.TimeBegin(), Events.TimeEnd())); }

        public EventModify WithModifiers(EventModifier modifier) {
            modifier.ModifyAll(Events);
            return this;
        }

        public EventModify WithModifiers(List<EventModifier> modifiers) {
            foreach (var modifier in modifiers) 
                WithModifiers(modifier);
            
            return this;
        }
    }
}