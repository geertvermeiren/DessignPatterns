## STATE

The State design pattern seeks to allow an object to change its own behavior when its internal state changes.

In this pattern, the "states" in which an object can exist are classes unto themselves, which refer back to the object instance and cause that instance's behaviors to differ depending on the state it is currently residing in.

## REAL WORLD EXAMPLE:
BIEFSTEAK

## The Participants
# The Context 
defines an interface of interest to the clients. It also maintains a reference to an instance of ConcreteState which represents the current state.
# The State
 defines an interface for encapsulating the behavior of the object associated with a particular state.
#The ConcreteState 
objects are subclasses which each implement a behavior (or set of behaviors) associated with a state of the Context.

