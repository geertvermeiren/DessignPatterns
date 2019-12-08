# COMPOSITE

- convert objects into tree structure 

For example, imagine that you have two types of objects: Products and Boxes. A Box can contain several Products as well as a number of smaller Boxes. These little Boxes can also hold some Products or even smaller Boxes, and so on.

Say you decide to create an ordering system that uses these classes. Orders could contain simple products without any wrapping, as well as boxes stuffed with products...and other boxes. How would you determine the total price of such an order?

real world example:

Armies of most countries are structured as hierarchies. An army consists of several divisions; a division is a set of brigades, and a brigade consists of platoons, which can be broken down into squads. Finally, a squad is a small group of real soldiers. Orders are given at the top of the hierarchy and passed down onto each level until every soldier knows what needs to be done.

structure: 

##component:
The Component interface describes operations that are common to both simple and complex elements of the tree.
## leaf:
The Leaf is a basic element of a tree that doesn’t have sub-elements.

Usually, leaf components end up doing most of the real work, since they don’t have anyone to delegate the work to.
## composite:
The Container (aka composite) is an element that has sub-elements: leaves or other containers. A container doesn’t know the concrete classes of its children. It works with all sub-elements only via the component interface.

Upon receiving a request, a container delegates the work to its sub-elements, processes intermediate results and then returns the final result to the client.
## the client:
The Client works with all elements through the component interface. As a result, the client can work in the same way with both simple or complex elements of the tree.

-the leaf
