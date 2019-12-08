## MEDIATOR
You can think of a Mediator object as a kind of traffic-coordinator; it directs traffic to appropriate parties based on its own state or outside values. Further, Mediator promotes loose coupling (a good thing!) by keeping objects from referring to each other explicitly.

# THE PARTICIPANTS
#The Mediator 
defines an interface for communicating with Collegue objects.
#The Colleague 
classes each know what Mediator is responsible for them and communicates with said Mediator whenever it would have otherwise communicated directly with another Colleague.
#The ConcreteMediator
classes implement behavior to coordinate Colleague objects. Each ConcreteMediator knows what its constituent Colleague classes are.