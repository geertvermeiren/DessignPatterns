# ITERATOR:
Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation".

Avoid direct access to datasource.

# The Participants:
## The Iterator 
defines an interface for accessing an Aggregate object and traversing elements within that Aggregate.
## The ConcreteIterator
 implements the Iterator interface and keeps track of its current position within the Aggregate.
## The Aggregate
 defines an interface for creating an Iterator object.
## The ConcreteAggregate 
implements the Iterator creation interface and returns a ConcreteIterator for that ConcreteAggregate.


