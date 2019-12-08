# VISITOR * 
The Visitor design pattern lets us operate on objects by representing that operation as an object unto itself. Thereby, we can operate on said objects without changing the classes or definitions of those objects.

#The Element
 defines an Accept operation which takes a Visitor as an argument.
#The ConcreteElement
 implements the Accept operation defined by the Element.
# The Visitor
 declares an operation for each of ConcreteElement in the object structure.
#The ConcreteVisitor
 implements each operation defined by the Visitor. Each operation implements a fragment of the algorithm needed for that object.
#The ObjectStructure
 can enumerate its elements and may provide a high-level interface to allow the Visitor to visit its elements.