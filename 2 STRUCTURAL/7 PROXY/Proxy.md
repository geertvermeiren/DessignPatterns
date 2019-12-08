# PROXY
Proxy is a structural design pattern that lets you provide a substitute or placeholder for another object. A proxy controls access to the original object, allowing you to perform something either before or after the request gets through to the original object.

The Proxy pattern provides a surrogate or placeholder object to control access to another, different object. The Proxy object can be used in the same manner as its containing object.

## PROBLEM
Why would you want to control access to an object? Here is an example: you have a massive object that consumes a vast amount of system resources. You need it from time to time, but not always.

## SOLUTION
The Proxy pattern suggests that you create a new proxy class with the same interface as an original service object. Then you update your app so that it passes the proxy object to all of the original object’s clients. Upon receiving a request from a client, the proxy creates a real service object and delegates all the work to it.

# THE STRUCTURE

## The Subject
 defines a common interface for the RealSubject and the Proxy such that the Proxy can be used anywhere the RealSubject is expected.

## The RealSubject
 defines the concrete object which the Proxy represents.

## The Proxy
 maintains a reference to the RealSubject and controls access to it. It must implement the same interface as the RealSubject so that the two can be used interchangeably.


