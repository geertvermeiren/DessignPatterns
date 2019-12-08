# MEMENTO

Memento design pattern provides the ability to store and restore object's internal state without breaking encapsulation. This pattern is useful when we have to support undo or redo operations over an object.

In OOPS, every object has internal state. To support undo/redo operations, we must save the state to somewhere. But due to encapsulation, object private/protected properties and methods are not available so that other objects can save these to external object.

Memento provides a memento object to save internal state of an object. This memento object can be restore later.

# PARTICIPANTS

## Memento: 
It stores internal state of the Originator object. 

## originator: 
Responsible for createing and restoring memento object.

## Caretaker: 
It is responsible for saving the memento object. Caretaker cannot modify the memento object.