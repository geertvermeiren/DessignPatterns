# COMMAND
//The Command design pattern encapsulates a request as an object,
// thereby allowing us developers to treat that request differently
// based upon what class receives said command. Further, 
//it enables much more complex architectures, and even enables operations such as undo/redo

The Participants - structur
The Command declares an interface for executing an operation.
The ConcreteCommand defines a binding between a Receiver and an action.
The Client creates a ConcreteCommand object and sets its receiver.
The Invoker asks the command to carry out its request.
The Receiver knows how to perform the operations associated with carrying out the request.

command
concretecommand 
invoker
receiver 
client

command
concretecommand
invoker 
receiver
client