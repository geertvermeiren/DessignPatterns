## OBSERVER PATTERN = DON´T CALL US WE CALL YOU. => PUBLISHER SUBSCRIBER

The observer design pattern is yet another, one of my favorite design patterns which falls in the category of "behavioral pattern". Going by its name, we can say that observer is something (objects in case of OOPS) which is looking upon (observing) other object(s). Observer pattern is popularly known to be based on "The Hollywood Principle" which says- "Don’t call us, we will call you." Pub-Sub (Publisher-Subscriber) is yet another popular nickname given to Observer pattern.

Based on the "Hollywood principle", we can make a guess that in observer pattern, there is a special Hollywood celebrity object in which all other common objects are interested. In actual terms in the observer pattern - "There are n numbers of observers (objects) which are interested in a special object (called the subject). Explaining one step further- there are various objects (called observers) which are interested in things going on with a special object (called the subject). So they register (or subscribe) themselves to subject (also called publisher). The observers are interested in happening of an event (this event usually happens in the boundary of subject object) whenever this event is raised (by the subject/publisher) the observers are notified (they have subscribed for the happening of this event- Remember?)

# SUBSCRIBER
# CONCRETE SUBSCRIBER
# OBSERVER
# CONCRETE OBSERVER
# CLIENT
