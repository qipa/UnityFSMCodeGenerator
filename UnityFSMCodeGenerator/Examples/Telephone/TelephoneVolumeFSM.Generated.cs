//
// Auto-generated by Unity FSM Code Generator:
//     https://github.com/justonia/UnityFSMCodeGenerator
//
// ** Do not modify, changes will be overwritten. **
//

using System.Collections;
using System.Collections.Generic;

namespace UnityFSMCodeGenerator.Examples
{
    // This FSM controls the volume of the phone.
    public class TelephoneVolumeFSM :  UnityFSMCodeGenerator.BaseFsm, UnityFSMCodeGenerator.IFsmDebugSupport
    {
        public readonly static string GeneratedFromPrefab = "Assets/UnityFSMCodeGenerator/UnityFSMCodeGenerator/Examples/Telephone/TelephoneVolumeFSM.prefab";
        public readonly static string GeneratedFromGUID = "b81d0d14e94579c4c85b7b09730d97dd";
    
        public enum State
        {
            WaitForEvent,
        }
    
        public const State START_STATE = State.WaitForEvent;
    
        public enum Event
        {
            VolumeDown,
            VolumeUp,
        }
    
        public interface IContext : UnityFSMCodeGenerator.IFsmContext
        {
            State State { get; set; }
            UnityFSMCodeGenerator.Examples.IAudioControl AudioControl { get; }
        }
    
        #region Public Methods
    
        public IContext Context { get { return context; }}
        
        // TelephoneVolumeFSM is completely stateless when events are not firing. Bind() sets
        // the current context but does nothing else until you call SendEvent().
        // Instances of this class may be re-used and shared by calling Bind() in-between
        // invocations of SendEvent().
        public void Bind(IContext context)
        {
            if (isFiring) {
                throw new System.InvalidOperationException("Cannot call TelephoneVolumeFSM.Bind(IContext) while events are in-progress");
            }
    
            this.context = context;
        }
    
        // Send an event, possibly triggering a transition, an internal action, or an 
        // exception if the event is not handled in the current state. If an event is in
        // process of firing, the event is queued and then sent once firing is done.
        public void SendEvent(Event _event)
        {
            if (eventPool.Count == 0) {
                eventPool.Enqueue(new QueuedEvent());
            }
            var queuedEvent = eventPool.Dequeue();
            queuedEvent._event = _event;
            InternalSendEvent(queuedEvent);
        }
        
        public static IContext NewDefaultContext(
            UnityFSMCodeGenerator.Examples.IAudioControl audioControl,
            State startState = START_STATE)
        {
            return new DefaultContext{
                State = startState,
                AudioControl = audioControl, 
            };
        }
    
        #endregion
    
        #region Private Variables
           
        public override UnityFSMCodeGenerator.IFsmContext BaseContext { get { return context; }}
        
        private class QueuedEvent
        {
            public Event _event;
        }
    
        readonly Queue<QueuedEvent> eventQueue = new Queue<QueuedEvent>();
        readonly Queue<QueuedEvent> eventPool = new Queue<QueuedEvent>();
        private bool isFiring;
        private IContext context;
    
        private class DefaultContext : IContext
        {
            public State State { get; set; }
            public UnityFSMCodeGenerator.Examples.IAudioControl AudioControl { get; set; }
            
        }
    
        #endregion
    
        #region Private Methods
        
        private void InternalSendEvent(QueuedEvent _event)
        {
            if (isFiring) {
                eventQueue.Enqueue(_event);
                return;
            }
    
            try {
                isFiring = true;
    
                SingleInternalSendEvent(_event);
    
                while (eventQueue.Count > 0) {
                    var queuedEvent = eventQueue.Dequeue();
                    SingleInternalSendEvent(queuedEvent);
                    eventPool.Enqueue(queuedEvent);
                }
            }
            finally {
                isFiring = false;
                eventQueue.Clear();
            }
        }
    
        
        private void SingleInternalSendEvent(QueuedEvent _eventData)
        {
            Event _event = _eventData._event;
            State from = context.State;
        
            switch (context.State) {
            case State.WaitForEvent:
                switch (_event) {        
                default:
                    if (!HandleInternalActions(from, _event)) {
                        throw new System.Exception(string.Format("Unhandled event '{0}' in state '{1}'", _event.ToString(), context.State.ToString()));
                    }
                    break;
                }
                break;
        
            }
        }
    
        
        
        private bool HandleInternalActions(State state, Event _event)
        {
            var handled = false;
        
            switch (state) {
            case State.WaitForEvent:
                switch (_event) {        
                case Event.VolumeUp:
                    context.AudioControl.VolumeUp();
                    handled = true;
                    break;        
                case Event.VolumeDown:
                    context.AudioControl.VolumeDown();
                    handled = true;
                    break;
                }
                break;
        
            }
        
            return handled;
        }
    
    
        private void SwitchState(State from, State to)
        {
            context.State = to;
            DispatchOnExit(from);
            DispatchOnEnter(to);
        }
        
        private bool TransitionTo(State state, State from)
        {
            // TODO: Guard conditions might hook in here
            return true;
        }
    
        
        private void DispatchOnEnter(State state)
        {
            switch (state) {
            case State.WaitForEvent:
                break;
            }
        }
    
        
        private void DispatchOnExit(State state)
        {
            switch (state) {
            case State.WaitForEvent:
                break;
            }
        }
    
        #endregion
        
        #region IFsmDebugSupport
        
        public struct StateComparer : IEqualityComparer<State>
        {
            public bool Equals(State x, State y) { return x == y; }
            public int GetHashCode(State obj) { return obj.GetHashCode(); }
        }
        
        private Dictionary<State, string> debugStateLookup = new Dictionary<State, string>(new StateComparer()){
            { State.WaitForEvent, "Wait For Event" },
        };
        private List<string> debugStringStates = new List<string>(){
            "Wait For Event",
        };
        
        string UnityFSMCodeGenerator.IFsmDebugSupport.State { get { return context != null ? debugStateLookup[context.State] : null; }}
        
        List<string> UnityFSMCodeGenerator.IFsmDebugSupport.AllStates { get { return debugStringStates; }}
        
        #endregion
    
    }
    
}
