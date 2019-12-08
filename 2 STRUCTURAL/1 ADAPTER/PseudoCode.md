# ADAPTER
- allows object with incompatible interfaces to collaborate
- example = xml to json converter 
- REAL WORLD EXAMPLE = SOCKET APDAPTER

 The Adapter pattern lets you create a middle-layer class that serves as a translator between your code and a legacy class, a 3rd-party class or any other class with a weird interface.


## The Target:
defines the domain-specific interface in use by the Client.
## The Client: 
collaborates with objects which conform to the Target.
## The Adapter:
 adapts the Adaptee to the Target.
## The Adaptee :
is the interface that needs adapting (i.e. the one that cannot be refactored).

Adapter and Facade are very similar, but they are used in different ways.

-Facade creates a new interface; Adapter re-uses an existing one.
-Facade hides several interfaces; Adapter makes two existing ones work together.
-Facade is the equivalent of saying "This is never gonna work; I will build my own."; -Adapter is the equivalent of "Of course it will work, it just needs a little tweaking."